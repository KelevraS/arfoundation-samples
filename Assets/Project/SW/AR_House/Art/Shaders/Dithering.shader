Shader "Custom/Dithering"
{
    Properties
    {
        [Header(Albedo)]
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        
        [Header(PBR)]
        _NormalTex ("Normal", 2D) = "bump" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _GlossinessMap ("Glossiness", 2D) = "white" {}
        _Metallic ("Metallic", Range(0,1)) = 0.0
             
        [Header(Dithering)]
        _DitheringTex ("Dithering", 2D) = "bump" {}
        _MinDistance ("Minimum Fade Distance", Float) = 0
        _MaxDistance ("Maximum Fade Distance", Float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        #pragma target 3.0

        sampler2D _MainTex, _GlossinessTex, _NormalTex, _DitheringTex;
        float4 _DitheringTex_ST;

        struct Input
        {
            float2 uv_MainTex;
            float4 screenPos;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        float _MinDistance;
        float _MaxDistance;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            
            o.Normal = tex2D (_NormalTex, IN.uv_MainTex);
            
            fixed g = tex2D (_GlossinessTex, IN.uv_MainTex);
            o.Smoothness = _Glossiness * g;
            
            o.Metallic = _Metallic;
            
            o.Alpha = c.a;
            
            float2 screenPos = IN.screenPos.xy / IN.screenPos.w;
            screenPos *= _DitheringTex_ST;
            float dithering = tex2D(_DitheringTex, screenPos);
            float relDistance = IN.screenPos.w;
            relDistance -= _MinDistance;
            relDistance = relDistance / (_MaxDistance - _MinDistance);

            clip(relDistance - dithering);
            
        }
        ENDCG
    }
    FallBack "Diffuse"
}
