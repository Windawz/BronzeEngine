using Engine.Systems;
using Engine.Messages;

using System.Collections.Generic;

namespace Engine {
    internal class MessageBus {
        public MessageBus() { }

        public HashSet<Entity> MessageeList { get; } = new HashSet<Entity>();
        private readonly Queue<object> messageQueue = new Queue<object>();

        public void FlushMessages() {
            while (messageQueue.TryDequeue(out object? message)) {
                foreach (var messagee in MessageeList) {
                    messagee.HandleMessage(message);
                }
            }
        }

        public void PostMessage(object message) {
            messageQueue.Enqueue(message);
        }
    }
}
