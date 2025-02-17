using System.Numerics;
using System.Text.Json;

namespace EntityComponentSystem.Components
{
    class Transform : Component
    {
        public Transform(Entity entity) : base(entity)
        {
            TransformSystem.Register(this);
            Initialize();
        }

        private void Initialize()
        {
            Position = new Vector2(120, 100);
        }

        public Vector2 Position { get; set; } = Vector2.Zero;
        public Vector2 Scale { get; set; } = Vector2.One;
        public float Rotation { get; set; } = 0;

        public override void Update(double deltaTime, int tick)
        {
            // Perform only necessary updates
        }

        public override void Start()
        {
            // Initialization logic moved to Initialize method
        }

        public override string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }

        public static Transform Deserialize(string json)
        {
            return JsonSerializer.Deserialize<Transform>(json) ?? throw new InvalidOperationException("Deserialization returned null");
        }

        /// <summary>
        /// Handles position change event.
        /// </summary>
        public static void OnPositionChanged()
        {
            // Handle position change
        }
    }
}
