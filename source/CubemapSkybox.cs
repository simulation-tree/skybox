using Cameras;
using Cameras.Components;
using Data;
using Materials;
using Meshes;
using Rendering;
using Rendering.Components;
using Shaders;
using Skyboxes.Assets;
using Skyboxes.Components;
using Textures;
using Worlds;

namespace Skyboxes
{
    public readonly partial struct CubemapSkybox : IEntity
    {
        public CubemapSkybox(World world, Camera camera, CubemapTexture cubemap) : this(world, camera, cubemap, new LayerMask(1))
        {
        }

        public CubemapSkybox(World world, Camera camera, CubemapTexture cubemap, LayerMask renderMask)
        {
            rint meshReference = (rint)1;
            rint materialReference = (rint)2;
            this.world = world;
            this.value = world.CreateEntity(new IsRenderer(meshReference, materialReference, renderMask));

            Mesh cubeMesh = Mesh.CreateCube(world);
            AddReference(cubeMesh);

            Shader vertexShader = new(world, EmbeddedResource.GetAddress<CubemapSkyboxVertexShader>(), ShaderType.Vertex);
            Shader fragmentShader = new(world, EmbeddedResource.GetAddress<CubemapSkyboxFragmentShader>(), ShaderType.Fragment);
            Material material = new(world, vertexShader, fragmentShader);
            material.AddComponentBinding<CameraMatrices>(new(0, 0), camera);
            material.AddTextureBinding(new(1, 0), cubemap);
            AddReference(material);
        }

        readonly void IEntity.Describe(ref Archetype archetype)
        {
            archetype.AddComponentType<IsRenderer>();
            archetype.AddTagType<IsSkybox>();
        }
    }
}