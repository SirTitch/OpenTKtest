#version 450 core
in vec4 vs_colour;
out vec4 colour;

void main(void)
{
 colour = vs_colour;
}