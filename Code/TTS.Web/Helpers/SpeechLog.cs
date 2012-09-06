using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace TTS.Web.Helpers {
    public class SpeechLog {

        public const string LOG_PATH = @"/Data/requests.txt";

        private string basePath;
        private static SpeechLog instance;

        public static SpeechLog Instance(string basePath) {
            if (instance == null)
                instance = new SpeechLog();

            instance.basePath = basePath;

            return instance;
        }

        public void LogRequest(string speechText, string ipAddress) {
            lock (instance) {
                try {
                    using (StreamWriter writer = File.AppendText(basePath + LOG_PATH)) {
                        writer.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " (" + ipAddress + ") - '" + speechText + "'");
                    }
                } catch { /* Don't care */ }
            }
        }

        public List<string> ReadLog() {
            lock (instance) {
                List<string> logData = new List<string>();

                try {
                    using (StreamReader reader = new StreamReader(basePath + LOG_PATH)) {
                        string logEntry = null;
                        while((logEntry = reader.ReadLine()) != null) {
                            logData.Add(logEntry);
                        }
                    }
                } catch { /* Don't care */ }

                logData.Reverse();
                logData = logData.Take(Properties.Settings.Default.MaxLogItems).ToList();
                
                return logData;
            }
        }

    }
}
