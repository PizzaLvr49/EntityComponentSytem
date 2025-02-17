using System.Numerics;

namespace EntityComponentSystem.Components
{
    class Transform : Component
    {
        public Transform()
        {
            TransformSystem.Register(this);
        }
        public Vector2 position = Vector2.Zero;
        public Vector2 scale = Vector2.Zero;
        public float rotation = 0;

        override public void Update(double deltaTime, int Tick)
        {
            if (Tick % 60 == 1)
            {
                Console.Clear();
                Console.WriteLine("FPS: " + Math.Round(1 / deltaTime * 1000));
            }
        }
    }
}