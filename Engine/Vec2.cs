using System;
using System.Collections.Generic;
using System.Text;

namespace Engine {
    internal readonly struct Vec2 {
        public Vec2(int x, int y) {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public static implicit operator Vec2((int x, int y) tuple) => new Vec2(tuple.x, tuple.y);
    }
}
