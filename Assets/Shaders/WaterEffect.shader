Shader "Custom/WaterEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
		_Speed ("Speed", float) = 1
		_Strength ("Strength", float) = 1
		_NoiseScale("Noise Scale", float) = 1
		_NoiseFrequency("Noise Frequency", float) = 1
		_NoiseSpeed("Noise Speed", float) = 1
		_PixelOffset("Pixel Offset", float) = 0.005
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
			#include "noiseSimplex.cginc"
			#define M_PI 3.141592653589

			uniform float _Speed, _Strength, _NoiseScale, _NoiseFrequency, _NoiseSpeed, _PixelOffset;
			float4 _Color;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
				float4 scrPos : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;
				
				float4 worldPos = mul(unity_ObjectToWorld, v.vertex);
				if (v.uv.y == 0)
				{
					float3 pos = float3(o.vertex.x, o.vertex.y, 0) * _NoiseFrequency;
					pos.z += _Time.x * _NoiseSpeed;
					float noise = _NoiseScale * ((snoise(pos) + 1) / 2);
					float y = worldPos.y;
					float x = worldPos.x;
					float disp = cos(y) + cos(x + _Speed * _Time * 100);
					worldPos.y = y + disp * _Strength;
				}
				o.vertex = mul(UNITY_MATRIX_VP, worldPos);//UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.scrPos = ComputeScreenPos(o.vertex);
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
				return _Color;
            }
            ENDCG
        }
    }
}
