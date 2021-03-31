using System;

namespace Engine.Messages {
    internal readonly struct KeyPressedMessage {
        public KeyPressedMessage(ConsoleKeyInfo key) {
            Key = key;
        }

        public ConsoleKeyInfo Key { get; }
    }
}
