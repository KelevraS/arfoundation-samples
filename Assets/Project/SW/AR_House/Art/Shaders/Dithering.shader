Shader "Custom/Dithering"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _GlossinessMap ("Glossiness", 2D) = "white" {}
        
        _NormalTex ("Normal", 2D) = "bump" {}
        _Metallic ("Metallic", Range(0,1)) = 0.0
        
        _ClipDistance ("Clipping distance", float) = 0
        
        _NoiseTex ("Noise", 2D) = "bump" {}
        _NoiseScale ("Noise Scale", Vector) = (1,1,0,0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows
        #pragma vertex vert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex, _GlossinessTex, _NormalTex, _NoiseTex;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_NoiseMap;
            float distance;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        float _ClipDistance;
        float2 _NoiseScale;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void vert (inout appdata_full v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input, o)
            float3 worldPos = mul(unity_ObjectToWorld, v.vertex.xyz);
            float noise = tex2Dlod(_NoiseTex, float4(worldPos.xy * _NoiseScale, 0, 0));
            o.distance = distance(mul(unity_ObjectToWorld, v.vertex.xyz), _WorldSpaceCameraPos.xyz) - noise;
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed noise = tex2D (_NoiseTex, IN.uv_NoiseMap);
            clip(IN.distance - _ClipDistance);
            
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            fixed g = tex2D (_GlossinessTex, IN.uv_MainTex);
            fixed3 n = tex2D (_NormalTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Normal = n;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness * g;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
