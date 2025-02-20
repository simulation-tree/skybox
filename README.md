# Skybox

Abstraction for skyboxes.

### Simple cubemap

Below is an example of creating a skybox from 6 textures, that uses
a built-in cubemap skybox shader drawing in the background:
```cs
using World world = new();
Texture right = new(world, "Assets/Sunny Skybox/right.jpg");
Texture left = new(world, "Assets/Sunny Skybox/left.jpg");
Texture top = new(world, "Assets/Sunny Skybox/top.jpg");
Texture bottom = new(world, "Assets/Sunny Skybox/bottom.jpg");
Texture front = new(world, "Assets/Sunny Skybox/front.jpg");
Texture back = new(world, "Assets/Sunny Skybox/back.jpg");
CubemapTexture cubemap = new(world, right, left, top, bottom, front, back);
Skybox skybox = new CubemapSkybox(world, camera, cubemap);
```