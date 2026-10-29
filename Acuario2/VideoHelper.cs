using System;
using System.IO;
using System.Windows.Forms;

namespace Acuario2
{
    internal static class VideoHelper
    {
        public static string RutaVideo()
        {
            string local = Path.Combine(Application.StartupPath, "V1.mp4");
            if (File.Exists(local)) return local;

            string dir = Application.StartupPath;
            for (int i = 0; i < 6 && !string.IsNullOrEmpty(dir); i++)
            {
                string candidato = Path.Combine(dir, "V1.mp4");
                if (File.Exists(candidato)) return candidato;
                dir = Path.GetDirectoryName(dir);
            }
            return local;
        }
    }
}
