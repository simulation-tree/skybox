#version 450

layout(location = 0) in vec3 fragTexCoord;
layout(binding = 1) uniform samplerCube skyboxTexture;

layout(location = 0) out vec4 fragColor;

void main() {
    fragColor = texture(skyboxTexture, fragTexCoord);
}