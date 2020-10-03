Shader "Custom/2D/Circle"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Radius("Radius px", Float) = 50
		_Width("Width px", Float) = 100
		_Height("Height px", Float) = 100

		// required for UI.Mask
		[HideInInspector]  _StencilComp("Stencil Comparison", Float) = 8
		[HideInInspector]  _Stencil("Stencil ID", Float) = 0
		[HideInInspector]  _StencilOp("Stencil Operation", Float) = 0
		[HideInInspector]  _StencilWriteMask("Stencil Write Mask", Float) = 255
		[HideInInspector]  _StencilReadMask("Stencil Read Mask", Float) = 255
		[HideInInspector]  _ColorMask("Color Mask", Float) = 15
	}

	SubShader {
		Tags {
			"RenderType" = "Transparent"
			"Queue" = "Transparent"
		}

		// required for UI.Mask
			Stencil
			{
				Ref[_Stencil]
				Comp[_StencilComp]
				Pass[_StencilOp]
				ReadMask[_StencilReadMask]
				WriteMask[_StencilWriteMask]
			}


			Cull Off
			Lighting Off
			ZTest[unity_GUIZTestMode]

		// Alpha blending.
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha

			Pass {
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				struct appdata {
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
					float4 color : COLOR;
				};

				struct v2f {
					float2 uv : TEXCOORD0;
					float4 vertex : SV_POSITION;
					float4 color : COLOR;
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;
				float _Radius;
				float _Width;
				float _Height;

				v2f vert(appdata v) {
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.uv, _MainTex);
					o.color = v.color;
					return o;
				}

				fixed4 frag(v2f i) : SV_Target {
					// UV -> rectangular coordinate system -> multiply pixel width, height
					float2 uvInPixelCoord = (i.uv - 0.5) * float2(_Width, _Height);

					float pixelDistance = length(uvInPixelCoord) / _Radius;
					float alpha = 1.0 - saturate(floor(pixelDistance));

					fixed4 col = tex2D(_MainTex, i.uv) * i.color;
					col.a = alpha;
					return col;
				}
				ENDCG
			}
	}
}