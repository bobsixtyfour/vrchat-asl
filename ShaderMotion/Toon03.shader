Shader "TypeA/Toon03"
{
	Properties
	{
		//----------------------------------------------------------------------------------------------------
		_Color("MainColor", Color) = (1, 1, 1, 1)
		_Cutoff("Cutoff",Range(0, 1)) = 0.0
		[Enum(Opaque,0,Cutout,1,Fade,2,Transparent,3)]_blendMode("BlendMode", Float) = 0
		[Enum(UnityEngine.Rendering.BlendMode)]_SrcBlend ("SrcBlend", Float) = 1.0
		[Enum(UnityEngine.Rendering.BlendMode)]_DstBlend ("DstBlend", Float) = 0.0
		[HideInInspector]_ColorMask("__ColorMask",Float) = 15
		[Toggle]_AlphaToMask("_AlphaToMask", Float) = 0.0
		[Enum(Off,0,On,1)]_ZWrite ("ZWrite", Float) = 1.0
		[Enum(UnityEngine.Rendering.CullMode)]_CullMode ("CullMode", Float) = 2.0
		[Enum(UnityEngine.Rendering.CompareFunction)]_ZTest ("ZTest", Float) = 4

		//----------------------------------------------------------------------------------------------------
		[Toggle]_StencilMode("__StencilMode", Float) = 0.0
		[IntRange]_RefV("ReferenceValue",Range(0, 255)) = 1
		[IntRange]_ReadMask("ReadMask",Range(0, 255)) = 255
		[IntRange]_WriteMask("WriteMask",Range(0, 255)) = 255
		[Enum(UnityEngine.Rendering.CompareFunction)]_stComp("comparisonFunction",Float) = 8
		[Enum(UnityEngine.Rendering.StencilOp)]_stPass("stencilOperation",Float) = 0
		[Enum(UnityEngine.Rendering.StencilOp)]_stFail("stencilOperation",Float) = 0
		[Enum(UnityEngine.Rendering.StencilOp)]_stZFail("stencilOperation",Float) = 0
		[HideInInspector]_stComp_c("__stComp_c",Float) = 8
		[HideInInspector]_stPass_c("__stPass_c",Float) = 0
		[HideInInspector]_stFail_c("__stFail_c",Float) = 0
		[HideInInspector]_stZFail_c("__stZFail_c",Float) = 0

		//----------------------------------------------------------------------------------------------------
		[NoScaleOffset]_BaseTex("BaseColor", 2D) = "white" {}
		_BaseColor("BaseColor", Color) = (0.8, 0.8, 0.8, 1.0)
		[NoScaleOffset]_ShadowTex("ShadowColor", 2D) = "black" {}
		_ShadowColor("ShadowColor", Color) = (0.5, 0.5, 0.5, 1.0)
		[NoScaleOffset]_ShadowmapTex("ShadowMap", 2D) = "white" {}
		[NoScaleOffset]_ToonTex("Toon", 2D) = "white" {}

		_LightingDir("LightingDir", Range(0, 1)) = 0.0
		_AnchorPoint("AnchorPoint", Vector) = (0.0, 0.0, 0.0)

		_NormalSpherical("Spherical", Range(0, 1)) = 0.0
		_SphericalCenter("Spherical Center", Vector) = (0.0, 0.0, 0.0)
		_MappingScale("Normal Scale", Vector) = (1.0, 1.0, 1.0)
		_MappingRotation("Normal Rotation", Vector) = (0.0, 0.0, 0.0)

		_MainLightAffect("MainLighting Affect", Range(0, 1)) = 1.0
		_AmbientLightColor("AmbientLight Color", Range(0, 1)) = 1.0
		_AmbientTilt("Ambient Tilt", Range(0, 1)) = 1.0
		_AddLightAffect("AddLighting Affect", Range(0, 1)) = 1.0
		_SaturatedValue("Saturated Value", Range(1, 10)) = 1.0
		_ShadowAffect("Shadow Affect", Range(0, 1)) = 1.0
		[Enum(IncludeInDiffuse,0,DropAsAShadow,1)]_HandleShadow("Handle Shadow", Float) = 0.0
		[NoScaleOffset]_SystemShadowColorTex("SystemShadowColorMap", 2D) = "white" {}
		_SystemShadowColor("SystemShadowColor", Color) = (0, 0, 0)
		_SystemShadowAffect("SystemShadow Affect", Range(0, 1)) = 1.0
		_AddSystemShadowAffect("AddSystemShadow Affect", Range(0, 1)) = 1.0

		[HideInInspector]_IsBaseColor("__IsBaseColor", Float) = 1
		[HideInInspector]_IsShadowColor("__IsShadowColor", Float) = 1
		[HideInInspector]_IsHilightColor("__IsHilightColor", Float) = 1
		[HideInInspector]_IsSystemShadowColor("__IsSystemShadowColor", Float) = 1

		//----------------------------------------------------------------------------------------------------
		[Toggle]_hilightMode("__hilightMode", Float) = 0.0
		[NoScaleOffset]_HilightmapTex("HilightMap", 2D) = "black" {}
		_HilightColor("HilightColor", Color) = (1.0, 1.0, 1.0, 1)
		[NoScaleOffset]_ToonHilightTex("Toon Hilight", 2D) = "black" {}
		_HilightIntensity("Hilight Intensity", Range(0.0, 1.0)) = 1.0
		_ShadowHilightIntensity("Hilight in Shadow", Range(0.0, 1.0)) = 0.6
		[IntRange]_HilightHardness("Hilight Hardness",Range(1, 100)) = 15
		_HilightPower("Hilight Power",Range(0, 1)) = 0
		_HilightSpread("Color Spread",Range(0, 1)) = 0
		[IntRange]_HilightHardness("Hilight Hardness",Range(1, 100)) = 15

	}

	SubShader
	{
		Tags{ "RenderType"="Opaque"}

		//-------------------------------------------------------------------------------------
		// Toon03 Forward Base
		Pass
		{
			Name "FORWARDBASE"
			Tags{ "LightMode"="Forwardbase" }

			Stencil{
				Ref [_RefV]
				ReadMask [_ReadMask]
				WriteMask [_WriteMask]
				Comp [_stComp]
                Pass [_stPass]
				Fail [_stFail]
                ZFail [_stZFail]
			}

			Blend [_SrcBlend] [_DstBlend]
			ColorMask [_ColorMask]
			AlphaToMask [_AlphaToMask]
			ZWrite [_ZWrite]
			Cull [_CullMode]
			ZTest [_ZTest]

			CGPROGRAM
			#pragma target 3.0

			#pragma shader_feature_local _ HILIGHT_ENABLED
			#pragma shader_feature_local _ DROPSHADOW

			#pragma shader_feature_local _ _ALPHATEST_ON _ALPHABLEND_ON _ALPHAPREMULTIPLY_ON

			#pragma multi_compile_fog
			#pragma multi_compile_fwdbase

			#pragma vertex vertForwardBase
			#pragma fragment fragForwardBase

			#include "TypeAtoon02Forwardbase.cginc"

			ENDCG
		}

		//-------------------------------------------------------------------------------------
		// Toon03 Forward Add
		
		Pass
		{
			Name "FORWARDADD"
			Tags{ "LightMode"="ForwardAdd" }

			Stencil{
				Ref [_RefV]
				ReadMask [_ReadMask]
				WriteMask[_WriteMask]
				Comp [_stComp]
                Pass [_stPass]
				Fail [_stFail]
                ZFail [_stZFail]
			}

			Blend [_SrcBlend] One
			Fog { Color (0,0,0,0) }
			ZWrite Off
			ZTest LEqual
			Cull [_CullMode]

			CGPROGRAM
			#pragma target 3.0

			#pragma shader_feature_local _ _ALPHATEST_ON _ALPHABLEND_ON _ALPHAPREMULTIPLY_ON

			#pragma multi_compile_fwdadd_fullshadows
			#pragma multi_compile_fog

			#pragma vertex vertForwardAdd
			#pragma fragment fragForwardAdd

			#include "TypeAtoon02Forwardadd.cginc"

			ENDCG
		}

		// ------------------------------------------------------------------
		//  Shadow rendering pass
		Pass {
			Name "SHADOWCASTER"
			Tags { "LightMode"="ShadowCaster" }

			ZWrite On ZTest LEqual

			CGPROGRAM
			#pragma target 3.0

			// -------------------------------------

			#pragma shader_feature_local _ _ALPHATEST_ON _ALPHABLEND_ON _ALPHAPREMULTIPLY_ON
			#pragma multi_compile_shadowcaster

			#pragma vertex vertShadowCaster
			#pragma fragment fragShadowCaster

			#include "TypeAshadow.cginc"

			ENDCG
		}

	}
	Fallback "Standard"
	CustomEditor "TypeAToon02GUI"
}
