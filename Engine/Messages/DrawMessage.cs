using System;

namespace Engine.Messages {
    internal readonly struct DrawMessage {
        public DrawMessage(Vec2 pos, DrawInfo drawInfo) {
            Pos = pos;
            DrawInfo = drawInfo;
        }

        public Vec2 Pos { get; }
        public DrawInfo DrawInfo { get; }
    }
}
