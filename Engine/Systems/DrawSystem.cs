using System;
using System.Collections.Generic;

using Engine.Messages;

namespace Engine.Systems {
    internal class DrawSystem : WindowedSystem {
        public DrawSystem(MessageBus messageBus, Framework.ConsoleWindow window) : base(messageBus, window) {
        }

        private readonly Queue<(Vec2 pos, DrawInfo drawInfo)> drawQueue =
            new Queue<(Vec2, DrawInfo)>();

        public override void Think() {
            while (drawQueue.TryDequeue(out var result)) {
                var window = Framework.ConsoleWindow.Instance;
                window.SetCell(result.pos, result.drawInfo);
            }
        }
        public override void HandleMessage(object message) {
            if (message is DrawMessage msg) {
                drawQueue.Enqueue((msg.Pos, msg.DrawInfo));
            }
        }
    }
}
