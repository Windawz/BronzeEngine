
using System;
using System.IO;

namespace Engine.Logging {
    internal class ConsoleLog : StreamLog {
        public enum OutputLocation {
            StdOutput,
            StdError,
        }

        public ConsoleLog(OutputLocation location) : base(GetOutputLocation(location)) { }

        private static TextWriter GetOutputLocation(OutputLocation location) {
            switch (location) {
                case OutputLocation.StdOutput:
                    return Console.Out;
                case OutputLocation.StdError:
                    return Console.Error;
                default:
                    throw new ArgumentException($"Invalid location {location}", nameof(location));
            }
        }
    }
}
