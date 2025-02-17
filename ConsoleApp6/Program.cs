using EntityComponentSystem.Components;

namespace EntityComponentSystem
{
    internal class Program
    {
        static void Main()
        {
            GameSystem system = new();
            Entity entity = new("test");
            entity.AddComponent(new Transform());
            system.Scene.Entities.Add(entity);
            system.Start();
        }
    }
}
