using System;

namespace Engine {
    internal static partial class Framework {
        public static bool TryGetPendingInput(out ConsoleKeyInfo result) {
            if (Console.KeyAvailable) {
                result = Console.ReadKey(intercept: true);
                return true;
            } else {
                result = default;
                return false;
            }
        }

    }
}
