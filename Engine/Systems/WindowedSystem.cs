using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Systems {
    internal abstract class WindowedSystem : Entity {
        public WindowedSystem(MessageBus messageBus, Framework.ConsoleWindow window) : base(messageBus) {
            Window = window;
        }

        protected Framework.ConsoleWindow Window { get; }
    }
}
