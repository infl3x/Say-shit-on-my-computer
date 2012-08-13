using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Speech.Synthesis;
using System.Collections.ObjectModel;
using TTS.Web.Helpers;

namespace TTS.Web {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication {

        public static List<string> InstalledVoices { get; set; }

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Installed voices
            InstalledVoices = new List<string>();
            using (SpeechSynthesizer speaker = new SpeechSynthesizer()) {
                ReadOnlyCollection<InstalledVoice> voices = speaker.GetInstalledVoices();
                foreach (InstalledVoice voice in voices) {
                    InstalledVoices.Add(voice.VoiceInfo.Name);
                }
            }
        }

        public void Application_End() {
            SpeechProcessor.Instance.IsRunning = false;
        }

    }
}