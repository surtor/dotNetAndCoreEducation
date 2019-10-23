using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace RoboVoiceGenerator
{
    public class FBXFactory : BaseFactory
    {
        public FBXFactory(LANG currentLANG) : base(currentLANG, Config.pathToFBXJsonFile) { }

        protected override bool Generate()
        {
            if (File.Exists(this.GetFullPath()) && this.currentObject.WavExist && this.currentObject.TxtExist)
            {
                this.currentObject.FbxExist = true;
                Console.WriteLine($"INFO: File {this.GetFullPath()} exist wav, txt file is uptodate, skip Import step.");
                return true;
            }

            using (StreamWriter fw = File.CreateText(Config.fbxToDoList))
            {
                fw.WriteLine(this.GetWavPath());
            }

            string commandLineArg = $"-exec \"{Config.pathToFBXpythonScript}\"";
            this.ExecuteFaceFXstudio(commandLineArg);
            if(File.Exists(this.GetFullPath()))
            {
                return true;
            }
            else
            {
                Console.WriteLine($"ERROR: FBX file {this.GetFullPath()} have not generated!");
                return false;
            }
        }

        private string GetFullPath()
        {
            return $"{Config.generatedVoiceRootFolder}/{currentObject.typeOfVO}/{this.currentLANG}/{this.currentObject.FolderName}/{this.currentObject.FileName}_face.fbx";
        }

        protected override string GetUassetPath()
        {
            return $"{Config.projectRootVoicesFolder}/{currentObject.typeOfVO}/{this.currentObject.FolderName}/{this.currentObject.FileName}_face.uasset";
        }

        private void ExecuteFaceFXstudio(string commandLineArg)
        {
            if (!File.Exists(Config.faceFXBinPath))
            {
                Console.WriteLine($"WARNING: File {Config.faceFXBinPath} not Exist, skip FBXGenenerate step.");
                return;
            }
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.CreateNoWindow = false;
            processInfo.UseShellExecute = false;
            processInfo.FileName = Config.faceFXBinPath;
            processInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processInfo.Arguments = commandLineArg;
            Console.WriteLine($"INFO: Executing the following command: {processInfo.FileName} {processInfo.Arguments}");
            try
            {
                using (Process executeProcess = Process.Start(processInfo))
                {
                    executeProcess.WaitForExit(); //TODO: find the way to get exit code from side process and trow it if it not equal 0
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
                writer.WriteStartObject();
                writer.WritePropertyName("AnimSequenceImportData");
                writer.WriteStartObject();
                writer.WritePropertyName("bUseDefaultSampleRate");
                writer.WriteValue("True");
                writer.WritePropertyName("bImportMesh");
                writer.WriteValue("False");
                writer.WritePropertyName("AnimationLength");
                writer.WriteValue("FBXALIT_ExportedTime");
                writer.WritePropertyName("bRemoveRedundantKeys");
                writer.WriteValue("False");
                writer.WritePropertyName("bPreserveLocalTransform");
                writer.WriteValue("False");
                writer.WritePropertyName("bImportMorphTargets");
                writer.WriteValue("True");
                writer.WritePropertyName("bForceFrontXAxis");
                writer.WriteValue("False");
                writer.WritePropertyName("bSetMaterialDriveParameterOnCustomAttribute");
                writer.WriteValue("False");
                writer.WritePropertyName("bDeleteExistingMorphTargetCurves");
                writer.WriteValue("False");
                writer.WritePropertyName("bConvertSceneUnit");
                writer.WriteValue("False");
                writer.WritePropertyName("bDoNotImportCurveWithZero");
                writer.WriteValue("True");
                writer.WritePropertyName("bConvertScene");
                writer.WriteValue("True");
                writer.WritePropertyName("bImportCustomAttribute");
                writer.WriteValue("True");
                writer.WriteEnd();
                writer.WritePropertyName("bImportAnimations");
                writer.WriteValue("True");
                writer.WritePropertyName("MeshTypeToImport");
                writer.WriteValue("FBXIT_Animation");
                writer.WritePropertyName("Skeleton");
                writer.WriteValue("/Game/Animation_Asset/Skeletons/CHR_Main_Character_Skeleton.CHR_Main_Character_Skeleton");
                writer.WritePropertyName("bImportAsSkeletal");
                writer.WriteValue("True");
                writer.WritePropertyName("OriginalImportType");
                writer.WriteValue("FBXIT_SkeletalMesh");
                writer.WritePropertyName("bImportMaterials");
                writer.WriteValue("False");
                writer.WritePropertyName("SkeletalMeshImportData");
                writer.WriteStartObject();
                writer.WritePropertyName("bImportMeshesInBoneHierarchy");
                writer.WriteValue("False");
                writer.WriteEnd();
                writer.WriteEnd();

                writer.WritePropertyName("FileNames");
                writer.WriteStartArray();
                writer.WriteValue(this.GetFullPath());
                writer.WriteEnd();

                writer.WritePropertyName("GroupName");
                writer.WriteValue("LipSync");
                writer.WritePropertyName("DestinationPath");
                writer.WriteValue($"{this.currentObject.Ue4DestinationPath}");
                writer.WritePropertyName("FactoryName");
                writer.WriteValue("FbxFactory");
                writer.WritePropertyName("bSkipReadOnly");
                writer.WriteValue("false");
                writer.WriteEnd();
                writer.WriteEndObject();
            }

            using (StreamWriter fw = File.CreateText(Config.pathToFBXJsonFile))
            {
                fw.WriteLine(sb.ToString());
            }
        }

        protected override string PrepaireToImport()
        {
            if (File.Exists(this.GetUassetPath()) && this.currentObject.FbxExist)
            {
                Console.WriteLine($"INFO: File {this.GetUassetPath()} exist and wav file is uptodate, skip Import step.");
                return "";
            }
            this.CreateJsonForImport();
            return $"{Config.ProjectName}.uproject -run=ImportAssets -nosourcecontrol -importsettings=\"{JsonPath}\"";
        }
    }
}
