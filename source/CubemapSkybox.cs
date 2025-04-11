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
using System;
using System.Numerics;
using Textures;
using Worlds;

namespace Skyboxes
{
    public readonly partial struct CubemapSkybox : IEntity
    {
        public CubemapSkybox(World world, Camera camera, CubemapTexture cubemap) :
            this(world, camera, cubemap, new LayerMask(0))
        {
        }

        public CubemapSkybox(World world, Camera camera, CubemapTexture cubemap, LayerMask renderMask)
        {
            rint meshReference = (rint)1;
            rint materialReference = (rint)2;
            this.world = world;
            this.value = world.CreateEntity(new IsRenderer(meshReference, materialReference, renderMask));

            Span<Vector3> positions = stackalloc Vector3[]
            {
                new(-1, 1, -1),
                new(1, 1, -1),
                new(1, -1, -1),
                new(-1, -1, -1),
                new(-1, 1, 1),
                new(1, 1, 1),
                new(1, -1, 1),
                new(-1, -1, 1)
            };

            Span<Vector2> uvs = stackalloc Vector2[]
            {
                new(0, 0),
                new(1, 0),
                new(1, 1),
                new(0, 1)
            };

            Span<uint> indices = stackalloc uint[]
            {
                0, 1, 2, 2, 3, 0,
                1, 5, 6, 6, 2, 1,
                5, 4, 7, 7, 6, 5,
                4, 0, 3, 3, 7, 4,
                3, 2, 6, 6, 7, 3,
                4, 5, 1, 1, 0, 4
            };

            Mesh cubeMesh = new(world, positions, uvs, indices);
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