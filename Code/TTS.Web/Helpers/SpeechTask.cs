using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Speech.Synthesis;

namespace TTS.Web.Helpers {
    public class SpeechTask {

        public string Text { get; set; }
        public string VoiceName { get; set; }
        public int Rate { get; set; }

        public void Run() {
            using (SpeechSynthesizer speaker = new SpeechSynthesizer()) {
                speaker.SelectVoice(VoiceName);
                speaker.Rate = Rate;
                speaker.Speak(Text);
            }
        }

    }
}