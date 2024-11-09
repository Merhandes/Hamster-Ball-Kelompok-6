Shader "Custom/WaterShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" { }
        _WaveSpeed ("Wave Speed", Float) = 0.3
        _WaveHeight ("Wave Height", Float) = 0.2
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : POSITION;
            };

            float _WaveSpeed;
            float _WaveHeight;

            v2f vert(appdata v)
            {
                v2f o;
                float wave = sin(v.vertex.x * 0.1 + _Time * _WaveSpeed) * _WaveHeight;
                v.vertex.y += wave;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                return half4(32.0 / 255.0, 178.0 / 255.0, 170.0 / 255.0, 1.0); // Warna biru untuk air
            }
            ENDCG
        }
    }
}
