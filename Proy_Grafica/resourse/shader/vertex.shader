#version 330 core
layout (location = 0) in vec3 aPosition;
out vec3 vertexPosition;
void main()
{
	vertexPosition = aPosition;
    gl_Position = vec4(0.3*aPosition, 1.0);
}