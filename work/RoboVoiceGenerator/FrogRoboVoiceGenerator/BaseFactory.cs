using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace RoboVoiceGenerator
{
    abstract public class BaseFactory
    {
        protected LANG currentLANG;
        protected VoiceObject currentObject;
        protected string JsonPath;

        protected BaseFactory(LANG currentLANG, string jsonPath)
        {
            this.currentLANG = currentLANG;
            JsonPath = jsonPath;
        }

        virtual protected string GetUassetPath()
        {
            return $"{Config.projectRootVoicesFolder}/{currentObject.typeOfVO}/{this.currentObject.FolderName}/{this.currentObject.FileName}.uasset";
        }

        virtual protected string GetWavPath()
        {
            return $"{Config.generatedVoiceRootFolder}/{currentObject.typeOfVO}/{this.currentLANG}/{this.currentObject.FolderName}/{this.currentObject.FileName}.wav";
        }

        abstract protected bool Generate();
        abstract protected string PrepaireToImport();
        abstract protected void CreateJsonForImport();
        virtual protected void ImportToEngine()
        {
            if (!File.Exists(Config.ue4BinPath))
            {
                Console.WriteLine($"ERROR: CANNOT Get Engine BIN! {Config.ue4BinPath} -> skip Import step.");
                return;
            }

            string commandLineArg = PrepaireToImport();

            if (commandLineArg == "")
            {
                return;
            }

            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.CreateNoWindow = false;
            processInfo.UseShellExecute = false;
            processInfo.FileName = Config.ue4BinPath;
            processInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processInfo.Arguments = commandLineArg;
            Console.WriteLine($"INFO: Executing the following command: {processInfo.FileName} {processInfo.Arguments}");
            try
            {
                using (Process executeProcess = Process.Start(processInfo))
                {
                    executeProcess.WaitForExit();
                }
            }
            catch
            {
                Console.WriteLine($"Someting went wrong with this arg: {commandLineArg}");
            }
        }

        public bool Main(VoiceObject currentObject)
        {
            this.currentObject = currentObject;
            if (!Generate())
            {
                return false;
            }
            ImportToEngine();
            return true;
        }




    }

}
