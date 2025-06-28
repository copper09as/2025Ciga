shader_type canvas_item;

uniform vec3 color = vec3(0.33, 0.15, 0.82);
uniform int OCTAVES = 4;

float rand(vec2 coord) {
    return fract(sin(dot(coord, vec2(56.0, 78.0))) * 100.0);
}

float noise(vec2 coord) {
    vec2 i = floor(coord);
    vec2 f = fract(coord);
    
    float a = rand(i);
    float b = rand(i + vec2(1.0, 0.0));
    float c = rand(i + vec2(0.0, 1.0));
    float d = rand(i + vec2(1.0, 1.0));
    
    vec2 cubic = f * f * (3.0 - 2.0 * f);
    
    return mix(a, b, cubic.x) + (c - a) * cubic.y * (1.0 - cubic.x) + (d - b) * cubic.x * cubic.y;
}

float fbm(vec2 coord) {
    float value = 0.0;
    float scale = 0.5;
    
    for (int i = 0; i < OCTAVES; i++) {
        value += noise(coord) * scale;
        coord *= 2.0;
        scale *= 0.5;
    }
    return value;
}

void fragment() {
    vec2 coord = UV * 5.0; // 控制纹理密度，调节这个值可以看到不同效果
    float n = fbm(coord + vec2(TIME * 0.1, 0.0)); // 加入时间产生动态变化（可选）
    float alpha = smoothstep(0.5, 0.8, n); // 透明度渐变
    COLOR = vec4(color * n, alpha);
}
