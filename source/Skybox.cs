using Rendering.Components;
using Skyboxes.Components;
using Worlds;

namespace Skyboxes
{
    public readonly partial struct Skybox : IEntity
    {
        readonly void IEntity.Describe(ref Archetype archetype)
        {
            archetype.AddComponentType<IsRenderer>();
            archetype.AddTagType<IsSkybox>();
        }
    }
}