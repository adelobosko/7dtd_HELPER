using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _7dtd_HELP
{ 
    public class FineReaderService
    {
        private readonly string _fineReaderExePath;
        private readonly string _language;
        private readonly string _send;

        public FineReaderService(string fineReaderDirectory, string language = "english", string send = "Clipboard")
        {
            _fineReaderExePath = Path.Combine(fineReaderDirectory, "FineOCR.exe");
            _language = language;
            _send = send;
        }

        /// <summary>
        /// Read text from the images streams.
        /// </summary>
        /// <param name="image">The image</param>
        /// <returns>The images text.</returns>
        public string GetText(Image image)
        {
            var output = string.Empty;
            if (image == null) return output;

            var tempInputFile = NewTempFileName(Path.GetTempPath());
            try
            {
                image.Save(tempInputFile);
                var info = new ProcessStartInfo
                {
                    FileName = _fineReaderExePath,
                    Arguments = $"{tempInputFile} /lang {_language} /send {_send}",
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                using (var ps = Process.Start(info))
                {
                    ps.WaitForExit();
                    var exitCode = ps.ExitCode;
                    if (exitCode == 0)
                    {
                        output = Clipboard.GetText();
                    }
                    else
                    {
                        var stderr = ps.StandardError.ReadToEnd();
                        throw new InvalidOperationException(stderr);
                    }
                }
            }
            finally
            {
                File.Delete(tempInputFile);
            }

            return output;
        }
        public string GetText(string imagePath)
        {
            var output = string.Empty;
            if (imagePath == "") return output;

            var tempInputFile = NewTempFileName(Path.GetTempPath());
            try
            {
                var info = new ProcessStartInfo
                {
                    FileName = _fineReaderExePath,
                    Arguments = $"{imagePath} /lang {_language} /send {_send}",
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                using (var ps = Process.Start(info))
                {
                    if (ps != null)
                    {
                        ps.WaitForExit();
                        var exitCode = ps.ExitCode;
                        if (exitCode == 0)
                        {
                            output = Clipboard.GetText();
                        }
                        else
                        {
                            var stderr = ps.StandardError.ReadToEnd();
                            throw new InvalidOperationException(stderr);
                        }
                    }
                }
            }
            finally
            {
            }

            return output;
        }

        private static string NewTempFileName(string tempPath)
        {
            return Path.Combine(tempPath, Guid.NewGuid().ToString());
        }
    }
}