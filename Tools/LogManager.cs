using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class LogManager
    {
      private  static string logpath="Log";
        

        public static string GetCurrentPathfolder()
        {
            string CurrentfolderPath = @$"{logpath}\_{DateTime.Now.Year}_{DateTime.Now.Month}";
            if (!Directory.Exists(CurrentfolderPath))
                Directory.CreateDirectory(CurrentfolderPath);
            return CurrentfolderPath;

        }
        public static string GetCurrentPathfile()
        {
            string CurrentfilePath = @$"{GetCurrentPathfolder()}\{DateTime.Now.Year}_{DateTime.Now.Month}.txt";
            if (!File.Exists(CurrentfilePath))
                File.Create(CurrentfilePath).Close();
            return CurrentfilePath;

        }
        public static void WriteToLog(string nameP, string nameF, string message)
            {
          
            using (StreamWriter sw = new StreamWriter(LogManager.GetCurrentPathfile(), true))
            {
                sw.WriteLine($"{DateTime.Now}\t{nameP}.{nameF}:\t{message}");
            }
        }
        public static void CleanOldLogs()
        {

            DateTime cutoffDate = DateTime.Now.AddMonths(-2);


            string[] directories = Directory.GetDirectories(logpath);

            foreach (string directory in directories)
            {

                DateTime creationTime = Directory.GetCreationTime(directory);


                if (creationTime < cutoffDate)
                {
                    Directory.Delete(directory, true);
                }
            }
        }

    }
}
