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

        private string RemoveSpecSymbolFromTextFile()
        {
            string calenedText = Regex.Replace(this.currentObject.Text, @"\[.*?\]", String.Empty); // @"\[.*?\]" - I don't what is it and how does it works. But, it works!
            calenedText = calenedText.Replace("\n", "");
            calenedText = calenedText.Replace("\r", "");
            return calenedText;
        }

        protected override bool Generate()
        {
            string path = GetFullPath();
            string cleanedText = RemoveSpecSymbolFromTextFile();
            string commandLineArg = $"-t {cleanedText} -w {path} -n {this.currentObject.Voice}";
            this.ExecuteBalcon(commandLineArg);
            if (File.Exists(this.GetFullPath()))
            {
                return true;
            }
            else
            {
                Console.WriteLine("ERROR!!!!!");
                return false;
            }
        }

        private string GetFullPath()
        {
            return $"{Config.voRootFolder}/Dialog/{this.currentLANG}/{this.currentObject.FileName}.wav";
        }

        private void ExecuteBalcon(string commandLineArg)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.CreateNoWindow = false;
            processInfo.UseShellExecute = false;
            processInfo.FileName = Config.balconPath;
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
                writer.WriteValue($"{this.currentObject.ue4path}");
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
    }
}
