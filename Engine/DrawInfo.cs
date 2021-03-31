using System;
using System.Collections.Generic;
using System.Text;

namespace Engine {
    internal readonly struct DrawInfo {
        public DrawInfo(char c, ConsoleColor color = ConsoleColor.Gray) {
            Char = c;
            Color = color;
        }

        public char Char { get; }
        public ConsoleColor Color { get; }
    }
}
