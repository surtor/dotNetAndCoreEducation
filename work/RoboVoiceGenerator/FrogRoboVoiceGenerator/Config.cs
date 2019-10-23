using System;
using System.Collections.Generic;
using System.Text;



namespace RoboVoiceGenerator
{
    public class Config
    {
        private static string rootPath = "G:/C#/ConsoleApplication01/dotNetAndCoreEducation.git/trunk/work";
        private static string projectName = "SH9";
        public static string ProjectName
        { get { return projectName; } set { projectName = value; } }

        public readonly static string pathToFBXpythonScript = "G:/svn/FrogMacros/FrogMacros/lipsync.py";

        public readonly static string jsonLocalSourceDialog = $"{rootPath}/source.json";
        public readonly static string jsonLocalSourceComments = $"{rootPath}/sourceComments.json";

        public readonly static string ue4BinPath = $"{rootPath}/Engine/Binaries/Win64/UE4Editor-Cmd.exe";
        public readonly static string balconBinPath = $"{rootPath}/bin/balcon.exe";
        public readonly static string faceFXBinPath = "C:/Program Files (x86)/FaceFX/FaceFX 2017/facefx-studio.com";
        public readonly static string projectRootVoicesFolder = $"{rootPath}/{projectName}/Content/Voices";
        public readonly static string fbxToDoList = $"{rootPath}/wavList.txt";
        public readonly static string pathToFBXJsonFile = $"{rootPath}/fbxImportJson.json";
        public readonly static string pathToWAVJsonFile = $"{rootPath}/wavImportJson.json";
        public readonly static string generatedVoiceRootFolder = $"{rootPath}/VoiceSource";
        public readonly static string voiceOverRootFolder = $"{rootPath}/voSource";

        public readonly static string commentsURL = $"http://192.168.1.16:4043/api/project/{projectName}/engine/robovoice/comments";
        public readonly static string dialogURL = $"http://192.168.1.16:4043/api/project/{projectName}/engine/robovoice/dialogues";

        public Config(string _rootPath, string _projectName)
        {
            rootPath = _rootPath;
            ProjectName = _projectName;
        }

    }
}
