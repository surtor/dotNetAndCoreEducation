using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RoboVoiceGenerator;
using System.Collections.Generic;
//using System.Net.Http;

namespace RoboVoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //HttpClient client = new HttpClient();
            Config.ue4Path = "G:/svn/UE4T/Engine/Binaries/Win64/UE4Editor-Cmd.exe";

            string jsonSourceFilePath = "G:/svn/FrogMacros/CSmacros/source.json";
            Config.rootPath = "G:/svn/UE4T/SH9/Content/Voices";
            Config.voRootFolder = "G:/svn/VoiceSource";
            string json = "";

            using (StreamReader r = new StreamReader(jsonSourceFilePath))
            {
                json = r.ReadToEnd();
            }

            dynamic collection = JsonConvert.DeserializeObject(json);
            List<VoiceObject> voiceObjectList = new List<VoiceObject>();

            foreach (var item in collection)
                {
                    foreach (var topic in item.topics)
                    {
                        foreach (var label in topic.labels)
                        {
                            foreach (var phrase in label.phrases)
                            {
                                VoiceObject vo = new VoiceObject(item.containerID.ToString());
                                vo.Text = phrase.text;
                                vo.Character = phrase.character;
                                if (phrase.phraseID != null)
                                {
                                    vo.FileName = phrase.phraseID;
                                }
                                else
                                {
                                    Console.WriteLine($"WARNING: This topic: {item.containerID} doesn't have any phrases!");
                                    continue;
                                }
                                vo.Gender = Helpers.GetCharacterGender(vo.Character);
                                voiceObjectList.Add(vo);
                            }
                        }
                    }
                }

            TXTFactory tXTFactory = new TXTFactory(LANG.EN);
            WAVFactory wAVFactory = new WAVFactory(LANG.EN);
            FBXFactory fBXFactory = new FBXFactory(LANG.EN);

            foreach (var voObj in voiceObjectList)
            {
                if(tXTFactory.main(voObj))
                {
                    wAVFactory.main(voObj);
                    fBXFactory.main(voObj);
                }
                //if (!voObj.Is_textFileUpToDate(LANG.EN))
                //{
                //    voObj.GenerateTextFile(LANG.EN);
                //    voObj.GenerateWavFile(LANG.EN);
                //    voObj.ImportWavFile(LANG.EN);
                //    if (!voObj.GenerateFBXFile(LANG.EN))
                //    {
                //        Console.WriteLine($"WARNINGL FBX for this file {voObj.FileName} have not beed created");
                //    }
                //    voObj.ImportFbxFile(LANG.EN);
                //}
            }
        }
    }
}
