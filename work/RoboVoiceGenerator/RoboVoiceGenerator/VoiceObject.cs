using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

public enum LANG { EN, DE, FR, RU };
public enum FILETYPE { txt, wav, uasset, fbx };

namespace RoboVoiceGenerator
{
    public class VoiceObject
    {
        private string destinationPath;
        public string ue4DestinationPath;
        private string voDestinationPath;

        private dynamic text;
        public dynamic Text
        { get { return text; } set { text = value; }}

        private string character;
        public string Character
        { get { return character; } set { character = value; } }

        private string gender;
        public string Gender
        { get { return gender; } set { gender = value; } }

        private string fileName;
        public string FileName
        {
             get {  return fileName; }
             set {
                   fileName = $"{this.character}_{value}";
            }
        }

        private string voice = "Joey";
        public string Voice
        {
             get {  return voice; }
            set  { voice = value; }
        }

        public VoiceObject(string containerID)
        {
            //constructor part
            this.destinationPath = $"{Config.projectRootVoicesFolder}/Dialogs/{containerID}";
            this.ue4DestinationPath = $"/Voices/Dialogs/{containerID}";
            this.voDestinationPath = $"{Config.generatedVoiceRootFolder}/Dialogs/{containerID}";
            
            //we setup this data later
            this.text = null;
            this.character = null;
            this.gender = null;
            this.fileName = null;
        }

        public override string ToString()
        {
            return $"fullPath = {fullPath}\n ue4path = {ue4path}\n text = {text}\n character = {character}\n gender = {gender}\n voiceSourceFolder = {voiceSourceFolder}\n fileName = {fileName}\n";
        }

        public string GetText(LANG language)
        {
            switch (language)
            {
                case LANG.EN:
                    return this.text.en;
                case LANG.DE:
                    return this.text.de;
                case LANG.FR:
                    return this.text.fr;
                case LANG.RU:
                    return this.text.ru;
                default:
                    Console.WriteLine($"Wrong argument. {language} Return EN");
                    return this.text.en;
            }
        }
      
    }
}
