using System;

namespace RoboVoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            DORC currentTask = DORC.Comments;
            bool web = true;
            bool dev = false;

            if (args.Length != 0)
            {   

                if (args[0] == "-h")
                {
                    Console.WriteLine("Ex: <RootFolder> <ProjectName> <currentTask>");
                    Environment.Exit(0);
                }

                Config setupConfig = new Config(args[0].Replace("\\","/"), args[1]);

                if (args[2] == "Comments")
                {
                    currentTask = DORC.Comments;
                }
                else if (args[2] == "Dialogs")
                {
                    currentTask = DORC.Dialogs;
                }
                else
                {
                    Console.WriteLine($"{args[2]} must be Comments or Dialogs");
                    Environment.Exit(100500);
                }
                web = true; //if we launch it as final program, with args -> it must use web as a source.
            }
            else if (dev)
            {
                web = false;
            }
            else
            {
                Console.WriteLine("No args, use -h or set args.\nEx: <RootFolder> <ProjectName> <currentTask>");
                Environment.Exit(0);
            }


            Console.WriteLine(Config.commentsURL);
            Console.WriteLine(Config.dialogURL);

            Parser parser = new Parser(currentTask, web);
            TXTFactory tXTFactory = new TXTFactory(LANG.EN);
            WAVFactory wAVFactory = new WAVFactory(LANG.EN);
            FBXFactory fBXFactory = new FBXFactory(LANG.EN);

            foreach (var voObj in parser.DoParse())
            {
                if(tXTFactory.Main(voObj))
                {
                    wAVFactory.Main(voObj);
                    fBXFactory.Main(voObj);
                }
            }
        }
    }
}
