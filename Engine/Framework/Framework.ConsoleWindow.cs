using System;
using System.Collections.Generic;
using System.Text;

namespace Engine {
    internal static partial class Framework {
        public class ConsoleWindow {
            private ConsoleWindow(Vec2 resolution) {
                Console.CursorVisible = true;

                Resolution = resolution;

                Console.SetWindowSize(Resolution.X, Resolution.Y);
                Console.SetBufferSize(Resolution.X, Resolution.Y);

                matrix = new DrawInfo[Resolution.X, Resolution.Y];
            }

            public static ConsoleWindow Instance => instance ?? throw new InvalidOperationException(
                "Attempt to get instance of the console window while uninitialized");
            private static ConsoleWindow? instance;
            public Vec2 Resolution { get; }
            private readonly DrawInfo[,] matrix;

            public void SetCell(Vec2 pos, DrawInfo drawInfo) {
                matrix[pos.X, pos.Y] = drawInfo;

                Console.SetCursorPosition(pos.X, pos.Y);

                var oldColor = Console.ForegroundColor;
                Console.ForegroundColor = drawInfo.Color;
                Console.Write(drawInfo.Char);
                Console.ForegroundColor = oldColor;
            }

            public DrawInfo GetCell(Vec2 pos) {
                return matrix[pos.X, pos.Y];
            }

            public static void Init(Vec2 resolution) {
                instance ??= new ConsoleWindow(resolution);
            }
        }
    }
}
