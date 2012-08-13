using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTS.Web.Helpers {
    public static class Extensions {

        public static void ForEach<T>(this T[] target, Action<T> action) {
            for (int i = 0; i < target.Length; i++) {
                action(target[i]);
            }
        }

    }
}