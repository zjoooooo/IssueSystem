using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IssueSystem
{
    class LogClass
    {

        public static void WirteLine(string content)
        {
            string savePath = Application.StartupPath + "\\Log";
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            StreamWriter sw = new StreamWriter(Application.StartupPath+"\\Log\\" +System.DateTime.Now.ToString("yyyyMMdd")+".txt",true);
            sw.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + content);
            sw.Flush();
            sw.Close();
        }

        public static void WirteLogForMovement(string content)
        {
            string savePath = $"{Application.StartupPath}\\log\\MovementTransaction Search\\";
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(savePath + System.DateTime.Now.ToString("yyyy-MM-dd") + ".txt", true);
                sw.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + content);
            }
            catch(IOException e)
            {
                WirteLine($"IO Exception:{e.ToString()}");
            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                }              
            }
            
           
        }

    }
}
