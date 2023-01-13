#version 330 core
in vec3 vertexPosition;
out vec4 FragColor;

void main()
{
    FragColor = vec4(clamp(vertexPosition,0.1f , 1.0f), 1.0f);
}