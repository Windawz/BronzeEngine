
using System;

namespace Engine.Logging {
    internal interface ILog : IDisposable {
        string Label { get; set; }
        bool AppendTime { get; set; }

        void Entry(string format, params object[] args);
    }
}
