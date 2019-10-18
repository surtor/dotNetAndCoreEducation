using System;
using System.Collections.Generic;
using System.Text;

namespace RoboVoiceGenerator
{
    public class Config
    {
        public static string ue4BinPath = "G:/svn/UE4T/Engine/Binaries/Win64/UE4Editor-Cmd.exe";
        public static string balconBinPath = "G:/svn/UE4T/SH9/Helpers/DialogScripts/Lib/balcon.exe";
        public static string faceFXBinPath = "\"C:/Program Files (x86)/FaceFX/FaceFX 2017/facefx-studio\"";
        public static string projectRootVoicesFolder = "G:/svn/UE4T/SH9/Content/Voices";
        public static string fbxToDoList = "G:/svn/FrogMacros/FrogMacros/wavList.txt";
        public static string pathToFBXJsonFile = "G:/svn/FrogMacros/CSmacros/fbxImportJson.json";
        public static string pathToWAVJsonFile = "G:/svn/FrogMacros/CSmacros/wavImportJson.json";
        public static string generatedVoiceRootFolder = "G:/svn/VoiceSource";
        public static string voiceOverRootFolder = "G:/svn/voSource";
    }
}
