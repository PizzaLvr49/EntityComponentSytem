using EntityComponentSystem.Components;

namespace EntityComponentSystem
{
    class Scene
    {
        public Entity Default;
        public List<Entity> Entities { get; set; } = [];
        public Entity Find(string Name)
        {
            return Entities.Find(x => x.Name == Name) ?? throw new Exception($"Entity '{Name}' not found");
        }
        public Scene()
        {
            Default = new Entity(null, "Default", this);
        }
        public Entity Instantiate(Entity Parent, string Name)
        {
            ArgumentNullException.ThrowIfNull(Parent);
            Entity entity = new(Parent, Name, this);
            entity.AddComponent(new Transform(entity));
            Entities.Add(entity);
            return entity;
        }
    }
}
