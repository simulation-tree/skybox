using Data;

namespace Skyboxes.Assets
{
    public readonly struct CubemapSkyboxFragmentShader : IEmbeddedResource
    {
        readonly Address IEmbeddedResource.Address => "Assets/CubemapSkybox.fragment.glsl";
    }
}