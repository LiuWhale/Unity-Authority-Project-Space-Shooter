//参考：www.cnblog.com/allyh/p/9090787.html
Shader "Unlit/Scroll"
{
	Properties
	{
		_MainTex ("Base Layer(RGB)", 2D) = "white" {} //纹理
		_ScrollZ("Base Layer Scroll Speed",Float) = 1.0 //滚动速度
		_Multiplier("Layer Multiplier",Float) = 1//整体亮度
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			Tags { "LightMode"="ForwardBase" }
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			//fix
			float _ScrollZ;
			float _Multiplier;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				/*o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);*/
				o.uv.xy =TRANSFORM_TEX(v.uv,_MainTex) + frac(float2 (0.0,_ScrollZ)*_Time.z);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv.xy);
				// apply fog
				//UNITY_APPLY_FOG(i.fogCoord, col);
				col.rgb *= _Multiplier;	
				return col;
			}
			ENDCG
		}
	}
		FallBack "VertexLit"
}
