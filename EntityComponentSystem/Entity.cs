namespace EntityComponentSystem
{
    class Entity
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public List<Component> Components { get; set; } = [];
        public Entity Parent { get; set; }

        public Entity(Entity Parent, string Name)
        {
            this.Name = Name;
            this.Parent = Parent ?? this;
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in Components)
            {
                if (component.GetType().Equals(typeof(T)))
                {
                    return (T)component;
                }
            }
            throw new Exception($"Entity does not have component '{typeof(T).Name}'");
        }
        public void AddComponent<T>(T component) where T : Component
        {
            if (Components.OfType<T>().Any()) throw new Exception($"Entity already has component '{typeof(T).Name}'");
            Components.Add(component);
            component.Entity = this;
        }
    }
}
