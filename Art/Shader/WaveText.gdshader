shader_type canvas_item;

uniform float height=10.0;
uniform float speed=5.0;
uniform float frequency=10.0;

void vertex() {
	VERTEX.y+=height * sin(frequency * UV.x + speed * TIME);
}

