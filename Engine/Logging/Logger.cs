namespace Engine.Logging {
    internal class Logger {
        private const int LogCount = 3;

        public enum Index {
            Out,
            Err,
            Dbg
        }

        public Logger() {
            for (int i = 0; i < LogCount; i++) {
                logs[i] = new DummyLog();
            }
        }

        public ILog Out {
            get => this[Index.Out];
            set => this[Index.Out] = value;
        }
        public ILog Err {
            get => this[Index.Err];
            set => this[Index.Err] = value;
        }
        public ILog Dbg {
            get => this[Index.Dbg];
            set => this[Index.Dbg] = value;
        }

        private readonly ILog[] logs = new ILog[LogCount];

        public ILog this[Index index] {
            get => logs[(int)index];
            set => logs[(int)index] = value;
        }
    }
}
