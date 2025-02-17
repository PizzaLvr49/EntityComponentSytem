using EntityComponentSystem.Components;

namespace EntityComponentSystem
{
    internal class Program
    {
        static void Main()
        {
            GameSystem system = new();
            Scene scene = system.Scene;
            Entity entity = scene.Instantiate(system.Scene.Default, "test");
            new Task(system.Start).Start();
            if (Console.ReadKey().KeyChar.ToString() == "q")
            {
                Console.WriteLine(scene.Find("test").GetComponent<Transform>().Position);
                entity.GetComponent<Transform>().Position = new(120, 10);
                Console.WriteLine(scene.Find("test").GetComponent<Transform>().Position);
            }
        }
    }
}
