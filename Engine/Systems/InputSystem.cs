using Engine.Messages;

using System;

namespace Engine.Systems {
    internal class InputSystem : Entity {
        public InputSystem(MessageBus messageBus) : base(messageBus) { }

        public override void Think() {
            if (Framework.TryGetPendingInput(out ConsoleKeyInfo key)) {
                var message = new KeyPressedMessage(key);
                MessageBus.PostMessage(message);
            }
        }
    }
}
