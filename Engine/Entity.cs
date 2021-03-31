using Engine.Messages;

namespace Engine.Systems {
    internal abstract class Entity {
        public Entity(MessageBus messageBus) {
            MessageBus = messageBus;
            messageBus.MessageeList.Add(this);
        }

        protected MessageBus MessageBus { get; }

        public virtual void Think() { }
        public virtual void HandleMessage(object message) { }
    }
}
