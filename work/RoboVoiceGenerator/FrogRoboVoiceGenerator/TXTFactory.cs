using System;
using System.IO;

namespace RoboVoiceGenerator
{
    public class TXTFactory : BaseFactory
    {
        public TXTFactory(LANG currentLANG) : base(currentLANG, "") { }

        protected override bool Generate()
        {
            if (this.Is_textFileUpToDate())
            {
                this.currentObject.TxtExist = true;
                return true;
            }
            string path = GetFullPath();

            System.IO.FileInfo file = new System.IO.FileInfo(path);
            file.Directory.Create(); // If the directory already exists, this method does nothing.

            using (StreamWriter fw = File.CreateText(path))
            {
                fw.WriteLine(this.currentObject.GetText(this.currentLANG));
            }
            if (File.Exists(this.GetFullPath()))
            {
                return true;
            }
            else
            {
                Console.WriteLine($"ERROR: Generate txt = {this.GetFullPath()} file failed!");
                return false;
            }
        }

        protected string GetFullPath()
        {
            return $"{Config.generatedVoiceRootFolder}/{currentObject.typeOfVO}/{this.currentLANG}/{this.currentObject.FolderName}/{this.currentObject.FileName}.txt";
        }

        protected override void CreateJsonForImport() { } //we don't use it for a txt file.

        protected override void ImportToEngine() { } //we don't need to import a txt file.

        public bool Is_textFileUpToDate()
        {
            string path = GetFullPath();
            if (File.Exists(path))
            {
                using (StreamReader data = new StreamReader(path))
                {
                    string f_text = data.ReadToEnd();
                    f_text = f_text.Replace("\n", "");
                    f_text = f_text.Replace("\r", "");
                    return this.currentObject.GetText(this.currentLANG) == f_text;
                }
            }
            else
            {
                Console.WriteLine($"INFO: File {path} NOT Exist");
                return false;
            }

        }

        protected override string PrepaireToImport() { return ""; }
    }
}
