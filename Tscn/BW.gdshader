shader_type canvas_item;

uniform float outline_size = 1.0;
uniform vec4 outline_color : source_color = vec4(1.0, 1.0, 1.0, 1.0);
uniform vec4 fill_color = vec4(0.0, 0.0, 0.0, 1.0);

void fragment() {
    float center_alpha = texture(TEXTURE, UV).a;

    if (center_alpha < 0.1) {
        discard;
    }

    bool is_outline = false;

    for (float x = -outline_size; x <= outline_size; x++) {
        for (float y = -outline_size; y <= outline_size; y++) {
            vec2 offset = vec2(x, y) * TEXTURE_PIXEL_SIZE;
            if (texture(TEXTURE, UV + offset).a < 0.1) {
                is_outline = true;
            }
        }
    }

    COLOR = is_outline ? outline_color : fill_color;
}
