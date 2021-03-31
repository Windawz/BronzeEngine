namespace Engine.Logging {
    internal class DummyLog : ILog {
        public DummyLog() { }

        public string Label { get => string.Empty; set { } }
        public bool AppendTime { get => false; set { } }

        public void Entry(string format, params object[] args) { }
        public void Dispose() { }
    }
}
