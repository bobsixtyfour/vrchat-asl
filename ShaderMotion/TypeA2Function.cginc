#ifndef TYPEA2_FUNCTION_INCLUDED
#define TYPEA2_FUNCTION_INCLUDED

#include "UnityCG.cginc"
#include "AutoLight.cginc"
#include "Lighting.cginc"

#include "TypeA2Config.cginc"

static float4x4 ta_MatrixITV = transpose(unity_MatrixInvV);
static half3 ta_lumaY = fixed3(0.2126729,  0.7151522, 0.0721750);
static half3 ta_worldobjectcenter = half3(UNITY_MATRIX_M[0][3] - _AnchorPoint.x, UNITY_MATRIX_M[1][3] - _AnchorPoint.y, UNITY_MATRIX_M[2][3] - _AnchorPoint.z);
#define TA_OBJCENTER ta_worldobjectcenter
static float ta_fov = atan(1.0f / unity_CameraProjection._m11) * 2.0 * (180 / UNITY_PI);

//object to world pos / ret 4
#define TAPOS_O2W_I4(pos) mul(UNITY_MATRIX_M, pos)
#define TAPOS_O2W_I3(pos) mul(UNITY_MATRIX_M, float4(pos, 1.0))

//object to view pos / ret 4
#define TAPOS_O2V_I4(pos) TAPOS_W2V_I3(TAPOS_O2W_I4(pos).xyz)
#define TAPOS_O2V_I3(pos) TAPOS_W2V_I3(TAPOS_O2W_I3(pos).xyz)

//object to clip pos / ret 4
#define TAPOS_O2C_I4(pos) TAPOS_W2C_I3(TAPOS_O2W_I4(pos).xyz)
#define TAPOS_O2C_I3(pos) TAPOS_W2C_I3(TAPOS_O2W_I3(pos).xyz)

//world to view pos / ret 4
#define TAPOS_W2V_I4(pos) mul(UNITY_MATRIX_V, pos)
#define TAPOS_W2V_I3(pos) mul(UNITY_MATRIX_V, float4(pos, 1.0))

//world to clip pos / ret 4
#define TAPOS_W2C_I4(pos) mul(UNITY_MATRIX_VP, pos)
#define TAPOS_W2C_I3(pos) mul(UNITY_MATRIX_VP, float4(pos, 1.0))

//view to clip pos / ret 4
#define TAPOS_V2C_I4(pos) mul(UNITY_MATRIX_P, pos)
#define TAPOS_V2C_I3(pos) mul(UNITY_MATRIX_P, float4(pos, 1.0))

//object to world normal
#define TANOR_O2W(normal) normalize(mul(normal, (float3x3)unity_WorldToObject))
//#define TANOR_O2W(normal) normalize(mul((float3x3)unity_ObjectToWorld, normal))

//object to view normal
#define TANOR_O2V(normal) normalize(mul((float3x3)UNITY_MATRIX_IT_MV, normal))

//world to view normal
#define TANOR_W2V(normal) normalize(mul((float3x3)ta_MatrixITV, normal))

//view to world normal
#define TANOR_V2W(normal) normalize(mul((float3x3)UNITY_MATRIX_V, normal))


#define TA_COLOR_WHITE(i) fixed3 i = fixed3(1, 1, 1);
#define TA_COLOR_BLACK(i) fixed3 i = fixed3(0, 0, 0);


#define IN_LIGHTDIR_FWDADD(i) half3(i.tangentToWorldAndLightDir[0].w, i.tangentToWorldAndLightDir[1].w, i.tangentToWorldAndLightDir[2].w)

half TA_Luminance(half3 rgb)
{
	return dot(rgb, ta_lumaY);
}

half3 TA_rotX(half3 v1, half r)
{
	float rad = r * UNITY_PI / 180.0;

	float sinr, cosr;
	sincos(rad, sinr, cosr);

	float2x2 m = float2x2(	cosr,	sinr,
							-sinr,	cosr	);
	float3 v = float3(v1.x,mul(m, v1.yz));

	return v;
}

half3 TA_rotY(half3 v1, half r)
{
	float rad = r * UNITY_PI / 180.0;

	float sinr, cosr;
	sincos(rad, sinr, cosr);

	float2x2 m = float2x2(	cosr,	-sinr,
							sinr,	cosr	);
	float3 v = float3(mul(m, v1.xz),v1.y).xzy;

	return v;
}

half3 TA_rotZ(half3 v1, half r)
{
	float rad = r * UNITY_PI / 180.0;

	float sinr, cosr;
	sincos(rad, sinr, cosr);

	float2x2 m = float2x2(	cosr,	sinr,
							-sinr,	cosr	);
	float3 v = float3(mul(m, v1.xy),v1.z);

	return v;
}


struct TA_VertexInput
{
    float4 vertex   : POSITION;
    half3 normal    : NORMAL;
#ifdef SHADERMOTION_ON
    float4 uv0      : TEXCOORD0;
    float4 boneWeights : TEXCOORD1;
    float2 uv1      : TEXCOORD2;
    half4 tangent   : TANGENT;
#else
    float2 uv0      : TEXCOORD0;
    float2 uv1      : TEXCOORD1;
#ifdef _TANGENT_TO_WORLD
    half4 tangent   : TANGENT;
#endif
#endif 

#if defined(DYNAMICLIGHTMAP_ON) || defined(UNITY_PASS_META)
    float2 uv2      : TEXCOORD2;
#endif
	fixed4 color	: COLOR;

};

float4 TA_TexCoords(TA_VertexInput v)
{
    float4 texcoord;
    texcoord.xy = v.uv0;
    texcoord.zw = v.uv1;
    return texcoord;
}

half3 TA_NormalizePerVertexNormal (float3 n)
{
    #if (SHADER_TARGET < 30)
        return normalize(n);
    #else
        return n;
    #endif
}

float3 TA_NormalizePerPixelNormal (float3 n)
{
    #if (SHADER_TARGET < 30)
        return n;
    #else
        return normalize(n);
    #endif
}

inline half3 TA_SafeNormalize(half3 inVec)
{
    half dp3 = max(0.001f, dot(inVec, inVec));
    return inVec * rsqrt(dp3);
}

//-------------------------------------------------------------------------------------
#ifdef POINT
#define TA_LIGHT_ATTENUATION(destName, shadow, input, worldPos) \
    unityShadowCoord3 lightCoord = mul(unity_WorldToLight, unityShadowCoord4(worldPos, 1)).xyz; \
    fixed shadow = UNITY_SHADOW_ATTENUATION(input, worldPos); \
    fixed destName = tex2D(_LightTexture0, dot(lightCoord, lightCoord).rr).UNITY_ATTEN_CHANNEL;
#endif

#ifdef SPOT
#define TA_LIGHT_ATTENUATION(destName, shadow, input, worldPos) \
    unityShadowCoord4 lightCoord = mul(unity_WorldToLight, unityShadowCoord4(worldPos, 1)); \
    fixed shadow = UNITY_SHADOW_ATTENUATION(input, worldPos); \
    fixed destName = (lightCoord.z > 0) * UnitySpotCookie(lightCoord) * UnitySpotAttenuate(lightCoord.xyz);
#endif

#ifdef DIRECTIONAL
    #define TA_LIGHT_ATTENUATION(destName, shadow, input, worldPos) fixed shadow = UNITY_SHADOW_ATTENUATION(input, worldPos); \
	fixed destName = _LightColor0.a;
#endif

#ifdef POINT_COOKIE
#define TA_LIGHT_ATTENUATION(destName, shadow, input, worldPos) \
    unityShadowCoord3 lightCoord = mul(unity_WorldToLight, unityShadowCoord4(worldPos, 1)).xyz; \
    fixed shadow = UNITY_SHADOW_ATTENUATION(input, worldPos); \
    fixed destName = tex2D(_LightTextureB0, dot(lightCoord, lightCoord).rr).UNITY_ATTEN_CHANNEL * texCUBE(_LightTexture0, lightCoord).w;
#endif

#ifdef DIRECTIONAL_COOKIE
#define TA_LIGHT_ATTENUATION(destName, shadow, input, worldPos) \
    unityShadowCoord2 lightCoord = mul(unity_WorldToLight, unityShadowCoord4(worldPos, 1)).xy; \
    fixed shadow = UNITY_SHADOW_ATTENUATION(input, worldPos); \
    fixed destName = tex2D(_LightTexture0, lightCoord).w;
#endif

half TA_restriction(half rest, half val)
{
	half l = max(val, 0.0000001);
	return l * min(1, rest / l);
}

half3 TA_restriction(half rest, half3 col)
{
	half l = max(TA_Luminance(col), 0.0000001);
	return col * min(1, rest / l);
}

half3 TA_restrictionLen(half rest, half3 col)
{
	half l = max(length(col) * 0.5773502691896259, 0.0000001);
	return col * min(1, rest / l);
}


//world pos
half3 TA_shLightDirection(float3 pos)
{
	half3 dir = _WorldSpaceLightPos0.xyz;
	dir *= TA_Luminance(_LightColor0.rgb) * _LightColor0.a;
	dir = TA_restrictionLen(_SaturatedValue, dir) * 2;

    #ifdef UNITY_SHOULD_SAMPLE_SH

		dir += TA_restrictionLen(_SaturatedValue, unity_SHAr.rgb + unity_SHAg.rgb + unity_SHAb.rgb);

	 	half3 wv = normalize(_WorldSpaceCameraPos.xyz - pos);
		half auc = step(abs(sign(unity_SHAr.y)) + abs(sign(unity_SHAg.y)) + abs(sign(unity_SHAb.y)) + length(dir), 0.0);
		auc = 1 - step(auc, 0);

		dir += normalize(half3(wv.x, 0.707, wv.z)) * auc * 0.3;


        #ifdef VERTEXLIGHT_ON
			float4 lightX = unity_4LightPosX0 - pos.x;
			float4 lightY = unity_4LightPosY0 - pos.y;
			float4 lightZ = unity_4LightPosZ0 - pos.z;

			float4 lengthSQ = 0;
			lengthSQ += lightX * lightX;
			lengthSQ += lightY * lightY;
			lengthSQ += lightZ * lightZ;
			float4 corr = rsqrt(lengthSQ);
			half4 cor = 1 - step(1, unity_4LightAtten0);

			lengthSQ *= 0.3;
			lengthSQ *= lengthSQ;
			lengthSQ *= 0.1;
			float4 atten = 1 / (1 + lengthSQ * unity_4LightAtten0);
			atten = atten * atten * cor * corr;
			
			lightX *= atten;
			lightY *= atten;
			lightZ *= atten;

			half3 light0 = half3(lightX.x, lightY.x, lightZ.x);
			half3 light1 = half3(lightX.y, lightY.y, lightZ.y);
			half3 light2 = half3(lightX.z, lightY.z, lightZ.z);
			half3 light3 = half3(lightX.w, lightY.w, lightZ.w);

			half3 lc = light0 + light1 + light2 + light3;
			dir += TA_restrictionLen(_SaturatedValue, lc);

		#endif

	#endif
	
	return dir;
}

//-------------------------------------------------------------------------------------
/*
UnityLight TA_MainLight (float3 worldPos)
{
    UnityLight l;

    l.color = _LightColor0.rgb;
	l.dir = _WorldSpaceLightPos0.xyz;
    return l;
}
*/

UnityLight TA_AdditiveLight (half3 lightDir, half atten)
{
    UnityLight l;

    l.color = _LightColor0.rgb;
    l.dir = lightDir;
    #ifndef USING_DIRECTIONAL_LIGHT
        l.dir = TA_NormalizePerPixelNormal(l.dir);
    #endif

    // shadow the light
	l.color *= atten;
    return l;
}

UnityIndirect TA_ZeroIndirect ()
{
    UnityIndirect ind;
    ind.diffuse = 0;
    ind.specular = 0;
    return ind;
}

half3 TA_SHEvalLinearL0L1 ( float4 normal )
{
	half3 x;
    
	x.r = dot(unity_SHAr,normal);
    x.g = dot(unity_SHAg,normal);
    x.b = dot(unity_SHAb,normal);
	
	return x;
}

half3 TA_SHEvalLinearL2 ( float4 normal)
{
    half3 x1, x2;

    half4 vB = normal.xyzz * normal.yzzx;

    x1.r = dot(unity_SHBr,vB);
    x1.g = dot(unity_SHBg,vB);
    x1.b = dot(unity_SHBb,vB);
	x1 = x1;

    half vC = normal.x*normal.x - normal.y*normal.y;

	x2 = unity_SHC.rgb * vC;

	return x1 + x2;
}

#if UNITY_LIGHT_PROBE_PROXY_VOLUME

// normal should be normalized, w=1.0
half3 TA_SHEvalLinearL0L1_SampleProbeVolume (half4 normal, float3 worldPos)
{
    const float transformToLocal = unity_ProbeVolumeParams.y;
    const float texelSizeX = unity_ProbeVolumeParams.z;

    //The SH coefficients textures and probe occlusion are packed into 1 atlas.
    //-------------------------
    //| ShR | ShG | ShB | Occ |
    //-------------------------

    float3 position = (transformToLocal == 1.0f) ? mul(unity_ProbeVolumeWorldToObject, float4(worldPos, 1.0)).xyz : worldPos;
    float3 texCoord = (position - unity_ProbeVolumeMin.xyz) * unity_ProbeVolumeSizeInv.xyz;
    texCoord.x = texCoord.x * 0.25f;

    // We need to compute proper X coordinate to sample.
    // Clamp the coordinate otherwize we'll have leaking between RGB coefficients
    float texCoordX = clamp(texCoord.x, 0.5f * texelSizeX, 0.25f - 0.5f * texelSizeX);

    // sampler state comes from SHr (all SH textures share the same sampler)
    texCoord.x = texCoordX;
    half4 SHAr = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, texCoord);

    texCoord.x = texCoordX + 0.25f;
    half4 SHAg = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, texCoord);

    texCoord.x = texCoordX + 0.5f;
    half4 SHAb = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, texCoord);

    // Linear + constant polynomial terms
    half3 x1;
	
	x1.r = dot(SHAr, normal);
	x1.g = dot(SHAg, normal);
	x1.b = dot(SHAb, normal);

    return x1;
}
#endif

half3 TA_ShadeSH9 ( float4 normal)
{
    // Linear + constant polynomial terms
    half3 res = TA_SHEvalLinearL0L1 ( normal );

    // Quadratic polynomials
    res += TA_SHEvalLinearL2 ( normal );

#   ifdef UNITY_COLORSPACE_GAMMA
        res = LinearToGammaSpace (res);
#   endif

    return res;
}

half3 TA_ShadeSHPerVertex (half4 normal, half3 ambient)
{
    #if UNITY_SAMPLE_FULL_SH_PER_PIXEL
        // Completely per-pixel
        // nothing to do here
    #elif (SHADER_TARGET < 30)
        // Completely per-vertex
        ambient += max(half3(0,0,0), TA_ShadeSH9(normal));
    #else
        #ifdef UNITY_COLORSPACE_GAMMA
            ambient = GammaToLinearSpace (ambient);
        #endif
        ambient += TA_SHEvalLinearL2(normal);
    #endif

    return ambient;
}

half3 TA_ShadeSHPerPixel (half4 normal, half3 ambient, float3 posWorld)
{
    half3 ambient_contrib = 0.0;

    #if UNITY_SAMPLE_FULL_SH_PER_PIXEL
        // Completely per-pixel
        ambient_contrib = TA_ShadeSH9(normal);
        ambient += max(half3(0, 0, 0), ambient_contrib);

    #elif (SHADER_TARGET < 30)
        // Completely per-vertex
        // nothing to do here
    #else
        // L2 per-vertex, L0..L1 & gamma-correction per-pixel
        // Ambient in this case is expected to be always Linear, see ShadeSHPerVertex()
        #if UNITY_LIGHT_PROBE_PROXY_VOLUME
            if (unity_ProbeVolumeParams.x == 1.0)
			{
                ambient_contrib = TA_SHEvalLinearL0L1_SampleProbeVolume (normal, posWorld);
	            ambient_contrib = TA_SHEvalLinearL0L1 (normal);

			}
            else
			{
                //ambient_contrib = TA_SHEvalLinearL0L1 (normal);///////////////
                ambient_contrib = TA_SHEvalLinearL0L1(normal);
			}
		#else
            ambient_contrib = TA_SHEvalLinearL0L1(normal);
            //ambient_contrib = TA_SHEvalLinearL0L1 (normal);

		#endif

        ambient = max(half3(0, 0, 0), ambient+ambient_contrib);
        #ifdef UNITY_COLORSPACE_GAMMA
            ambient = LinearToGammaSpace (ambient);
        #endif

    #endif

    return ambient;
}


float3 TA_Shade4PointLights (
    float4 lightPosX, float4 lightPosY, float4 lightPosZ,
    float3 lightColor0, float3 lightColor1, float3 lightColor2, float3 lightColor3,
    float4 lightAttenSq,
    float3 pos, float3 normal)
{

    // to light vectors
    float4 toLightX = lightPosX - pos.x;
    float4 toLightY = lightPosY - pos.y;
    float4 toLightZ = lightPosZ - pos.z;
    // squared lengths
    float4 lengthSq = 0;
    lengthSq += toLightX * toLightX;
    lengthSq += toLightY * toLightY;
    lengthSq += toLightZ * toLightZ;
    // don't produce NaNs if some vertex position overlaps with the light
    lengthSq = max(lengthSq, 0.000001);

    // NdotL
    float4 ndotl = 0;
    ndotl += toLightX * normal.x;
    ndotl += toLightY * normal.y;
    ndotl += toLightZ * normal.z;
    // correct NdotL
    float4 corr = rsqrt(lengthSq);
    ndotl = ndotl * corr * 0.5 + 0.5;

    float4 atten = 1.0 / (1.0 + lengthSq * lightAttenSq);
	atten = atten * smoothstep(0.0346, 0.069, atten);
    float4 diff = ndotl * atten;

    // final color
    float3 col = 0;
	col += lightColor0 * diff.x;
    col += lightColor1 * diff.y;
    col += lightColor2 * diff.z;
    col += lightColor3 * diff.w;
    return col;

}


inline half4 TA_VertexGIForward(TA_VertexInput v, float3 posWorld, float4 normalWorld)
{
    half4 ambientOrLightmapUV = 0;
    // Static lightmaps
//    #ifdef LIGHTMAP_ON
//        ambientOrLightmapUV.xy = v.uv1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
//        ambientOrLightmapUV.zw = 0;
    // Sample light probe for Dynamic objects only (no static or dynamic lightmaps)
    #ifdef UNITY_SHOULD_SAMPLE_SH
        
		#ifdef VERTEXLIGHT_ON
           // Approximated illumination from non-important point lights
            ambientOrLightmapUV.rgb = Shade4PointLights (
                unity_4LightPosX0, unity_4LightPosY0, unity_4LightPosZ0,
                unity_LightColor[0].rgb, unity_LightColor[1].rgb, unity_LightColor[2].rgb, unity_LightColor[3].rgb,
                unity_4LightAtten0, posWorld, normalWorld.xyz);
		#endif

        ambientOrLightmapUV.rgb = TA_ShadeSHPerVertex (normalWorld, ambientOrLightmapUV.rgb);
   #endif

//    #ifdef DYNAMICLIGHTMAP_ON
//        ambientOrLightmapUV.zw = v.uv2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
//   #endif

    return ambientOrLightmapUV;
}

inline half4 TA_VertexGIForward(float3 posWorld, float4 normalWorld)
{
    half4 ambientOrLightmapUV = 0;
    // Static lightmaps
//    #ifdef LIGHTMAP_ON
//        ambientOrLightmapUV.xy = v.uv1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
//        ambientOrLightmapUV.zw = 0;
    // Sample light probe for Dynamic objects only (no static or dynamic lightmaps)
    #ifdef UNITY_SHOULD_SAMPLE_SH
        //#ifdef VERTEXLIGHT_ON
        //    // Approximated illumination from non-important point lights
        //    ambientOrLightmapUV.rgb = TA_Shade4PointLights (
        //        unity_4LightPosX0, unity_4LightPosY0, unity_4LightPosZ0,
        //        unity_LightColor[0].rgb, unity_LightColor[1].rgb, unity_LightColor[2].rgb, unity_LightColor[3].rgb,
        //        unity_4LightAtten0, posWorld, normalWorld.xyz);
		//#endif

        ambientOrLightmapUV.rgb = TA_ShadeSHPerVertex (normalWorld, ambientOrLightmapUV.rgb);
   #endif

//    #ifdef DYNAMICLIGHTMAP_ON
//        ambientOrLightmapUV.zw = v.uv2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
//   #endif

    return ambientOrLightmapUV;
}

#endif

