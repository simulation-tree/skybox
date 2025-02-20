#version 450

layout(location = 0) in vec3 inPosition;

layout(binding = 0) uniform CameraInfo {
	mat4 proj;
    mat4 view;
} cameraInfo;

layout(location = 0) out vec3 fragTexCoord;

void main() {
    mat4 viewNoTranslation = mat4(mat3(cameraInfo.view));

    fragTexCoord = inPosition;  
    gl_Position = cameraInfo.proj * viewNoTranslation * vec4(inPosition, 1.0);
    gl_Position = gl_Position.xyww; // Force depth to 1.0
}