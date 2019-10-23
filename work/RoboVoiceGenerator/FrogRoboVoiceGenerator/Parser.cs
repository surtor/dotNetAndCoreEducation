using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace RoboVoiceGenerator
{
    public class Parser
    {
        private List<VoiceObject> voiceObjectList = new List<VoiceObject>();
        private readonly dynamic collection;
        private readonly DORC switcher;

        public Parser(DORC typeOfVO, bool web)
        {
            if (typeOfVO == DORC.Dialogs)
            {
                if (web)
                {
                    this.collection = GetWebData(Config.dialogURL);
                }
                
                else
                {
                    this.collection = GetLocalData(Config.jsonLocalSourceDialog);
                }

                this.switcher = typeOfVO;
            }
            else
            {
                if (web)
                {
                    this.collection = GetWebData(Config.commentsURL);
                }
                else
                {
                    this.collection = GetLocalData(Config.jsonLocalSourceComments);
                }
                this.switcher = typeOfVO;
            }
        }

        private dynamic GetLocalData(string pathToLocalFile)
        {
            using (StreamReader r = new StreamReader(pathToLocalFile))
            {
                return JsonConvert.DeserializeObject(r.ReadToEnd());
            }
        }

        private dynamic GetWebData(string url)
        {

            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            if (webRequest == null)
            {
                Console.WriteLine("ERROR: WEB SERVER RETURN NULL. EXIT");
                Environment.Exit(100500);
            }

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var contributorsAsJson = sr.ReadToEnd();
                    dynamic contributors = JsonConvert.DeserializeObject(contributorsAsJson);
                    return contributors;
                }
            }
        }

        private void ParseDialog()
        {
            foreach (var item in this.collection)
            {
                if (item.topics == null) continue;
                foreach (var topic in item.topics)
                {
                    if (topic.labels == null) continue;
                    foreach (var label in topic.labels)
                    {
                        if (label.phrases == null) continue;
                        foreach (var phrase in label.phrases)
                        {
                            VoiceObject vo = new VoiceObject(
                                item.containerID.ToString(), 
                                DORC.Dialogs,
                                phrase.character.name.ToString(),
                                phrase.character.gender.ToString(),
                                phrase.text
                                );

                            if (phrase.phraseID != null)
                            {
                                vo.FileName = phrase.phraseID;
                            }
                            else
                            {
                                Console.WriteLine($"WARNING: This topic: {item.containerID} doesn't have any phrases!");
                                continue;
                            }
                            this.voiceObjectList.Add(vo);
                        }
                    }
                }
            }
        }

        private void ParseComments()
        {
              foreach (var item in collection)
              {
                    if (item.subcontainers == null) continue;
                    foreach (var subcontainer in item.subcontainers)
                    {
                        if (subcontainer.comments == null) continue;
                        foreach (var comments in subcontainer.comments)
                        {
                            if (comments.characters == null) continue;
                            foreach (var character in comments.characters)
                            {
                                VoiceObject vo = new VoiceObject(
                                    subcontainer.subcontainerID.ToString(), 
                                    DORC.Comments, 
                                    character.name.ToString(), 
                                    character.gender.ToString(),
                                    comments.text
                                    );

                                if (comments.commentID != null)
                                {
                                    string temp = comments.commentID.ToString();
                                    vo.FileName = $"{comments.nameID}{temp.Replace("Comment", "")}";
                                }
                                this.voiceObjectList.Add(vo);
                            }
                        }
                    }
            }
        }

        public List<VoiceObject> DoParse()
        {
            if (switcher == DORC.Dialogs)
            {
                this.ParseDialog();
            }
            else
            {
                this.ParseComments();
            }
            return voiceObjectList;
        }
    }
}
