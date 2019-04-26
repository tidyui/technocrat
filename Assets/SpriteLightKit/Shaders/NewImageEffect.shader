// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hidden/NewImageEffect"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_LightsTex ( "Lights (RGB)", 2D ) = "white" {}
		_MultiplicativeFactor ( "Multiplier", float ) = 1.0
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

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _LightsTex;
			float _MultiplicativeFactor;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 main = tex2D(_MainTex, i.uv);
				fixed4 lights = tex2D( _LightsTex, i.uv );

				return _MultiplicativeFactor * main * lights;
			}
			ENDCG
		}
	}
	FallBack "VertexLit"
}
