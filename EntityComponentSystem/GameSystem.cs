using EntityComponentSystem.Components;
using System.Diagnostics;

namespace EntityComponentSystem
{
    class GameSystem
    {
        public Scene Scene { get; set; } = new();
        private readonly Stopwatch stopwatch = new();
        public int Tick { get; private set; }
        public double DeltaTime { get; private set; }
        private const int TargetFps = 60;
        private const double FrameTime = 1000 / TargetFps;

        public void Start()
        {
            Tick = 0;
            stopwatch.Start();

            InitializeComponents();

            while (true)
            {
                Update();
                Thread.Sleep((int)(FrameTime - stopwatch.Elapsed.TotalMilliseconds));
            }
        }

        private void InitializeComponents()
        {
            foreach (Entity entity in Scene.Entities)
            {
                foreach (Component component in entity.Components)
                {
                    component.Start();
                }
            }
        }

        private void Update()
        {
            DeltaTime = stopwatch.Elapsed.TotalMilliseconds;
            TransformSystem.Update(DeltaTime, Tick);
            stopwatch.Restart();
            Tick++;
        }
    }

    class BaseSystem<T> where T : Component
    {
        protected static List<T> components = [];

        public static void Register(T component)
        {
            components.Add(component);
        }

        public static void Update(double deltaTime, int tick)
        {
            foreach (T component in components)
            {
                component.Update(deltaTime, tick);
            }
        }
    }

    class TransformSystem : BaseSystem<Transform> { }
}
