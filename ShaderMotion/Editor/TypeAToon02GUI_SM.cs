using System;
using UnityEngine;
//using System.Linq;
//using System.Collections.Generic;

namespace UnityEditor
{

	internal class TypeAToon02GUI_SM : ShaderGUI
	{

		public enum BlendMode
		{
			Opaque,
			Cutout,
			Fade,
			Transparent
		}

		public enum RQName
		{
			FromShader,
			Geometry,
			AlphaTest,
			Transparent
		}

		public enum ZWriteMode
		{
			Off,
			On
		}

		public enum LightindMode
		{
			View,
			Light
		}

		public enum ShadowMode
		{
			IncludeInDiffuse,
			DropAsShadow
		}

		private class TA_KeyModes
		{
			public float lightingMode = 0;
			public float stencilMode = 0;
			public float hilightMode = 0;
			public float handlwShadow = 0;
		}
		TA_KeyModes keyModes = new TA_KeyModes();

		private static class Styles
		{
			//----------------------------------------------------------------------------------------------------
			public static string MotionText = "Motion ";

			public static string motionDec = "Motion Decoded RT";
			public static string motionHumanScale = "HumanScale";
			public static string motionLayer = "Layer";
			public static string motionRotationTolerance = "RotationTolerance";

			//----------------------------------------------------------------------------------------------------
			public static string RenderingSettingsText = "Rendering Settings";

			public static string renderingMode = "Rendering Mode";
			public static readonly string[] blendNames = Enum.GetNames(typeof(BlendMode));
			public static string srcBlendMode = "SrcBlend";
			public static string dstBlendMode = "DstBlend";
			public static string ColorMask = "ColorMask";
			public static string AlphaToMask = "AlphaToMask";
			public static string zwriteModeText = "ZWrite";
			public static string cullModeText = "Culling";
			public static string zTestModeText = "ZTest";
			public static GUIContent alphaCutoffText = new GUIContent("Alpha Cutoff", "Threshold for alpha cutoff");
			public static string ObjectColorText = "ObjectColor";


			//----------------------------------------------------------------------------------------------------
			public static GUIContent StencilSettingsText = new GUIContent("Stencil Settings", "check to enable the Stencil function.");

			public static GUIContent StencilModeText = new GUIContent("Stencil", "Mode selection. This is a preset. In the case of custom, it becomes the newest setting that was manually changed.");
			public static GUIContent ReferenceValueText = new GUIContent("ReferenceValue", "ReferenceValue");
			public static GUIContent ReadMaskText = new GUIContent("ReadMask", "(0-255) : Default: 255");
			public static GUIContent WriteMaskText = new GUIContent("WriteMask", "(0-255) : Default: 255");
			public static string stCompText = "ComparisonFunction";
			public static string stPassText = "PassOperation";
			public static string stFailText = "FailOperation";
			public static string stZFailText = "ZFailOperation";

			public static GUIContent FadeSttingsText = new GUIContent("FadeMask Sttings", "Specify the bit and strength to be faded.");
			public static GUIContent ReadMaskFText = new GUIContent("ReadMask", "(0-255) : Default: 255");
			public static GUIContent stFadeText = new GUIContent("Stencil Fade", "Stencil Fade");


			//----------------------------------------------------------------------------------------------------
			public static string MainColorSettingsText = "Main Color Settings";

			public static GUIContent BaseColorText = new GUIContent("BaseColor", "RGB - Color, A - Alpha : Color is used when Texture is not set.");
			public static GUIContent ShadowColorText = new GUIContent("ShadowColor", "RGB - Color, A - Alpha : Color is used when Texture is not set.");
			public static GUIContent ShadowMapText = new GUIContent("ShadowMap", "Shadow range specification. The zero side is the shadow range.");
			public static GUIContent ToonTexText = new GUIContent("Toon (Diffuse)", "size is 4 pixels or more. The zero side is the shadow range.");

			public static string LightingDirText = "Lighting Direction";
			public static GUIContent AnchorPointText = new GUIContent("AnchorPoint", "orverride the center. Invalid when set to zero,zero,zero");

			public static GUIContent NormalSphericalText = new GUIContent("Expand Spherically", "0 - 1 Expand normals into a sphere.");
			public static GUIContent SphericalCenterText = new GUIContent("Spherical Center", "Center position when expanding the normal into a sphere.");
			public static GUIContent MappingScaleText = new GUIContent("Normal Scale", "Specify the scale value.");
			public static GUIContent MappingRotationText = new GUIContent("Normal Rotation", "Specify rotation in degrees.");

			public static string MainLightAffectText = "MainLighting Affect";
			public static string AmbientLightColorText = "AmbientLight Color";
			public static string AmbientTiltText = "Ambient Tilt";
			public static string AddLightAffectText = "AddLighting Affect";
			public static string SaturatedValueText = "Saturated Value";
			public static string ShadowAffectText = "Shadow Affect";

			public static string SystemShadowAffectText = "SystemShadow Affect";
			public static string AddSystemShadowAffectText = "AddSystemShadow Affect";
			public static string HandlwShadowText = "Handl Shadow";
			public static GUIContent SystemShadowColorTexText = new GUIContent("SystemShadow Color", "Shadow range specification. The zero side is the shadow range.");
			public static string SystemShadowColorText = "SystemShadow Color";

			//----------------------------------------------------------------------------------------------------
			public static GUIContent HilightSettingsText = new GUIContent("Hilight Settings", "check to enable the hilight function.");

			public static GUIContent HilightMapText = new GUIContent("Hilight Map", "RGB - Color, A - Range specification : Color is used when Texture is not set.");
			public static GUIContent ToonHilightTexText = new GUIContent("Toon (Hilight)", "size is 4 pixels or more. The zero side is the spred color range.");
			public static string HilightIntensityText = "Hilight Intensity";
			public static string ShadowHilightIntensityText = "Hilight in Shadow";
			public static string HilightHardnessText = "Hilight Hardness";
			public static string HilightPowerText = "Hilight Power";
			public static string HilightSpreadText = "Color Spread ";

			//----------------------------------------------------------------------------------------------------
			public static GUIContent EdgeSettingsText = new GUIContent("Outline Edge Settings", "check to enable the Outline edge function.");

			public static GUIContent edgeModeText = new GUIContent("Enabled", "check to enable the Outline edge function.");
			public static string EdgeColorText = "Edge Color";
			public static GUIContent BCmixMethodText = new GUIContent("BaseColorMixing", "Multiply or Add");
			public static GUIContent BaseTexMixText = new GUIContent("Mixing strength", "BaseColorMixing");
			public static GUIContent SCmixMethodText = new GUIContent("ShadowColorMixing", "Multiply or Add");
			public static GUIContent ShadowTexMixText = new GUIContent("Mixing strength", "ShadowColorMixing");
			public static string EdgeThicknessText = "Edge Thickness";
			public static string vc2edgeModeText = "VColor(R) to Edge";

		}

		//----------------------------------------------------------------------------------------------------
		MaterialProperty motionDec = null;
		MaterialProperty motionHumanScale = null;
		MaterialProperty motionLayer = null;
		MaterialProperty motionRotationTolerance = null;

		//----------------------------------------------------------------------------------------------------
		MaterialProperty blendMode = null;

		MaterialProperty srcBlend = null;
		MaterialProperty dstBlend = null;
		MaterialProperty ColorMask = null;
		MaterialProperty AlphaToMask = null;
		MaterialProperty zWriteMode = null;
		MaterialProperty cullMode = null;
		MaterialProperty zTestMode = null;
		MaterialProperty alphaCutoff = null;

		MaterialProperty ObjectColor = null;

		//----------------------------------------------------------------------------------------------------
		MaterialProperty stencilMode = null;
		MaterialProperty ReferenceValue = null;
		MaterialProperty ReadMask = null;
		MaterialProperty WriteMask = null;
		MaterialProperty stComp = null;
		MaterialProperty stPass = null;
		MaterialProperty stFail = null;
		MaterialProperty stZFail = null;
		MaterialProperty stFade = null;

		MaterialProperty stComp_c = null;
		MaterialProperty stPass_c = null;
		MaterialProperty stFail_c = null;
		MaterialProperty stZFail_c = null;

		MaterialProperty ReadMaskF = null;

		//----------------------------------------------------------------------------------------------------
		MaterialProperty BaseColorTex = null;
		MaterialProperty BaseColor = null;
		MaterialProperty IsBaseColor = null;
		MaterialProperty ShadowColorTex = null;
		MaterialProperty ShadowColor = null;
		MaterialProperty IsShadowColor = null;
		MaterialProperty ShadowMapTex = null;
		MaterialProperty ToonTex = null;

		MaterialProperty LightingDir = null;
		MaterialProperty AnchorPoint = null;

		MaterialProperty NormalSpherical = null;
		MaterialProperty SphericalCenter = null;
		MaterialProperty MappingScale = null;
		MaterialProperty MappingRotation = null;

		MaterialProperty MainLightAffect = null;
		MaterialProperty AmbientLightColor = null;
		MaterialProperty AmbientTilt = null;
		MaterialProperty AddLightAffect = null;
		MaterialProperty SaturatedValue = null;
		MaterialProperty ShadowAffect = null;

		MaterialProperty SystemShadowAffect = null;
		MaterialProperty AddSystemShadowAffect = null;
		MaterialProperty HandleShadow = null;
		MaterialProperty SystemShadowColorTex = null;
		MaterialProperty SystemShadowColor = null;
		MaterialProperty IsSystemShadowColor = null;

		//----------------------------------------------------------------------------------------------------
		MaterialProperty hilightMode = null;

		MaterialProperty HilightMap = null;
		MaterialProperty HilightColor = null;
		MaterialProperty IsHilightColor = null;
		MaterialProperty ToonHilightTex = null;
		MaterialProperty HilightIntensity = null;
		MaterialProperty ShadowHilightIntensity = null;
		MaterialProperty HilightHardness = null;
		MaterialProperty HilightPower = null;
		MaterialProperty HilightSpread = null;

		//----------------------------------------------------------------------------------------------------
		MaterialProperty EdgeColor = null;
		MaterialProperty BaseTexMix = null;
		MaterialProperty BCmixMethod = null;
		MaterialProperty ShadowTexMix = null;
		MaterialProperty SCmixMethod = null;
		MaterialProperty EdgeThickness = null;
		MaterialProperty VC2Edge = null;

		//----------------------------------------------------------------------------------------------------

		MaterialEditor m_MaterialEditor;

		bool m_FirstTimeApply = true;

		int rq = -1;

		bool IsStencilSettings = false;
		bool IsStencilFade = false;
		bool IsHilightSettings = false;
		bool IsOutlineSettings = false;

		string[] CMChannel; 
		bool[] In_CM;

		public void FindProperties(MaterialProperty[] props)
		{

			//----------------------------------------------------------------------------------------------------
			motionDec = FindProperty("_MotionDec", props);
			motionHumanScale = FindProperty("_HumanScale", props);
			motionLayer = FindProperty("_Layer", props);
			motionRotationTolerance = FindProperty("_RotationTolerance", props);

			//----------------------------------------------------------------------------------------------------
			blendMode = FindProperty("_blendMode", props);

			cullMode = FindProperty("_CullMode", props);
			zTestMode = FindProperty("_ZTest", props);
			zWriteMode = FindProperty("_ZWrite", props);

			ObjectColor = FindProperty("_Color", props);

			alphaCutoff = FindProperty("_Cutoff", props);

			ColorMask = FindProperty("_ColorMask", props);
			CMChannel = new string[4]{ " A", " B", " G", " R" };

			AlphaToMask = FindProperty("_AlphaToMask", props);
			In_CM = new bool[4] {true,true,true,true };

			srcBlend = FindProperty("_SrcBlend", props);
			dstBlend = FindProperty("_DstBlend", props);

			//----------------------------------------------------------------------------------------------------
			BaseColor = FindProperty("_BaseColor", props);
			IsBaseColor = FindProperty("_IsBaseColor", props);
			BaseColorTex = FindProperty("_BaseTex", props);
			ShadowColor = FindProperty("_ShadowColor", props);
			IsShadowColor = FindProperty("_IsShadowColor", props);
			ShadowColorTex = FindProperty("_ShadowTex", props);
			ShadowMapTex = FindProperty("_ShadowmapTex", props);
			ToonTex = FindProperty("_ToonTex", props);

			LightingDir = FindProperty("_LightingDir", props);
			if (LightingDir.floatValue == (int)LightindMode.View)
				keyModes.lightingMode = (int)LightindMode.View;
			else
				keyModes.lightingMode = (int)LightindMode.Light;

			AnchorPoint = FindProperty("_AnchorPoint", props);

			NormalSpherical = FindProperty("_NormalSpherical", props);
			SphericalCenter = FindProperty("_SphericalCenter", props);
			MappingScale = FindProperty("_MappingScale", props);
			MappingRotation = FindProperty("_MappingRotation", props);

			MainLightAffect = FindProperty("_MainLightAffect", props);
			AmbientLightColor = FindProperty("_AmbientLightColor", props);
			AmbientTilt = FindProperty("_AmbientTilt", props);
			AddLightAffect = FindProperty("_AddLightAffect", props);
			SaturatedValue = FindProperty("_SaturatedValue", props);
			ShadowAffect = FindProperty("_ShadowAffect", props);

			SystemShadowAffect = FindProperty("_SystemShadowAffect", props);
			AddSystemShadowAffect = FindProperty("_AddSystemShadowAffect", props);
			HandleShadow = FindProperty("_HandleShadow", props);
			if (HandleShadow.floatValue == 0)
				keyModes.handlwShadow = 0;
			else
				keyModes.handlwShadow = 1;
			SystemShadowColorTex = FindProperty("_SystemShadowColorTex", props);
			SystemShadowColor = FindProperty("_SystemShadowColor", props);
			IsSystemShadowColor = FindProperty("_IsSystemShadowColor", props);


			//----------------------------------------------------------------------------------------------------
			stencilMode = FindProperty("_StencilMode", props);
			FindPropertiesStencil(props);
			if (stencilMode.floatValue == 1)
			{
				IsStencilSettings = true;
			}

			//----------------------------------------------------------------------------------------------------
			hilightMode = FindProperty("_hilightMode", props);
			if (hilightMode.floatValue == 1)
			{
				IsHilightSettings = true;
				FindPropertiesHilight(props);
				keyModes.hilightMode = 1;
			}

			//----------------------------------------------------------------------------------------------------
			FindPropertiesOutline(props);
		}
		public void FindPropertiesStencil(MaterialProperty[] props)
		{
			ReferenceValue = FindProperty("_RefV", props);
			ReadMask = FindProperty("_ReadMask", props);
			WriteMask = FindProperty("_WriteMask", props);
			stComp = FindProperty("_stComp", props);
			stPass = FindProperty("_stPass", props);
			stFail = FindProperty("_stFail", props);
			stZFail = FindProperty("_stZFail", props);

			stComp_c = FindProperty("_stComp_c", props);
			stPass_c = FindProperty("_stPass_c", props);
			stFail_c = FindProperty("_stFail_c", props);
			stZFail_c = FindProperty("_stZFail_c", props);


			try
			{
				stFade = FindProperty("_StencilFade", props);
			}
			catch
			{
				IsStencilFade = false;
				keyModes.stencilMode = 0;
				return;
			}

			IsStencilFade = true;
			keyModes.stencilMode = 1;
			stFade = FindProperty("_StencilFade", props);
			ReadMaskF = FindProperty("_ReadMask_f", props);
		}

		public void FindPropertiesHilight(MaterialProperty[] props)
		{
			HilightMap = FindProperty("_HilightmapTex", props);
			HilightColor = FindProperty("_HilightColor", props);
			IsHilightColor = FindProperty("_IsHilightColor", props);
			ToonHilightTex = FindProperty("_ToonHilightTex", props);
			HilightIntensity = FindProperty("_HilightIntensity", props);
			ShadowHilightIntensity = FindProperty("_ShadowHilightIntensity", props);
			HilightHardness = FindProperty("_HilightHardness", props);
			HilightPower = FindProperty("_HilightPower", props);
			HilightSpread = FindProperty("_HilightSpread", props);
		}

		public void FindPropertiesOutline(MaterialProperty[] props)
		{
			try
			{
				FindProperty("_vc2edge", props);
			}
			catch
			{
				IsOutlineSettings = false;
				return;
			}

			IsOutlineSettings = true;
			EdgeColor = FindProperty("_EdgeColor", props);
			BaseTexMix = FindProperty("_BaseTexMix", props);
			BCmixMethod = FindProperty("_BCmixMethod", props);
			ShadowTexMix = FindProperty("_ShadowTexMix", props);
			SCmixMethod = FindProperty("_SCmixMethod", props);
			EdgeThickness = FindProperty("_EdgeThickness", props);
			VC2Edge = FindProperty("_vc2edge", props);
		}

		public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] props)
        {
			FindProperties(props);

			m_MaterialEditor = materialEditor;
            Material material = materialEditor.target as Material;

			if (m_FirstTimeApply)
            {
				int renderQueue = material.renderQueue;
				MaterialChanged(material, keyModes);
				material.renderQueue = renderQueue;

				m_FirstTimeApply = false;
            }

			ShaderPropertiesGUI(material, props);
        }

        public void ShaderPropertiesGUI(Material material, MaterialProperty[] props)
        {
            EditorGUIUtility.labelWidth = 0f;

			//------------------------------------------------------------------------------------------
			EditorGUI.BeginChangeCheck();
            {
				//------------------------------------------------------------------------------------------
				GUILayout.Label(Styles.MotionText, EditorStyles.boldLabel);
				DoMotionSettingArea(material);

				//------------------------------------------------------------------------------------------
				GUILayout.Label(Styles.RenderingSettingsText, EditorStyles.boldLabel);
				DoRenderSettingArea(material);

				//------------------------------------------------------------------------------------------
				EditorGUILayout.Separator();
				IsStencilSettings = EditorGUILayout.BeginToggleGroup(Styles.StencilSettingsText, IsStencilSettings);
				if (IsStencilSettings)
				{
					stencilMode.floatValue = 1;
					SetupStencil();
					DoStencilArea(material);
				}
				else
				{
					stencilMode.floatValue = 0;
					SetupStencil();
				}
				EditorGUILayout.EndToggleGroup();

				//------------------------------------------------------------------------------------------
				EditorGUILayout.Separator();
				GUILayout.Label(Styles.MainColorSettingsText, EditorStyles.boldLabel);
				DoBaseColorArea(material);

                //------------------------------------------------------------------------------------------
                EditorGUILayout.Separator();
				IsHilightSettings = EditorGUILayout.BeginToggleGroup(Styles.HilightSettingsText, IsHilightSettings);
				if (IsHilightSettings)
				{
					hilightMode.floatValue = 1;
					FindPropertiesHilight(props);
					DoHilightArea(material);
					GUILayout.Space(8);
				}
				else
				{
					hilightMode.floatValue = 0;
				}

				keyModes.hilightMode = hilightMode.floatValue;

				EditorGUILayout.EndToggleGroup();

				//------------------------------------------------------------------------------------------
				if (IsOutlineSettings)
                {
					GUILayout.Label(Styles.EdgeSettingsText, EditorStyles.boldLabel);
                    DoEdgeArea(material);

                }
			}
			//------------------------------------------------------------------------------------------
			if (EditorGUI.EndChangeCheck())
            {
				foreach (var obj in blendMode.targets)
                    MaterialChanged((Material)obj, keyModes);
			}
			material.renderQueue = rq;
		}

		void DoStencilArea(Material material)
		{

			m_MaterialEditor.ShaderProperty(ReferenceValue ,Styles.ReferenceValueText);
			m_MaterialEditor.ShaderProperty(ReadMask, Styles.ReadMaskText);
			m_MaterialEditor.ShaderProperty(WriteMask, Styles.WriteMaskText);

			m_MaterialEditor.ShaderProperty(stComp, Styles.stCompText);
			m_MaterialEditor.ShaderProperty(stPass, Styles.stPassText);
			m_MaterialEditor.ShaderProperty(stFail, Styles.stFailText);
			m_MaterialEditor.ShaderProperty(stZFail, Styles.stZFailText);

			stComp_c.floatValue = stComp.floatValue;
			stPass_c.floatValue = stPass.floatValue;
			stFail_c.floatValue = stFail.floatValue;
			stZFail_c.floatValue = stZFail.floatValue;

			if(IsStencilFade)
			{
				keyModes.stencilMode = 1;
				GUILayout.Space(4);
				GUILayout.Label(Styles.FadeSttingsText, EditorStyles.boldLabel);

				int rmf = (int)ReadMaskF.floatValue;

				{
					EditorGUI.BeginChangeCheck();
					{
						rmf = EditorGUILayout.IntField(Styles.ReadMaskFText, rmf);
						if (rmf < 0) { rmf = 0; }
						else if (rmf > 255) { rmf = 255; }
					}
					if (EditorGUI.EndChangeCheck())
					{
						ReadMaskF.floatValue = rmf;
					}
					m_MaterialEditor.ShaderProperty(stFade, Styles.stFadeText);
				}
			}
			else
			{
				keyModes.stencilMode = 0;
			}
		}

		void SetupStencil()
		{
			if(stencilMode.floatValue == 1)
			{
				stComp.floatValue = stComp_c.floatValue;
				stPass.floatValue = stPass_c.floatValue;
				stFail.floatValue = stFail_c.floatValue;
				stZFail.floatValue = stZFail_c.floatValue;
			}
			else
			{
				stComp.floatValue = (int)UnityEngine.Rendering.CompareFunction.Always;
				stPass.floatValue = (int)UnityEngine.Rendering.StencilOp.Keep;
				stFail.floatValue = (int)UnityEngine.Rendering.StencilOp.Keep;
				stZFail.floatValue = (int)UnityEngine.Rendering.StencilOp.Keep;
			}

		}

		
		public override void AssignNewShaderToMaterial(Material material, Shader oldShader, Shader newShader)
        {
            base.AssignNewShaderToMaterial(material, oldShader, newShader);

            if (oldShader == null)
            {
                SetupMaterialWithBlendMode(material, (BlendMode)material.GetFloat("_blendMode"));
				return;
            }

			if (newShader.name.Contains("vrc"))
			{
				BlendMode blendMode = BlendMode.Opaque;
				UnityEngine.Rendering.BlendMode SrcBlend = UnityEngine.Rendering.BlendMode.One;
				UnityEngine.Rendering.BlendMode DstBlend = UnityEngine.Rendering.BlendMode.Zero;

				if (newShader.name.Contains("Cutout") || newShader.name.Contains("cutout"))
				{
					blendMode = BlendMode.Cutout;
					SrcBlend = UnityEngine.Rendering.BlendMode.SrcAlpha;
					DstBlend = UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha;
					material.SetFloat("_ColorMask", 14);
					material.SetFloat("_AlphaToMask", 1);
				}
				else if (newShader.name.Contains("Fade") || newShader.name.Contains("fade"))
				{
					blendMode = BlendMode.Fade;
					SrcBlend = UnityEngine.Rendering.BlendMode.SrcAlpha;
					DstBlend = UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha;
				}
				else if (newShader.name.Contains("Transparent") || newShader.name.Contains("transparent"))
				{
					blendMode = BlendMode.Transparent;
					SrcBlend = UnityEngine.Rendering.BlendMode.SrcAlpha;
					DstBlend = UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha;
				}
				material.SetFloat("_blendMode", (float)blendMode);
				material.SetFloat("_SrcBlend", (float)SrcBlend);
				material.SetFloat("_DstBlend", (float)DstBlend);

				MaterialChanged(material, keyModes);

				material.renderQueue = -1;
			}
			else
			{
				MaterialChanged(material, keyModes);
			}

		}
		

		public static void SetupMaterialWithBlendMode(Material material, BlendMode blendMode)
        {
            switch (blendMode)
            {
                case BlendMode.Opaque:
                    material.SetOverrideTag("RenderType", "");
                    material.SetOverrideTag("IgnoreProjector", "");
                    material.SetOverrideTag("ForceNoShadowCasting", "");
                    material.DisableKeyword("_ALPHATEST_ON");
                    material.DisableKeyword("_ALPHABLEND_ON");
                    material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Geometry;
                    break;
                case BlendMode.Cutout:
                    material.SetOverrideTag("RenderType", "TransparentCutout");
                    material.SetOverrideTag("IgnoreProjector", "true");
                    material.SetOverrideTag("ForceNoShadowCasting", "true");
                    material.EnableKeyword("_ALPHATEST_ON");
                    material.DisableKeyword("_ALPHABLEND_ON");
                    material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.AlphaTest;
                    break;
                case BlendMode.Fade:
                    material.SetOverrideTag("RenderType", "Transparent");
                    material.SetOverrideTag("IgnoreProjector", "true");
                    material.SetOverrideTag("ForceNoShadowCasting", "true");
                    material.DisableKeyword("_ALPHATEST_ON");
                    material.EnableKeyword("_ALPHABLEND_ON");
                    material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
                    break;
                case BlendMode.Transparent:
                    material.SetOverrideTag("RenderType", "Transparent");
					material.SetOverrideTag("IgnoreProjector", "true");
					material.SetOverrideTag("ForceNoShadowCasting", "true");
                    material.DisableKeyword("_ALPHATEST_ON");
                    material.DisableKeyword("_ALPHABLEND_ON");
                    material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                    material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
                    break;
            }
        }


		void DoMotionSettingArea(Material material)
		{
			m_MaterialEditor.ShaderProperty(motionDec, Styles.motionDec);
			m_MaterialEditor.ShaderProperty(motionHumanScale, Styles.motionHumanScale);
			m_MaterialEditor.ShaderProperty(motionLayer, Styles.motionLayer);
			m_MaterialEditor.ShaderProperty(motionRotationTolerance, Styles.motionRotationTolerance);
		}

		void DoRenderSettingArea(Material material)
        {
			m_MaterialEditor.ShaderProperty(blendMode, Styles.renderingMode);
			m_MaterialEditor.RenderQueueField();
			rq = material.renderQueue;

			if ((BlendMode)material.GetFloat("_blendMode") != BlendMode.Opaque)
			{
				m_MaterialEditor.ShaderProperty(srcBlend, Styles.srcBlendMode);
				m_MaterialEditor.ShaderProperty(dstBlend, Styles.dstBlendMode);
				if ((BlendMode)material.GetFloat("_blendMode") == BlendMode.Cutout)
				{
					m_MaterialEditor.ShaderProperty(alphaCutoff, Styles.alphaCutoffText.text);
				}

				int o_cm = 0;

				GUILayout.Label("ColorMask");
				{
					GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true), GUILayout.MinWidth(218));
					{
						GUILayout.Space(16);
						for (int i = 3; i > -1; i--)
						{
							int p = (int)Mathf.Pow(2, i);
							p = p == 0 ? 1 : p;
							int icm = (int)ColorMask.floatValue & p;
							In_CM[i] = icm > 0;
							In_CM[i] = GUILayout.Toggle(In_CM[i], CMChannel[i]);
							o_cm += p * (In_CM[i] ? 1 : 0);
						}
					}
					GUILayout.EndHorizontal();
				}
				ColorMask.floatValue = o_cm;

				m_MaterialEditor.ShaderProperty(AlphaToMask, Styles.AlphaToMask);

			}
			m_MaterialEditor.ShaderProperty(zWriteMode, Styles.zwriteModeText);
			m_MaterialEditor.ShaderProperty(cullMode, Styles.cullModeText);
			m_MaterialEditor.ShaderProperty(zTestMode, Styles.zTestModeText);

			m_MaterialEditor.ColorProperty(ObjectColor, Styles.ObjectColorText);
		}

        void DoBaseColorArea(Material material)
        {
            GUILayout.Space(4);
            DrawTexorColorProp(material, "_BaseTex", Styles.BaseColorText, BaseColorTex, BaseColor, IsBaseColor);
            DrawTexorColorProp(material, "_ShadowTex", Styles.ShadowColorText, ShadowColorTex, ShadowColor, IsShadowColor);
            m_MaterialEditor.TexturePropertySingleLine(Styles.ShadowMapText, ShadowMapTex);
            m_MaterialEditor.TexturePropertySingleLine( Styles.ToonTexText, ToonTex);

			m_MaterialEditor.ShaderProperty(LightingDir, Styles.LightingDirText);
			keyModes.lightingMode = LightingDir.floatValue;

			GUILayout.Space(4);
			DoDrawVector3Field(AnchorPoint, Styles.AnchorPointText);

			GUILayout.Space(4);
			m_MaterialEditor.ShaderProperty(NormalSpherical, Styles.NormalSphericalText);
			DoDrawVector3Field(SphericalCenter, Styles.SphericalCenterText);

			GUILayout.Space(4);
            DoDrawVector3Field(MappingScale,Styles.MappingScaleText);

            GUILayout.Space(4);
            DoDrawVector2Field(MappingRotation, Styles.MappingRotationText);

            GUILayout.Space(4);
            m_MaterialEditor.RangeProperty(MainLightAffect, Styles.MainLightAffectText);
			m_MaterialEditor.RangeProperty(AmbientLightColor, Styles.AmbientLightColorText);
			m_MaterialEditor.RangeProperty(AmbientTilt, Styles.AmbientTiltText);
			m_MaterialEditor.RangeProperty(AddLightAffect, Styles.AddLightAffectText);
			m_MaterialEditor.RangeProperty(SaturatedValue, Styles.SaturatedValueText);
			m_MaterialEditor.RangeProperty(ShadowAffect, Styles.ShadowAffectText);

			GUILayout.Space(4);
			m_MaterialEditor.RangeProperty(SystemShadowAffect, Styles.SystemShadowAffectText);
			m_MaterialEditor.RangeProperty(AddSystemShadowAffect, Styles.AddSystemShadowAffectText);
			m_MaterialEditor.ShaderProperty(HandleShadow, Styles.HandlwShadowText);
			keyModes.handlwShadow = HandleShadow.floatValue;
			if(HandleShadow.floatValue == 1)
			{
				DrawTexorColorProp(material, "_SystemShadowColorTex", Styles.SystemShadowColorTexText, SystemShadowColorTex, SystemShadowColor, IsSystemShadowColor);
			}

			GUILayout.Space(4);

        }
        void DoDrawVector2Field(MaterialProperty prop, GUIContent content)
        {
            Vector2 v = prop.vectorValue;

            EditorGUI.BeginChangeCheck();
			v = EditorGUILayout.Vector2Field(content, v);
            if (EditorGUI.EndChangeCheck())
            {
                prop.vectorValue = v;
            }
        }

        void DoDrawVector3Field(MaterialProperty prop, GUIContent content)
        {
            Vector3 v = prop.vectorValue;

			EditorGUI.BeginChangeCheck();
			v = EditorGUILayout.Vector3Field(content, v);

            if (EditorGUI.EndChangeCheck())
            {
				prop.vectorValue = v;
            }

        }


        void DoHilightArea(Material material)
        {

            if (hilightMode.floatValue >= 1)
            {
                DrawTexorColorProp(material, "_HilightmapTex", Styles.HilightMapText, HilightMap, HilightColor, IsHilightColor);
                m_MaterialEditor.TexturePropertySingleLine(Styles.ToonHilightTexText, ToonHilightTex);
                GUILayout.Space(8);
                m_MaterialEditor.RangeProperty(HilightIntensity, Styles.HilightIntensityText);
                m_MaterialEditor.RangeProperty(ShadowHilightIntensity, Styles.ShadowHilightIntensityText);
                m_MaterialEditor.RangeProperty(HilightHardness, Styles.HilightHardnessText);
                m_MaterialEditor.RangeProperty(HilightPower, Styles.HilightPowerText);
                m_MaterialEditor.RangeProperty(HilightSpread, Styles.HilightSpreadText);
			}

			GUILayout.Space(8);

        }

        void DrawTexorColorProp(Material material, string name, GUIContent content, MaterialProperty prop, MaterialProperty colorProp, MaterialProperty isProp)
        {
            if (material.GetTexture(name))
            {
                m_MaterialEditor.TexturePropertySingleLine(content, prop);
                isProp.floatValue = 0;
            }
            else
            {
                m_MaterialEditor.TexturePropertySingleLine(content, prop, colorProp);
                isProp.floatValue = 1;
            }
        }

        void DoEdgeArea(Material material)
        {
			GUILayout.Space(4);
			m_MaterialEditor.ColorProperty(EdgeColor, Styles.EdgeColorText);
            GUILayout.Space(4);
            m_MaterialEditor.ShaderProperty(BCmixMethod, Styles.BCmixMethodText);
            if(BCmixMethod.floatValue > 0)
            {
                m_MaterialEditor.ShaderProperty(BaseTexMix, Styles.BaseTexMixText);
            }
            GUILayout.Space(4);
            m_MaterialEditor.ShaderProperty(SCmixMethod, Styles.SCmixMethodText);
            if (SCmixMethod.floatValue > 0)
            {
                m_MaterialEditor.ShaderProperty(ShadowTexMix, Styles.ShadowTexMixText);
            }
            GUILayout.Space(4);
            m_MaterialEditor.RangeProperty(EdgeThickness, Styles.EdgeThicknessText);
            m_MaterialEditor.ShaderProperty(VC2Edge, Styles.vc2edgeModeText);

            GUILayout.Space(4);
        }

		static void MaterialChanged(Material material, TA_KeyModes keyModes)
        {
			SetupMaterialWithBlendMode(material, (BlendMode)material.GetFloat("_blendMode"));

            SetMaterialKeywords(material, keyModes);

        }

        static void SetMaterialKeywords(Material material, TA_KeyModes keyModes)
        {
			//if (keyModes.lightingMode == (int)LightindMode.Light) SetKeyword(material, "VIEWLIGHTING_OFF", true);
			//else SetKeyword(material, "VIEWLIGHTING_OFF", false);

			if (keyModes.hilightMode == 1) SetKeyword(material, "HILIGHT_ENABLED", true);
			else SetKeyword(material, "HILIGHT_ENABLED", false);

			if (keyModes.stencilMode == 1) SetKeyword(material, "TA_STENCIL_FADE", true);
			else SetKeyword(material, "TA_STENCIL_FADE", false);

			if (keyModes.handlwShadow == 1) SetKeyword(material, "DROPSHADOW", true);
			else SetKeyword(material, "DROPSHADOW", false);
		}
		static void SetKeyword(Material m, string keyword, bool state)
        {
            if (state)
                m.EnableKeyword(keyword);
            else
                m.DisableKeyword(keyword);
        }

    }
}

