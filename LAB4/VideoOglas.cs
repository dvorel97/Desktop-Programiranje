using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LAB4
{
    public class VideoOglas : Oglas
    {
        private string video;
        public VideoOglas(string naslov, string opis, string autor, string video)
        : base(naslov, opis, autor)
        {
            if (!video.EndsWith(".mp4"))
                throw new Exception(
                    "URL videa mora završavati s .mp4!");
            this.video = video;
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"Video: {video}";
        }
    }
}
