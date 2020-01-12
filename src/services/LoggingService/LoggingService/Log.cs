using System;
using System.IO;

namespace LoggingService
{
    public class Log
    {
        private string _dir;
        public Log()
        {
            _dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            _dir += "\\logs";
        }


        public void CreateLog(string[] message)
        {
            CheckFolderStructure();
            WriteToFile(message);
        }
        /// <summary>
        /// Creates the necessary folder structure
        /// [desktop/logs/year/month/day]
        /// </summary>
        private void CheckFolderStructure()
        {
            if (!File.Exists(_dir))
            {
                Directory.CreateDirectory(_dir);
            }

            string currentYear = DateTime.Today.Year.ToString();
            string folderPath = Path.Combine(_dir, currentYear);

            if (!File.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string currentMonth = DateTime.Today.Month.ToString();
            folderPath = Path.Combine(folderPath, currentMonth);
            if (!File.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string currentDay = DateTime.Today.Day.ToString();
            folderPath = Path.Combine(folderPath, currentDay);
            if (!File.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        /// <summary>
        /// Calculates todays date, and converts it into a path.
        /// </summary>
        /// <returns>a string with the path for today's folder</returns>
        private string ConstructTodaysPath()
        {
            string currentYear = DateTime.Today.Year.ToString();
            string currentMonth = DateTime.Today.Month.ToString();
            string currentDay = DateTime.Today.Day.ToString();

            string path = Path.Combine(_dir, currentYear, currentMonth, currentDay);
            return path;
        }

        /// <summary>
        /// writes the message to a txt file.
        /// </summary>
        /// <param name="message">A string array with the messages to be written to file</param>
        private void WriteToFile(string[] message)
        {
            string logName = "log.txt";
            string todaysPath = ConstructTodaysPath();

            string logFile = Path.Combine(todaysPath, logName);
            if (!File.Exists(logFile))
            {
                using (StreamWriter sw = File.CreateText(logFile))
                {
                    foreach (var m in message)
                    {
                        sw.WriteLine(m);
                    }
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(logFile))
                {
                    sw.WriteLine("");

                    foreach (var m in message)
                    {
                        sw.WriteLine(m);
                    }
                }
            }
        }
    }
}