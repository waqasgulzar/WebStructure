using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Common.Logging
{
    public class WebLogging
    {
        private static string CheckOrCreateLogsBaseFolder()
        {
            try
            {

                string FolderPath = @"" + Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Web-Exception\WebException";

                if (!System.IO.Directory.Exists(FolderPath))
                    System.IO.Directory.CreateDirectory(FolderPath);

                return FolderPath;

            }
            catch (Exception)
            {
                return "";

            }
        }

        public static bool AddJsonPGMConfiguration(string data, string type)
        {
            try
            {
                var jsonData = System.Text.Json.JsonSerializer.Serialize(data);

                string folderPath = CheckOrCreateLogsBaseFolder();
                if (string.IsNullOrWhiteSpace(folderPath)) return false;
                string filepath = @"" + CheckOrCreateLogsBaseFolder() + @"\" + "Web_" + type + ".Json";
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
                if (!File.Exists(filepath))
                {
                    FileStream fs = File.Create(filepath);
                    fs.Close();
                }
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(jsonData);
                    return true;
                }


            }
            catch (Exception)
            {
                return false;

            }
        }


        public static void LogException(string message)
        {
            try
            {
                string folderPath = CheckOrCreateLogsBaseFolder();
                if (string.IsNullOrWhiteSpace(folderPath)) return;


                string filepath = @"" + CheckOrCreateLogsBaseFolder() + @"\" + "Log" + "Exception" + DateTime.Today.ToString("dd-MM-yy") + ".txt";

                if (!File.Exists(filepath))
                {
                    FileStream fs = File.Create(filepath);
                    fs.Close();
                }
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.Write(" ------------------ Exception Logs! ------------------");
                    sw.WriteLine("");
                    sw.Write("Date: " + System.DateTime.Now.ToString());
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("Log Msg: ");
                    sw.WriteLine(message);

                    sw.WriteLine("");
                    sw.Write("Class Name: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType.Name);
                    sw.WriteLine("");
                    sw.Write("Function Name: " + new StackTrace().GetFrame(1).GetMethod());

                    sw.WriteLine("");
                    sw.WriteLine(System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString());
                    sw.WriteLine("");
                }
            }
            catch (Exception ex)
            {

                LogException(ex.Message);
            }
        }
    }
}
