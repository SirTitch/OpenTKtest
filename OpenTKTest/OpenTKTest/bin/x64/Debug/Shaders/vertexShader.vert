#version 450 core

layout (location = 0) in vec3 position;
layout(location = 1) in vec4 colour;
layout(location = 2) in vec3 normal;

out vec4 vs_colour;

layout(location = 20) uniform  mat4 projection;
layout (location = 26) uniform  mat4 modelView;
layout (location = 27) uniform uint colourmode;

vec4 ambient =vec4(0.2, 0.2, 0.2, 1.0);
 //vec3 position3 = position.xyz;
void main(void)
{
	vec3 light_dir = vec3(0, 0, 4.0);			// Define a light direction

	vec4 diffuse_colour;
	vec4 position_h = vec4(position, 1.0);
	
	if (colourmode == 1)
		diffuse_colour = colour;
	else
		diffuse_colour = vec4(0.0, 1.0, 0, 1.0);

	vec4 ambient = diffuse_colour * 0.2;			// Define ambient as a darker version of the vertex colour

	// calculate diffuse lighting
				
	mat3 n_matrix = transpose(inverse(mat3(modelView)));  // It's more efficient to calculate this in your application
	vec3 N = normalize(n_matrix * normal);			// Be careful with the order of multiplication!
	vec3 L = normalize(light_dir);					// Ensure light_dir is unit length
	vec4 diffuse = max(dot(L, N), 0) * diffuse_colour;

	// Calculate specular lighting
	vec4 specular_colour = vec4(1.0, 1.0, 0.6, 1.0);	// Bright yellow light
	float shininess = 20;							// smaller values give sharper specular responses, larger more spread out
	vec4 P = modelView * position_h;				// Calculate vertex position in eye space
	vec3 V = normalize(-P.xyz);						// Viewing vector is reverse of vertex position in eye space
	vec3 S = normalize(V + L);						// Calculate the Blinn-Phong half-vector
	vec4 specular = pow(max(dot(S, N), 0), shininess) * specular_colour;	// Calculate specular component

	
	// Define the vertex colour by summing the sperate lighting components
 vs_colour = ambient + diffuse + specular;			
 gl_Position = (projection * modelView)*position_h;
 
}