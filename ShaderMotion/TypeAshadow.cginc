#ifndef TYPEA_SHADOW_INCLUDED
#define TYPEA_SHADOW_INCLUDED

#include "UnityCG.cginc"
#include "UnityStandardUtils.cginc"

#include "TypeA2Config.cginc"

#include "TypeA2Function.cginc"

#ifdef SHADERMOTION_ON
#include "MeshPlayer.hlsl"

UNITY_INSTANCING_BUFFER_START(Props)
UNITY_DEFINE_INSTANCED_PROP(float, _Layer)
UNITY_INSTANCING_BUFFER_END(Props)
#endif

#if (SHADER_TARGET < 30) || defined(SHADER_API_GLES) || defined(SHADER_API_D3D11_9X) || defined (SHADER_API_PSP2)
    #undef UNITY_USE_DITHER_MASK_FOR_ALPHABLENDED_SHADOWS
#endif

#if (defined(_ALPHABLEND_ON) || defined(_ALPHAPREMULTIPLY_ON)) && defined(UNITY_USE_DITHER_MASK_FOR_ALPHABLENDED_SHADOWS)
    #define UNITY_STANDARD_USE_DITHER_MASK 1
#endif

#if defined(_ALPHATEST_ON) || defined(_ALPHABLEND_ON) || defined(_ALPHAPREMULTIPLY_ON)
#define UNITY_STANDARD_USE_SHADOW_UVS 1
#endif

#if !defined(V2F_SHADOW_CASTER_NOPOS_IS_EMPTY) || defined(UNITY_STANDARD_USE_SHADOW_UVS)
#define UNITY_STANDARD_USE_SHADOW_OUTPUT_STRUCT 1
#endif

float4      _BaseTex_ST;
#ifdef UNITY_STANDARD_USE_DITHER_MASK
sampler3D   _DitherMaskLOD;
#endif

struct VertexInputS
{
    float4 vertex   : POSITION;
    float3 normal   : NORMAL;
    float2 uv0      : TEXCOORD0;
};

#ifdef UNITY_STANDARD_USE_SHADOW_OUTPUT_STRUCT
struct VertexOutputShadowCaster
{
    V2F_SHADOW_CASTER_NOPOS
    float2 tex : TEXCOORD1;
};
#endif

// We have to do these dances of outputting SV_POSITION separately from the vertex shader,
// and inputting VPOS in the pixel shader, since they both map to "POSITION" semantic on
// some platforms, and then things don't go well.


//void vertShadowCaster (VertexInputS v,
void vertShadowCaster (TA_VertexInput v,
    #ifdef UNITY_STANDARD_USE_SHADOW_OUTPUT_STRUCT
    out VertexOutputShadowCaster o,
    #endif
    out float4 opos : SV_POSITION)
{
#ifdef SHADERMOTION_ON
    MorphAndSkinVertex(v, UNITY_ACCESS_INSTANCED_PROP(Props, _Layer));
#endif

    #ifdef UNITY_STANDARD_USE_SHADOW_OUTPUT_STRUCT
	    UNITY_INITIALIZE_OUTPUT(VertexOutputShadowCaster, o);
    #endif

    TRANSFER_SHADOW_CASTER_NOPOS(o,opos)
    #if defined(UNITY_STANDARD_USE_SHADOW_UVS)
        o.tex = TRANSFORM_TEX(v.uv0, _BaseTex);
    #endif
}

half4 fragShadowCaster (
#ifdef UNITY_STANDARD_USE_SHADOW_OUTPUT_STRUCT
    VertexOutputShadowCaster i
#endif
#ifdef UNITY_STANDARD_USE_DITHER_MASK
    , UNITY_VPOS_TYPE vpos : VPOS
#endif
    ) : SV_Target
{
    #if defined(UNITY_STANDARD_USE_SHADOW_UVS)
        half baseAlpha = tex2D(_BaseTex,i.tex).a;
		baseAlpha = lerp(baseAlpha, _BaseColor.a, _IsBaseColor);
        half alpha = baseAlpha * _Color.a;
        #if defined(_ALPHATEST_ON)
            clip (alpha - _Cutoff - 0.01);
        #endif
        #if defined(_ALPHABLEND_ON) || defined(_ALPHAPREMULTIPLY_ON)
            #if defined(UNITY_STANDARD_USE_DITHER_MASK)
                half alphaRef = tex3D(_DitherMaskLOD, float3(vpos.xy*0.25,alpha*0.9375)).a;
                clip (alphaRef - 0.01);
            #else
				clip (alpha - _Cutoff);
			#endif
        #endif
    #endif // #if defined(UNITY_STANDARD_USE_SHADOW_UVS)

    SHADOW_CASTER_FRAGMENT(i)
}


#endif
