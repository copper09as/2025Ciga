shader_type canvas_item;

// 可调节参数（修正了参数作用域问题）
uniform bool is_active = true; // 开关控制
uniform float speed: hint_range(0.1, 5.0) = 1.0; // 动画速度
uniform float intensity: hint_range(0.0, 1.0) = 0.5; // 效果强度
uniform vec4 glow_color = vec4(0.2, 0.8, 0.2, 1.0); // 发光颜色（修正为小写）

// 随机噪声函数
float rand(vec2 coord) {
    return fract(sin(dot(coord, vec2(12.9898, 78.233))) * 43758.5453);
}

void fragment() {
    // 获取基础颜色
    vec4 tex_color = texture(TEXTURE, UV);
    float time = TIME * speed; // 将time声明移到外部作用域

    // 如果效果关闭，直接显示原纹理
    if (!is_active) {
        COLOR = tex_color;
    }
	else
	{
		    // 1. 边缘发光效果
    vec2 uv_distorted = UV + vec2(
        sin(time * 2.0 + UV.y * 10.0) * 0.02,
        cos(time * 1.5 + UV.x * 8.0) * 0.01
    ) * intensity;

    float edge_glow = pow(1.0 - min(distance(UV, vec2(0.5)), 0.7), 2.0) * intensity;

    // 2. 颜色闪烁效果
    float flicker = sin(time * 3.0) * 0.1 + 0.9;
    flicker = mix(1.0, flicker, intensity);

    // 3. 随机闪烁点
    float sparkle = rand(UV * 100.0 + floor(time * 5.0)) * intensity;
    sparkle = smoothstep(0.95 - intensity * 0.2, 1.0, sparkle);

    // 组合效果
    vec4 glow = glow_color * (edge_glow * 0.7 + sparkle * 0.8);
    vec4 final_color = mix(tex_color * flicker, glow, intensity * 0.8);

    // 添加轻微扭曲
    vec2 distortion = vec2(
        sin(UV.y * 10.0 + time) * 0.005,
        cos(UV.x * 8.0 + time * 1.2) * 0.003
    ) * intensity;

    final_color = texture(TEXTURE, uv_distorted + distortion) * flicker + glow;

    // 最终颜色输出（修正为直接赋值）
    COLOR = final_color;
	}


}