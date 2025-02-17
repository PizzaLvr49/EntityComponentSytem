namespace EntityComponentSystem
{
    class Component(Entity entity)
    {
        public Entity Entity { get; set; } = entity;

        public virtual void Update(double deltaTime, int tick) { }

        public virtual void Start() { }

        public virtual string Serialize()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }

        public static T Deserialize<T>(string json) where T : Component
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(json) ?? throw new InvalidOperationException("Deserialization returned null");
        }
        public void Destroy()
        {
            Entity.Components.Remove(this);
        }

    }
}
