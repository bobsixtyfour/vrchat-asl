#ifndef TYPEA_TOON02_FORWRDBASE_INCLUDED
#define TYPEA_TOON02_FORWRDBASE_INCLUDED

#include "TypeA2Function.cginc"

		struct VertexOutForwardBase
		{
			float4	pos					:	SV_POSITION;
			float4	tex					:	TEXCOORD0;
			half3	normal				:	NORMAL;
			half4	viewDir				:	TEXCOORD1;	//xyz:viewDir
			float3	posWorld			:	TEXCOORD2;
			half4	ambientOrLightmapUV	:	TEXCOORD3;
			fixed3	pointLightColor		:	TEXCOORD4;
			half3	lightDirSH			:	TEXCOORD5;
			UNITY_SHADOW_COORDS(6)
			UNITY_FOG_COORDS(7)

			UNITY_VERTEX_INPUT_INSTANCE_ID
			UNITY_VERTEX_OUTPUT_STEREO
		};

		VertexOutForwardBase vertForwardBase(TA_VertexInput v)
		{
			UNITY_SETUP_INSTANCE_ID(v);
			VertexOutForwardBase o;
		    UNITY_INITIALIZE_OUTPUT(VertexOutForwardBase, o);
			UNITY_TRANSFER_INSTANCE_ID(v, o);
			UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

			float4 iv = float4(v.vertex.xyz, 1.0);
			o.posWorld = TAPOS_O2W_I4(iv).xyz;
			o.pos = TAPOS_W2C_I3(o.posWorld);
			float4 normalWorld = float4(o.posWorld - TA_OBJCENTER, 1.0);
			normalWorld.y = normalWorld.y * _AmbientTilt;

			half3 posView = TAPOS_W2V_I3(o.posWorld).xyz;
			o.viewDir.xyz = normalize(-posView);

			half3 spn = normalize(v.vertex.xyz - _SphericalCenter);
			half3 n = lerp(v.normal, spn, _NormalSpherical);
			n *= _MappingScale;
			n = TA_rotX( n, _MappingRotation.x);
			n = TA_rotY( n, _MappingRotation.y);

			o.normal = TANOR_O2V(n);

			half3 ldsh = TA_shLightDirection(o.posWorld);
			o.lightDirSH = TANOR_W2V(ldsh);

			o.tex = TA_TexCoords(v);

			o.pointLightColor = 0;
			#ifdef UNITY_SHOULD_SAMPLE_SH
				#ifdef VERTEXLIGHT_ON
					o.pointLightColor = TA_Shade4PointLights (	unity_4LightPosX0, unity_4LightPosY0, unity_4LightPosZ0,
											unity_LightColor[0].rgb, unity_LightColor[1].rgb, unity_LightColor[2].rgb, unity_LightColor[3].rgb,
											unity_4LightAtten0, o.posWorld, normalWorld.xyz	);
					o.pointLightColor = TA_restriction(_SaturatedValue, o.pointLightColor);
				#endif
			#endif
			o.ambientOrLightmapUV.rgb = TA_VertexGIForward(o.posWorld, normalWorld);

			UNITY_TRANSFER_SHADOW(o, v.uv1);
			UNITY_TRANSFER_FOG(o, o.pos);

			return o;
		}


		float4 fragForwardBase(VertexOutForwardBase i, fixed vf : VFACE) : SV_Target
		{
		    UNITY_SETUP_INSTANCE_ID(i);
			UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);
			
			TA_COLOR_WHITE(TAC_w)
			TA_COLOR_BLACK(TAC_b)

			half4 tex = tex2D(_BaseTex,i.tex.xy);
			tex = lerp(tex, _BaseColor, _IsBaseColor);
			half4 tex_s = tex2D(_ShadowTex, i.tex.xy);
			tex_s = lerp(tex_s, _ShadowColor, _IsShadowColor);
			half tex_sm = tex2D(_ShadowmapTex, i.tex.xy);
			half3 tex_ss = tex2D(_SystemShadowColorTex, i.tex.xy);
			tex_ss = lerp(tex_ss, _SystemShadowColor, _IsSystemShadowColor);
			tex_ss = lerp(1, tex_ss, _SystemShadowAffect);

			half iff = sign(vf);
			i.normal *= iff;

			TA_LIGHT_ATTENUATION(atten, shadow, i, i.posWorld.xyz);
			atten = min(_SaturatedValue, atten);
			shadow = shadow * min(1, atten * max(0, iff));
			half sa = lerp(1, shadow, _SystemShadowAffect);

			half3 shd = i.ambientOrLightmapUV.rgb;
			#if UNITY_SHOULD_SAMPLE_SH
				float4 normalWorld = float4(i.posWorld - TA_OBJCENTER, 1.0);
				normalWorld.y = normalWorld.y * _AmbientTilt;
				normalWorld *= lerp(0.5, 1.0, max(0, iff));
				shd = TA_ShadeSHPerPixel(normalWorld, shd, i.posWorld);
			#endif
			shd = TA_restriction(_SaturatedValue , shd);
			half shl = TA_Luminance(shd);
			shd = lerp(shl, shd, _AmbientLightColor);

			half3 lc = _LightColor0.rgb;
			lc = TA_restriction(_SaturatedValue, lc);
			lc *= (_SaturatedValue - shl) / _SaturatedValue;
			half lcl = TA_Luminance(lc);
			
			half3 n = normalize(i.normal);
			half3 hn = normalize(n - lerp(0, i.lightDirSH * 0.25, _LightingDir));
			half3 v = normalize(i.viewDir.xyz);

			half dnv = saturate( dot(i.normal, i.viewDir) );
			half dnl = lerp( dot(i.normal, i.lightDirSH), 1.0, 0.25);

			float2 tuv = lerp(dnv - (1 - tex_sm), dnl * tex_sm, _LightingDir);
			half smdt = tex2D(_ToonTex, tuv);
			smdt = lerp(1, smdt, _ShadowAffect);

			half dla = min(smdt, sa + sa * shl);
			half asa = saturate((sa + smdt) -1);

			half4 tdiff = tex;
			tdiff.rgb = tex.rgb * dla + tex_s.rgb * (1.0 - dla);
			half4 shdiff = tex;
			shdiff.rgb = tex.rgb * smdt + tex_s.rgb * (1.0 - smdt);

			#if DROPSHADOW
				tdiff.rgb = lerp(tdiff.rgb * tex_ss, tdiff.rgb, sa);
				tdiff.rgb = lerp(tdiff.rgb, tdiff.rgb * lc + shdiff.rgb * shd, _MainLightAffect);
			#else
				tdiff.rgb = lerp(tdiff.rgb, tdiff.rgb * (lc + shd), _MainLightAffect);
			#endif
			
			tdiff.rgb += lerp(TAC_b, (shdiff.rgb + tex.rgb) * 0.5 * i.pointLightColor, _AddLightAffect);

			tdiff.a = tdiff.a * asa + tex_s.a * (1.0 - asa );

			#ifdef HILIGHT_ENABLED
				half4 tex_hi = tex2D(_HilightmapTex, i.tex.xy);
				tex_hi = lerp(tex_hi, _HilightColor, _IsHilightColor);
				half hh = _HilightHardness * 1.75;
				half hid1 = pow( max(0, dot( hn, v)), hh);
				half hid2 = pow( max(0, dot( TA_rotX(hn, 60), v)), hh);
				half hid3 = pow( max(0, dot( TA_rotX(hn, -60), v ) ), hh);
				half hid = hid1 + hid2 + hid3;
				tuv.x = hid * tex_hi.a;
				half3 hit = tex2D(_ToonHilightTex, tuv);
				
				#ifdef UNITY_COLORSPACE_GAMMA
					hit = hit * hit * hit * hit;
				#endif

				half his = saturate(smdt * (shadow + shl));

				half hpw = saturate(pow(hit, 2 * (1 - _HilightPower) + 4));
				half3 hspw = lerp(TAC_w, tex_hi.rgb, tuv.x * _HilightSpread);
				half3 hspb = lerp(TAC_b, tex_hi.rgb, tuv.x * _HilightSpread) * lcl * his * 0.5;
				hspw = lerp(hspw, TAC_w, hpw);
				half3 hspc = tdiff.rgb * hspw + hspb;
				
				half3 hpc = lerp(tex_hi.rgb * hpw, tex_hi.rgb * hpw + hpw * 2, _HilightPower);
				hpc = TA_restriction(0.25, hpc * (lc + shd + i.pointLightColor));
				half3 hpcs = hpc * _ShadowHilightIntensity * _ShadowHilightIntensity;
				hpc = lerp(hpcs, hpc, his);

				half3 hc = TA_restriction(_SaturatedValue, hspc + hpc);
				hc = lerp(tdiff.rgb, hc, _HilightIntensity);

				tdiff.rgb = lerp(tdiff.rgb, hc, _MainLightAffect);
			#endif

			fixed4 c = tdiff;

			c.rgb *= _Color.rgb;

			#if _ALPHATEST_ON
				c.a = tdiff.a * _Color.a;
				clip (c.a - _Cutoff);
			#elif _ALPHABLEND_ON || _ALPHAPREMULTIPLY_ON
				c.a = tdiff.a * _Color.a;
			#else
				c.a = 1.0;
			#endif

			#if TA_STENCIL_FADE
				c.a = lerp(c.a, 0, (1 - _StencilFade) );
			#endif

			UNITY_APPLY_FOG(i.fogCoord, c.rgb);

			return c;
		}

#endif
