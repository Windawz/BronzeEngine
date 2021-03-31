using System;

using Engine.Messages;

namespace Engine.Systems {
    internal class ConsoleSystem : WindowedSystem {
        private const char NullChar = '\0';
        private const char BackspaceChar = '\b';

        private class Cursor {
            public Cursor(Vec2 bounds) {
                this.bounds = bounds;
            }

            public Vec2 Pos { get; private set; } = (0, 0);
            public bool StartOfLineReached => Pos.X - 1 < 0;
            public bool EndOfLineReached => Pos.X + 1 >= bounds.X;
            public bool UpperBoundReached => (Pos.X - 1 < 0) && (Pos.Y - 1 < 0);
            public bool LowerBoundReached => (Pos.X + 1 >= bounds.X) && (Pos.Y + 1 >= bounds.Y);
            private readonly Vec2 bounds;

            public void Advance() {
                if (!EndOfLineReached) {
                    Pos = (Pos.X + 1, Pos.Y);
                } else if (!LowerBoundReached) {
                    Pos = (0, Pos.Y + 1);
                }
            }
            public void Retract() {
                if (!StartOfLineReached) {
                    Pos = (Pos.X - 1, Pos.Y);
                } else if (!UpperBoundReached) {
                    Pos = (0, Pos.Y - 1);
                }
            }
        }

        public ConsoleSystem(MessageBus messageBus, Framework.ConsoleWindow window) : base(messageBus, window) {
            matrix = new char[Window.Resolution.X, Window.Resolution.Y];
            cursor = new Cursor(Window.Resolution);
        }

        private readonly char[,] matrix;
        private readonly Cursor cursor;

        public override void Think() {
            /*char c = default;
            for (int j = 0, y = 0; j < matrix.GetLength(1); j++) {
                for (int i = 0, x = 0; i < matrix.GetLength(0); i++) {
                    c = matrix[i, j];
                    if (c != NullChar) {
                        var msg = new DrawMessage((x, y), new DrawInfo(c));
                        MessageBus.PostMessage(msg);
                        x++;
                    }
                }
                if (c != NullChar) {
                    y++;
                }
            }*/
        }
        public override void HandleMessage(object message) {
            if (message is KeyPressedMessage msg) {
                char c = msg.Key.KeyChar;

                if (c == BackspaceChar) {
                    cursor.Retract();
                }
                var drawMsg = new DrawMessage((cursor.Pos.X, cursor.Pos.Y), new DrawInfo(c));
                MessageBus.PostMessage(drawMsg);
                //matrix[cursor.Pos.X, cursor.Pos.Y] = c;
                if (c != BackspaceChar) {
                    cursor.Advance();
                }
            }
        }
    }
}
