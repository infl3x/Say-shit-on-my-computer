using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Net;
using System.Media;
using System.IO;
using Alvas.Audio;
using System.Speech.Synthesis;

namespace TTS.Web.Helpers {
    public enum SpeechStatus {
        Speaking,
        Done
    }

    public class SpeechProcessor {

        public bool IsRunning { get; set; }

        public Queue<SpeechTask> SpeechQueue { get; set; }

        private static SpeechProcessor instance;
        public static SpeechProcessor Instance {
            get {
                if (instance == null) {
                    instance = new SpeechProcessor() {
                        SpeechQueue = new Queue<SpeechTask>()
                    };

                    instance.Start();
                }

                return instance;
            }
        }

        private void Start() {
            IsRunning = true;

            (new Thread(t => {
                while (IsRunning) {
                    Thread.Sleep(100);
                    
                    lock (SpeechQueue) {
                        while (SpeechQueue.Count > 0) {
                            SpeechTask task = SpeechQueue.Dequeue();
                            task.Run();
                        }
                    }
                }
            })).Start();
        }

        public int EnqueueSpeech(string text, string voiceName, int speechRate) {
            lock (SpeechQueue) {
                SpeechTask task = new SpeechTask() {
                    Text = text,
                    VoiceName = voiceName,
                    Rate = speechRate
                };

                SpeechQueue.Enqueue(task);

                return task.GetHashCode();
            }
        }

        public SpeechStatus GetStatus(int hashCode) {
            lock (SpeechQueue) {
                foreach (SpeechTask task in SpeechQueue) {
                    if (task.GetHashCode() == hashCode)
                        return SpeechStatus.Speaking;
                }
            }

            return SpeechStatus.Done;
        }

    }
}