using Rendering.Components;
using Shaders.Components;
using Worlds;

namespace Shaders
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