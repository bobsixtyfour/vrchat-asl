#ifndef TYPEA_TOON02_FORWRDBASE_INCLUDED
#define TYPEA_TOON02_FORWRDBASE_INCLUDED

#include "TypeA2Function.cginc"

#ifdef SHADERMOTION_ON
#include "MeshPlayer.hlsl"

UNITY_INSTANCING_BUFFER_START(Props)
UNITY_DEFINE_INSTANCED_PROP(float, _Layer)
UNITY_INSTANCING_BUFFER_END(Props)
#endif


		struct VertexOutForwardAdd
		{

			float4	pos					:	SV_POSITION;
			float4	tex					:	TEXCOORD0;
			half3	normal				:	NORMAL;
			half4	viewDir				:	TEXCOORD1;	//xyz:viewDir / w:clip viewDir z
			float3	posWorld			:	TEXCOORD2;
			half3	lightDir			:	TEXCOORD3;
			UNITY_SHADOW_COORDS(4)
			UNITY_FOG_COORDS(5)

			UNITY_VERTEX_OUTPUT_STEREO
		};

		VertexOutForwardAdd vertForwardAdd(TA_VertexInput v)
		{
			UNITY_SETUP_INSTANCE_ID(v);
		    VertexOutForwardAdd o;
		    UNITY_INITIALIZE_OUTPUT(VertexOutForwardAdd, o);
			UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

#ifdef SHADERMOTION_ON
			MorphAndSkinVertex(v, UNITY_ACCESS_INSTANCED_PROP(Props, _Layer));
#endif

			float4 iv = float4(v.vertex.xyz, 1.0);
			o.posWorld = TAPOS_O2W_I4(iv).xyz;
			o.pos = TAPOS_W2C_I3(o.posWorld);

			half3 posView = TAPOS_W2V_I3(o.posWorld).xyz;
			o.viewDir.xyz = normalize(-posView);

			o.normal = TANOR_O2V(v.vertex.xyz);

		    o.lightDir = _WorldSpaceLightPos0.xyz - o.posWorld.xyz * _WorldSpaceLightPos0.w;
			#ifndef USING_DIRECTIONAL_LIGHT
				o.lightDir = TA_NormalizePerVertexNormal(o.lightDir);
			#endif

			o.tex = TA_TexCoords(v);

			UNITY_TRANSFER_SHADOW(o, v.uv1);
			UNITY_TRANSFER_FOG(o, o.pos);

			return o;
		}


		float4 fragForwardAdd(VertexOutForwardAdd i) : SV_Target
		{
			UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

			TA_COLOR_WHITE(TAC_w)
			TA_COLOR_BLACK(TAC_b)

			TA_LIGHT_ATTENUATION(atten, shadow, i, i.posWorld.xyz);
			UnityLight light = TA_AdditiveLight (i.lightDir,atten);
			atten = min(_SaturatedValue, atten);

			#if DIRECTIONAL
				shadow = lerp(1, shadow * atten, _AddSystemShadowAffect);
			#else
				shadow = lerp(1, shadow, _AddSystemShadowAffect);
			#endif

			half3 lc = TA_restriction(_SaturatedValue, light.color);
			half lcl = TA_Luminance(lc);

			half4 tex = tex2D(_BaseTex,i.tex.xy);
			tex = lerp(tex, _BaseColor, _IsBaseColor);
			half4 tex_s = tex2D(_ShadowTex, i.tex.xy);
			tex_s = lerp(tex_s, _ShadowColor, _IsShadowColor);
			half tex_sm = tex2D(_ShadowmapTex, i.tex.xy);
			half3 tex_ss = tex2D(_SystemShadowColorTex, i.tex.xy);
			tex_ss = lerp(tex_ss, _SystemShadowColor, _IsSystemShadowColor);
			tex_ss = lerp(1, tex_ss, _AddSystemShadowAffect);


			half3 n = normalize(i.normal);
			half3 normalWorld = half3(i.posWorld - TA_OBJCENTER);

			half d = dot(normalWorld, light.dir) * 0.5 + 0.5;

			float2 tuv = (d + tex_sm) * 0.5;
			half smdt = tex2D(_ToonTex, tuv);
			smdt = lerp(1, smdt, _ShadowAffect);

			half dla = smdt * shadow;
			half asa = saturate((shadow + smdt) -1);

			#if DROPSHADOW
				dla = smdt * (_ShadowAffect + (1 - _ShadowAffect) );
			#endif

			half4 tdiff = tex;
			tdiff = tex * dla + tex_s * (1.0 - dla);
			tdiff.a = tdiff.a * asa + tex_s.a * (1.0 - asa);

			#if DROPSHADOW
				tdiff.rgb = lerp(tdiff.rgb * tex_ss, tdiff.rgb, min(shadow, iff));
			#endif

			fixed4 c = tdiff;
			c.rgb = lerp(TAC_b, c.rgb * lc * d, _AddLightAffect);

			#if _ALPHATEST_ON
				c.a = tdiff.a * _Color.a;
				clip (c.a - _Cutoff);
			#elif _ALPHABLEND_ON || _ALPHAPREMULTIPLY_ON
				c.a = tdiff.a * _Color.a;
			#else
				c.a = 1.0;
			#endif

			#if TA_STENCIL_FADE
				c.a = lerp(c.a, 0, (1 - _StencilFade)) * _StencilMode;
			#endif

			UNITY_APPLY_FOG_COLOR(i.fogCoord, c.rgb, half4(0,0,0,0));

			return c;
		}

#endif
