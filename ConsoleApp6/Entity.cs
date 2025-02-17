namespace EntityComponentSystem
{
    class Entity(string Name)
    {
        public int Id { get; private set; }
        public string Name { get; set; } = Name;
        public List<Component> Components { get; set; } = [];

        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in Components)
            {
                if (component.GetType().Equals(typeof(T)))
                {
                    return (T)component;
                }
            }
            return null;
        }
        public void AddComponent<T>(T component) where T : Component
        {
            Components.Add(component);
            component.Entity = this;
        }
    }
}
