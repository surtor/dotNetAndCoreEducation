using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace RoboVoiceGenerator
{
    public class WAVFactory : BaseFactory
    {
        public WAVFactory(LANG currentLANG) : base(currentLANG, Config.pathToWAVJsonFile) { }

        private string RemoveSpecSymbolFromText()
        {
            string calenedText = Regex.Replace(this.currentObject.GetText(currentLANG), @"\[.*?\]", String.Empty); // @"\[.*?\]" - I don't know how does it works. But, it worked!
            calenedText = calenedText.Replace("\n", "");
            calenedText = calenedText.Replace("\r", "");
            return calenedText;
        }

        protected override bool Generate()
        {
            if (File.Exists(this.GetFullPath()) && this.currentObject.TxtExist)
            {
                //text is up to date and wav file exist - assume no need to regenerate wav file.
                this.currentObject.WavExist = true;
                return true;
            }
            string path = GetFullPath();
            string cleanedText = RemoveSpecSymbolFromText();
            string commandLineArg = $"-t \"{cleanedText}\" -w {path} -n {this.currentObject.Voice}";
            this.ExecuteBalcon(commandLineArg);
            if (File.Exists(this.GetFullPath()))
            {
                return true;
            }
            else
            {
                Console.WriteLine($"ERROR: Generate wav = {this.GetFullPath()} file failed!");
                return false;
            }
        }

        private string GetFullPath()
        {
            return $"{Config.generatedVoiceRootFolder}/{currentObject.typeOfVO}/{this.currentLANG}/{this.currentObject.FolderName}/{this.currentObject.FileName}.wav";
        }

        private void ExecuteBalcon(string commandLineArg)
        {
            if (!File.Exists(Config.balconBinPath))
            {
                Console.WriteLine($"WARNING: File {Config.balconBinPath} not Exist, skip GenerateWav step.");
                return;
            }

            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.CreateNoWindow = false;
            processInfo.UseShellExecute = false;
            processInfo.FileName = Config.balconBinPath;
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

        protected override void CreateJsonForImport()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;

                writer.WriteStartObject();
                writer.WritePropertyName("ImportGroups");
                writer.WriteStartArray();
                writer.WriteStartObject();
                writer.WritePropertyName("bReplaceExisting");
                writer.WriteValue("true");

                writer.WritePropertyName("ImportSettings");
                writer.WriteValue("");

                writer.WritePropertyName("FileNames");
                writer.WriteStartArray();
                writer.WriteValue(this.GetFullPath());
                writer.WriteEnd();

                writer.WritePropertyName("GroupName");
                writer.WriteValue("RoboVoice");
                writer.WritePropertyName("DestinationPath");
                writer.WriteValue($"{this.currentObject.Ue4DestinationPath}");
                writer.WritePropertyName("bSkipReadOnly");
                writer.WriteValue("false");
                writer.WriteEnd();
                writer.WriteEndObject();
            }

            using (StreamWriter fw = File.CreateText(Config.pathToWAVJsonFile))
            {
                fw.WriteLine(sb.ToString());
            }
        }

        protected override string PrepaireToImport()
        {
            if (File.Exists(this.GetUassetPath()) && this.currentObject.WavExist)
            {
                Console.WriteLine($"INFO: File {this.GetUassetPath()} exist and wav file is uptodate, skip Import step.");
                return "";
            }
            this.CreateJsonForImport();
            return $"{Config.ProjectName}.uproject -run=ImportAssets -nosourcecontrol -importsettings=\"{JsonPath}\"";
        }
    }
}
