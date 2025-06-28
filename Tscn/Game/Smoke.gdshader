shader_type canvas_item;

uniform vec3 color=vec3(1.0,1.0,1.0);

float rand(vec2 coord)
{
	return fract(sin(dot(coord,vec2(56,78))*1000.0)*1000.0);	
}

float noise(vec2 coord)
{
	vec2 i=fract(coord);
	vec2 f=fract(coord);
	
	float a=rand(i);
	float b=rand(i+vec2(1.0,0.0));
	float c=rand(i+vec2(0.0,1.0));
	float d=rand(i+vec2(1.0,1.0));
	
	vec2 cubic=f*f*(3.0-2.0*f);
	
	return mix(a,b,cubic.x)+(c-a)*cubic.y*(1.0-cubic.x)+(d-b)*cubic.x*cubic.y;
}

void vertex() 
{
	
}

void fragment() {
	vec2 coord=UV*20.0;
	COLOR=vec4(color,noise(coord));	
}

//void light() {
//	// Called for every pixel for every light affecting the CanvasItem.
//	// Uncomment to replace the default light processing function with this one.
//}
