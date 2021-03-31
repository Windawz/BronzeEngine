
using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Engine.Logging {
    internal class FileLog : StreamLog {
        public FileLog(string logDirectory) : base(CreateLogFile(logDirectory)) { }

        protected static string GetFileNameTimeString(DateTime time) {
            return time.ToString("dd-MM-yyyy_hh'h'mm'm'ss's'", CultureInfo.InvariantCulture);
        }
        private static string GetName() {
            return $"Log_({GetFileNameTimeString(DateTime.Now)}).txt";
        }
        private static TextWriter CreateLogFile(string logDirectory) {
            if (!Path.EndsInDirectorySeparator(logDirectory)) {
                logDirectory += Path.DirectorySeparatorChar;
            }
            Directory.CreateDirectory(logDirectory);

            var stream = new FileStream(logDirectory + GetName(), FileMode.Create, FileAccess.Write);
            var writer = new StreamWriter(stream, Encoding.UTF8, 512, false);

            return writer;
        }
    }
}
