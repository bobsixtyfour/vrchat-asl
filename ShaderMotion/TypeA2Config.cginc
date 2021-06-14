#ifndef TYPEA2_CONFIG_INCLUDED
#define TYPEA2_CONFIG_INCLUDED

//------------------------------------------------------
fixed		_blendMode;
fixed		_SrcBlend;
fixed		_DstBlend;
fixed		_ZWrite;
fixed		_CullMode;
fixed		_ZTest;

half		_Cutoff;
fixed		_ColorMask;
fixed		_AlphaToMask;

fixed4		_Color;

//------------------------------------------------------
fixed		_StencilMode;

fixed		_RefV;

fixed		_ReadMask;
fixed		_WriteMask;
fixed		_stComp;
fixed		_stPass;
fixed		_stFail;
fixed		_stZFail;

half		_StencilFade;

fixed		_stComp_c;
fixed		_stPass_c;
fixed		_stFail_c;
fixed		_stZFail_c;

fixed		_ReadMask_f;


//------------------------------------------------------
sampler2D	_BaseTex;
fixed4		_BaseColor;
fixed		_IsBaseColor;
sampler2D	_ShadowTex;
fixed4		_ShadowColor;
fixed		_IsShadowColor;
sampler2D	_ShadowmapTex;
sampler2D	_ToonTex;

half		_LightingDir;
half3		_AnchorPoint;

half		_NormalSpherical;
half3		_SphericalCenter;
half3		_MappingScale;
half2		_MappingRotation;

half		_MainLightAffect;
half		_AmbientLightColor;
half		_AmbientTilt;
half		_AddLightAffect;
half		_SaturatedValue;
half		_ShadowAffect;

sampler2D	_SystemShadowColorTex;
fixed3		_SystemShadowColor;
fixed		_IsSystemShadowColor;
half		_SystemShadowAffect;
half		_AddSystemShadowAffect;

half		_HandleShadow;

//------------------------------------------------------
fixed		_hilightmode;

sampler2D	_HilightmapTex;
fixed4		_HilightColor;
fixed		_IsHilightColor;
sampler2D	_ToonHilightTex;
half		_HilightHardness;
half		_HilightPower;
half		_HilightSpread;
half		_HilightIntensity;
half		_ShadowHilightIntensity;

//------------------------------------------------------
fixed		_edgeMode;

fixed4		_EdgeColor;
half		_BaseTexMix;
fixed		_BCmixMethod;
half		_ShadowTexMix;
fixed		_SCmixMethod;
half		_EdgeThickness;
fixed		_vc2edge;

#endif
