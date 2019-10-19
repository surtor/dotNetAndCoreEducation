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
            Config setupConfig = new Config(args[0].Replace("\\","/"), args[1]);
            //HttpClient client = new HttpClient();

            string json = "";

            using (StreamReader r = new StreamReader(Config.jsonSourceFilePath))
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
                if(tXTFactory.Main(voObj))
                {
                    wAVFactory.Main(voObj);
                    fBXFactory.Main(voObj);
                }
            }
        }
    }
}
