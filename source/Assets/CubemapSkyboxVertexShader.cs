using Data;

namespace Skyboxes.Assets
{
    public readonly struct CubemapSkyboxVertexShader : IEmbeddedResource
    {
        readonly Address IEmbeddedResource.Address => "Assets/CubemapSkybox.vertex.glsl";
    }
}