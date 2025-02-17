using EntityComponentSystem.Components;

namespace EntityComponentSystem
{
    class Scene
    {
        public Entity Defualt = new(null, "");
        public List<Entity> Entities { get; set; } = [];
        public Entity Find(string Name)
        {
            return Entities.Find(x => x.Name == Name);
        }
        public Entity Instantiate(Entity Parent, string Name)
        {
            ArgumentNullException.ThrowIfNull(Parent);
            Entity entity = new(Parent, Name);
            entity.AddComponent(new Transform());
            Entities.Add(entity);
            return entity;
        }
    }
}
