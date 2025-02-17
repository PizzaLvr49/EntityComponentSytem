using EntityComponentSystem.Components;

namespace EntityComponentSystem
{
    internal class Program
    {
        static void Main()
        {
            GameSystem system = new();
            Scene scene = system.Scene;
            Entity entity = scene.Instantiate(system.Scene.Defualt, "test");
            new Task(system.Start).Start();
            if (Console.ReadKey().KeyChar.ToString() == "q")
            {
                entity.AddComponent(new Transform());
                Console.WriteLine(scene.Find("test").GetComponent<Transform>().position);
                entity.GetComponent<Transform>().position = new(120, 10);
                Console.WriteLine(scene.Find("test").GetComponent<Transform>().position);
            }
        }
    }
}
