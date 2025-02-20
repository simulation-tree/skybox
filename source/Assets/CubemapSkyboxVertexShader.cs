using Data;

namespace Shaders.Assets
{
    public readonly struct CubemapSkyboxVertexShader : IEmbeddedResource
    {
        readonly Address IEmbeddedResource.Address => "Assets/CubemapSkybox.vertex.glsl";
    }
}