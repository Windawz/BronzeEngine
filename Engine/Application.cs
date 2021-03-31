using Engine.Systems;

using System.Collections.Generic;

namespace Engine {
    public class Application {
        public Application() {
            messageBus = new MessageBus();

            Framework.ConsoleWindow.Init(new Vec2(80, 24));

            entities.Add(new InputSystem(messageBus));
            entities.Add(new ConsoleSystem(messageBus, Framework.ConsoleWindow.Instance));
            entities.Add(new DrawSystem(messageBus, Framework.ConsoleWindow.Instance));
        }

        private readonly MessageBus messageBus = new MessageBus();
        private readonly List<Entity> entities = new List<Entity>();

        public void Run() {
            while (true) {
                foreach (Entity system in entities) {
                    system.Think();
                }
                messageBus.FlushMessages();
            }
        }
    }
}
