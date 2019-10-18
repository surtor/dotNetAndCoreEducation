using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace RoboVoiceGenerator
{
    public class Helpers
    {
        public static string GetCharacterGender(string characterName)
        {
            //TODO: get info about character gender
            return "M";
        }

        public static void ExecuteBalcon (string commandLineArg)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.CreateNoWindow = false;
            processInfo.UseShellExecute = false;
            processInfo.FileName = "G:/svn/UE4T/SH9/Helpers/DialogScripts/Lib/balcon.exe";
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
    }
}
