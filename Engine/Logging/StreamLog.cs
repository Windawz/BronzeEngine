
using System;
using System.Globalization;
using System.IO;

namespace Engine.Logging {
    internal abstract class StreamLog : ILog {
        protected StreamLog(TextWriter writer) {
            Writer = writer;
        }

        public string Label { get; set; } = string.Empty;
        public bool AppendTime { get; set; } = true;

        protected TextWriter Writer { get; }

        public void Entry(string format, params object[] args) {
            if (AppendTime) {
                Writer.Write($"[{GetTimeString(DateTime.Now)}]");
                Writer.Write(' ');
            }
            if (!string.IsNullOrWhiteSpace(Label)) {
                Writer.Write($"({Label})");
                Writer.Write(' ');
            }
            Writer.WriteLine(format, args);
            Writer.Flush();
        }
        public void Dispose() {
            Writer.Close();
        }
        protected static string GetTimeString(DateTime time) {
            return time.ToString("hh:mm:ss.ff", CultureInfo.InvariantCulture);
        }
    }
}
