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
        }
        override public void Start()
        {
            position = new(120, 100);
        }
    }
}