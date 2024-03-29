﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RoboVoiceGenerator
{
    public class TXTFactory : BaseFactory
    {
        public TXTFactory(LANG currentLANG) : base(currentLANG, "") { }

        protected override bool Generate()
        {
            if (this.Is_textFileUpToDate())
            {
                return false;
            }
            string path = GetFullPath();

            System.IO.FileInfo file = new System.IO.FileInfo(path);
            file.Directory.Create(); // If the directory already exists, this method does nothing.
            //System.IO.File.WriteAllText(file.FullName, content);

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

        private string GetFullPath()
        {
            return $"{Config.generatedVoiceRootFolder}/Dialog/{this.currentLANG}/{this.currentObject.FolderName}/{this.currentObject.FileName}.txt";
        }

        protected override void CreateJsonForImport() { }

        protected override void ImportToEngine() { }

        public bool Is_textFileUpToDate()
        {
            string path = GetFullPath();
            //Console.WriteLine($"Checking the following file: {path}");
            if (File.Exists(path))
            {
                //Console.WriteLine($"File {path} exist");
                using (StreamReader data = new StreamReader(path))
                {
                    string f_text = data.ReadToEnd();
                    return this.currentObject.GetText(this.currentLANG) == f_text;
                }
            }
            else
            {
                Console.WriteLine($"File {path} NO Exist");
                return false;
            }

        }
    }
}
