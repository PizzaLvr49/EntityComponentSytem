namespace EntityComponentSystem
{
    class Component
    {
        public Entity Entity { get; set; }
        public virtual void Update(double DeltaTime, int Tick) { }
        public virtual void Start() { }
    }
}
