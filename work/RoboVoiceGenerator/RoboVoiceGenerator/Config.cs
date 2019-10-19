using System;
using System.Collections.Generic;
using System.Text;

namespace RoboVoiceGenerator
{
    public class Config
    {
        private static string rootPath = "D:/svn/C#/trunk/work";
        private static string projectName = "SH9";

        //TODO: remove it if you get data from web.
        public static string jsonSourceFilePath = $"{rootPath}/source.json";

        public static string ue4BinPath = $"{rootPath}/UE4T/Engine/Binaries/Win64/UE4Editor-Cmd.exe";
        public static string balconBinPath = $"{rootPath}/bin/balcon.exe";
        public static string faceFXBinPath = "\"C:/Program Files (x86)/FaceFX/FaceFX 2017/facefx-studio\"";
        public static string projectRootVoicesFolder = $"{rootPath}/{projectName}/Content/Voices";
        public static string fbxToDoList = $"{rootPath}/wavList.txt";
        public static string pathToFBXJsonFile = $"{rootPath}/fbxImportJson.json";
        public static string pathToWAVJsonFile = $"{rootPath}/wavImportJson.json";
        public static string generatedVoiceRootFolder = $"{rootPath}/RootVoiceFolder/Generated";
        public static string voiceOverRootFolder = $"{rootPath}/RootVoiceFolder/VO";

        public Config(string _rootPath, string _projectName)
        {
            rootPath = _rootPath;
            projectName = _projectName;
        }

    }
}
