#ifndef TYPEA_EDGE_INCLUDED
#define TYPEA_EDGE_INCLUDED

#include "TypeA2Function.cginc"

		struct VertexOutForwardBaseEdge
		{
			float4	pos					:	SV_POSITION;
			float2	tex					:	TEXCOORD0;
			fixed3	pointLightColor		:	TEXCOORD1;
			half4	ambientOrLightmapUV	:	TEXCOORD2;
			float4	posWorld			:	TEXCOORD3;	//xyz:posWorld / w:clip viewDir z
			half4	normalWorld			:	TEXCOORD4;
			half4	mixValue			:	TEXCOORD5;
			UNITY_SHADOW_COORDS(6)
			UNITY_FOG_COORDS(7)
		};


		VertexOutForwardBaseEdge vertForwardBaseEdge(TA_VertexInput v)
		{
		    VertexOutForwardBaseEdge o;
		    UNITY_INITIALIZE_OUTPUT(VertexOutForwardBaseEdge, o);
			UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

			float4 iv = float4(v.vertex.xyz, 1.0);
			o.posWorld.xyz = TAPOS_O2W_I4(iv).xyz;
			o.normalWorld = half4((o.posWorld - TA_OBJCENTER), 1.0);
			
			o.pointLightColor = 0;
			#ifdef UNITY_SHOULD_SAMPLE_SH
				#ifdef VERTEXLIGHT_ON
					o.pointLightColor = TA_Shade4PointLights (	unity_4LightPosX0, unity_4LightPosY0, unity_4LightPosZ0,
											unity_LightColor[0].rgb, unity_LightColor[1].rgb, unity_LightColor[2].rgb, unity_LightColor[3].rgb,
											unity_4LightAtten0, o.posWorld.xyz, o.normalWorld.xyz	);
					o.pointLightColor = TA_restriction(_SaturatedValue, o.pointLightColor);
				#endif
			#endif
			o.ambientOrLightmapUV.rgb = TA_VertexGIForward(o.posWorld, o.normalWorld);
			
			float vcr = v.color.r;
			vcr = lerp(1.0, vcr, _vc2edge);

			o.pos = TAPOS_W2V_I3(o.posWorld.xyz);
			half3 n = TANOR_O2V(v.normal);

			half3 viewDirProj = mul((float3x3)UNITY_MATRIX_P, o.pos.xyz);
			o.posWorld.w = sign(viewDirProj.z);
			
			half2 ln = normalize(n.xy);
			float ft = lerp(1.0, 8.0, (ta_fov / 170));
			float lz = lerp(0.075, 1.25, min(3.0, -o.pos.z) * 0.3);
			o.pos.xy += ln * _EdgeThickness * vcr * ft * lz * 0.001;
			o.pos = TAPOS_V2C_I3(o.pos.xyz);
			o.pos.z -= 0.002 * _ProjectionParams.y;

			o.tex = TA_TexCoords(v).xy;

			fixed bcm = step(1, _BCmixMethod) * step(_BCmixMethod, 1);
			fixed bca = step(2, _BCmixMethod) * step(_BCmixMethod, 2);
			fixed scm = step(1, _SCmixMethod) * step(_SCmixMethod, 1);
			fixed sca = step(2, _SCmixMethod) * step(_SCmixMethod, 2);

			o.mixValue.x = bcm * _BaseTexMix;
			o.mixValue.y = bca * _BaseTexMix;
			o.mixValue.z = scm * _ShadowTexMix;
			o.mixValue.w = sca * _ShadowTexMix;

			UNITY_TRANSFER_SHADOW(o, v.uv1);
			UNITY_TRANSFER_FOG(o, o.pos);

			return o;
		}

		fixed4 fragForwardBaseEdge(VertexOutForwardBaseEdge i,fixed vf : VFACE) : SV_Target
		{
			TA_COLOR_WHITE(TAC_w)
			TA_COLOR_BLACK(TAC_b)
			
			TA_LIGHT_ATTENUATION(atten, shadow, i, i.posWorld.xyz);
			atten = min(_SaturatedValue, atten);
			shadow = shadow * min(1, atten);
			half sa = lerp(1, shadow, _SystemShadowAffect);
			half sa_i = 1 - sa;

			half3 shd = i.ambientOrLightmapUV.rgb;
			#if UNITY_SHOULD_SAMPLE_SH
				shd = TA_ShadeSHPerPixel (i.normalWorld, shd, i.posWorld.xyz);
			#endif
			shd = TA_restriction(_SaturatedValue , shd);
			half shl = TA_Luminance(shd);
			shd = lerp(shl, shd, _AmbientLightColor);

			half3 lc = _LightColor0.rgb;
			lc = TA_restriction(_SaturatedValue, lc);
			lc *= (_SaturatedValue - shl) / _SaturatedValue;
			half lcl = TA_Luminance(lc);


			half4 tex = tex2D(_BaseTex,i.tex.xy);
			tex = lerp(tex, _BaseColor, _IsBaseColor);
			half4 tex_s = tex2D(_ShadowTex, i.tex.xy);
			tex_s = lerp(tex_s, _ShadowColor, _IsShadowColor);

			fixed4 ec = _EdgeColor;
			
			half3 bcmix_m = lerp(TAC_w, tex.rgb, i.mixValue.x);
			half3 bcmix_a = tex.rgb * i.mixValue.y;
			half3 scmix_m = lerp(TAC_w, tex_s.rgb, i.mixValue.z);
			half3 scmix_a = tex_s.rgb * i.mixValue.w;

			ec.rgb = _EdgeColor.rgb * bcmix_m * scmix_m + bcmix_a + scmix_a;
			ec.rgb = TA_restriction(_SaturatedValue, ec.rgb);

			fixed4 c;
			c.rgb = ec.rgb * _Color.rgb;
			c.rgb = lerp(c.rgb, c.rgb * (lc + shd), _MainLightAffect);
			c.rgb += lerp(c.rgb, c.rgb * i.pointLightColor, _AddLightAffect);

			#if _ALPHATEST_ON
				c.a = _Color.a * _EdgeColor.a;
				clip ( c.a - _Cutoff);
			#elif _ALPHABLEND_ON || _ALPHAPREMULTIPLY_ON
				c.a = _Color.a * _EdgeColor.a;
			#else
				c.a = 1.0;
			#endif

			#if TA_STENCIL_FADE
				c.a = lerp(c.a, 0, (1 - _StencilFade));
			#endif

			UNITY_APPLY_FOG(i.fogCoord, c);

			return c;
		}

#endif
