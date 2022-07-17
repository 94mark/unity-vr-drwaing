Shader "customize/SphericalMask" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_ColorStrength("Color Strength", Range(1,4)) = 1

		_EmissionColor("Emission Color", Color) = (1,1,1,1)
		_EmissionTex("Emission (RGB)", 2D) = "white" {}
		_EmissionStrength("Emission Strength", Range(0,10)) = 1

		_Position("World Position", Vector) = (0,0,0,0)
		_Radius("Sphere Radius", Range(0,100)) = 0
		_Softness("Sphere Softness", Range(0,100)) = 0
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows
			#pragma target 3.0

			sampler2D _MainTex;
			sampler2D _EmissionTex;

			struct Input {
				float2 uv_MainTex;
				float2 uv_EmissionTex;
				float3 worldPos;
			};

			fixed4 _Color, _EmissionColor;
			half _ColorStrength, _EmissionStrength;

			// Spherical Mask
			uniform float4 GLOBALmask_Position;
			uniform half GLOBALmask_Radius;
			uniform half GLOBALmask_Softness;

			void surf(Input IN, inout SurfaceOutputStandard o) {
				// Color
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;

				// Grayscale
				float grayscale = (c.r + c.g + c.b) * 0.333;
				fixed3 c_g = fixed3(grayscale, grayscale, grayscale);

				// Emission
				fixed4 e = tex2D(_EmissionTex, IN.uv_EmissionTex) * _EmissionColor * _EmissionStrength;

				half d = distance(GLOBALmask_Position, IN.worldPos);
				half sum = saturate((d - GLOBALmask_Radius) / -GLOBALmask_Softness);
				fixed4 lerpColor = lerp(fixed4(c_g,1), c * _ColorStrength, sum);
				fixed4 lerpEmission = lerp(fixed4(0,0,0,0), e, sum);

				o.Albedo = lerpColor.rgb;
				o.Emission = lerpEmission.rgb;
				o.Alpha = c.a;
			}
			ENDCG
		}
			FallBack "Diffuse"
}