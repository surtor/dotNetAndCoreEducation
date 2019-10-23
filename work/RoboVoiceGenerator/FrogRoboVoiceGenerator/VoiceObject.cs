using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

public enum LANG { EN, DE, FR, RU };
public enum DORC { Comments, Dialogs };


namespace RoboVoiceGenerator
{
    public class VoiceObject
    {
        public string Ue4DestinationPath { get; }
        public string FolderName { get; }

        private dynamic text;
        public dynamic Text { get; }


        private string character;
        public string Character { get; }


        private string gender;
        public string Gender { get; }

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
        }
        
        // flags TODO: is it the best way to do it?
        private bool txtExist = false;
        public bool TxtExist
        { get { return txtExist; } set { txtExist = value; } }

        private bool wavExist = false;
        public bool WavExist
        { get { return wavExist; } set { wavExist = value; } }

        private bool uassetExist = false;
        public bool UassetExist
        { get { return uassetExist; } set { uassetExist = value; } }

        public readonly DORC typeOfVO;

        private bool fbxExist = false;
        public bool FbxExist
        { get { return fbxExist; } set { fbxExist = value; } }
        
        //constructor part
        public VoiceObject(string containerID, DORC typeOfVO, string character, string gender, dynamic text)
        {

            this.Ue4DestinationPath = $"/Voices/{typeOfVO}/{containerID}";
            this.FolderName = containerID;
            this.typeOfVO = typeOfVO;
            this.character = character;
            this.gender = gender;
            this.text = text;

            if (Character == "mc")
                this.voice = "Joey";
            else if (Gender == "M")
                this.voice = "Eric";
            else if (Gender == "F")
                voice = "Salli";
            else
                this.voice = "Eric";
        }

        public override string ToString()
        {
            return $"ue4DestinationPath = {Ue4DestinationPath}\n text = {text}\n character = {character}\n gender = {gender}\n fileName = {fileName}\n";
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
                    Console.WriteLine($"WARNING: Wrong argument. {language} Return EN");
                    return this.text.en;
            }
        }
      
    }
}
