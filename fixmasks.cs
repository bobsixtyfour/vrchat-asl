// Do not load this script when building
#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using System.Text.RegularExpressions;

public class FixMask
{  /*
    
    [MenuItem("Assets/Fix Animation Masks")]
    private static void Init()
    {
        UnityEngine.Object[] selection = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.DeepAssets);
        foreach( UnityEngine.Object obj in selection )
        {
            string path = AssetDatabase.GetAssetPath( obj );
            ModelImporter mi = AssetImporter.GetAtPath(path) as ModelImporter;
 
            Type modelImporterType = typeof(ModelImporter);
 
            MethodInfo updateTransformMaskMethodInfo = modelImporterType.GetMethod("UpdateTransformMask", BindingFlags.NonPublic | BindingFlags.Static);
 
            ModelImporterClipAnimation[] clipAnimations = mi.clipAnimations;
            SerializedObject so = new SerializedObject(mi);
            SerializedProperty clips = so.FindProperty("m_ClipAnimations");
           
           AvatarMask avatarMask= AssetDatabase.LoadAssetAtPath("Assets/upperbody.mask",typeof(AvatarMask)) as AvatarMask;
            //AvatarMask avatarMask = new AvatarMask();
            avatarMask.transformCount = mi.transformPaths.Length;
            for( int i=0; i<mi.transformPaths.Length; i++ )
            {
                avatarMask.SetTransformPath(i,mi.transformPaths[i]);
                avatarMask.SetTransformActive(i,true);
            }
           
            for( int i=0; i<clipAnimations.Length; i++ )
            {
                Debug.Log(clipAnimations[i].name );
                SerializedProperty transformMaskProperty = clips.GetArrayElementAtIndex(i).FindPropertyRelative("transformMask");
                updateTransformMaskMethodInfo.Invoke(mi, new System.Object[]{avatarMask, transformMaskProperty});
                clipAnimations[i].loop=true;
                clipAnimations[i].lockRootRotation=true;
                clipAnimations[i].lockRootPositionXZ=true;
                clipAnimations[i].lockRootHeightY=true;
            }
            so.ApplyModifiedProperties();
 
            AssetDatabase.ImportAsset(path);
        }
    }
*/
    
    [MenuItem("Assets/Fix Animation Masks")]
    private static void Init()
    {
        UnityEngine.Object[] selection = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.DeepAssets);
        foreach( UnityEngine.Object obj in selection )
        {
            string path = AssetDatabase.GetAssetPath( obj );
            ModelImporter mi = AssetImporter.GetAtPath(path) as ModelImporter;
 
            Type modelImporterType = typeof(ModelImporter);
 
            MethodInfo updateTransformMaskMethodInfo = modelImporterType.GetMethod("UpdateTransformMask", BindingFlags.NonPublic | BindingFlags.Static);
 
            ModelImporterClipAnimation[] clipAnimations = mi.clipAnimations;
            SerializedObject so = new SerializedObject(mi);
            SerializedProperty clips = so.FindProperty("m_ClipAnimations");
            //AvatarMask avatarMask= AssetDatabase.LoadAssetAtPath<AvatarMask>("Assets/upperbody.mask");
            AvatarMask avatarMask = new AvatarMask();
            avatarMask.transformCount = mi.transformPaths.Length;
            for( int i=0; i<mi.transformPaths.Length; i++ )
            {
                avatarMask.SetTransformPath(i,mi.transformPaths[i]);
                avatarMask.SetTransformActive(i,true);
            }
           
            for( int i=0; i<clipAnimations.Length; i++ )
            {
                SerializedProperty transformMaskProperty = clips.GetArrayElementAtIndex(i).FindPropertyRelative("transformMask");
                updateTransformMaskMethodInfo.Invoke(mi, new System.Object[]{avatarMask, transformMaskProperty});
            }
            so.ApplyModifiedProperties();
 
            AssetDatabase.ImportAsset(path);
        }
    }
    
        static void SetAnimationImporterSettings(ModelImporter importer, string x)
    {
        //AvatarMask avatarMask= AssetDatabase.LoadAssetAtPath("Assets/upperbody.mask",typeof(AvatarMask)) as AvatarMask;
        if(x=="nana"){
            AvatarMask avatarMask= AssetDatabase.LoadAssetAtPath<AvatarMask>("Assets/upperbodynospinenohead.mask");
            var clips = importer.clipAnimations;
                    if (clips.Length == 0) clips = importer.defaultClipAnimations;
        foreach (var clip in clips) {
            if (clip.name.StartsWith("_a|")==true){
            clip.name=clip.name.Replace("_a|", "ASL-");
            }
            //clip.name=clip.name.Replace("_a|", "");

            if (clip.name.StartsWith("ASL")==false){
                clip.name="ASL-"+clip.name;
            }
            if (clip.name.StartsWith("ASL")==true){
                clip.name=clip.name.Replace("ASL", "ASL-");
            }
            if (clip.name.StartsWith("ASL--")==true){
                clip.name=clip.name.Replace("ASL--", "ASL-");
            }
           
            clip.name = Regex.Replace(clip.name, "[0-9]", "");
            clip.name=clip.name.Replace(".", "");
            clip.name=clip.name.Replace("ASL-ASL-", "ASL-");


            clip.lockRootHeightY = true;
            clip.keepOriginalPositionY = false;
            clip.heightFromFeet = true;
            //clip.loop=true;
            clip.loopTime=true;
            clip.lockRootRotation=true;
            clip.lockRootPositionXZ=true;
            clip.maskType=ClipAnimationMaskType.CreateFromThisModel;
            clip.ConfigureClipFromMask(avatarMask);
            //clip.heightOffset = -0.1f;
            importer.clipAnimations = clips;
        }
        }
        else{
            AvatarMask avatarMask= AssetDatabase.LoadAssetAtPath<AvatarMask>("Assets/upperbody.mask");
            var clips = importer.clipAnimations;
                    if (clips.Length == 0) clips = importer.defaultClipAnimations;
        foreach (var clip in clips) {
            if (clip.name.StartsWith("_a|")==true){
            clip.name=clip.name.Replace("_a|", "ASL-");
            }
            //clip.name=clip.name.Replace("_a|", "");

            if (clip.name.StartsWith("ASL")==false){
                clip.name="ASL-"+clip.name;
            }
            if (clip.name.StartsWith("ASL")==true){
                clip.name=clip.name.Replace("ASL", "ASL-");
            }
            if (clip.name.StartsWith("ASL--")==true){
                clip.name=clip.name.Replace("ASL--", "ASL-");
            }
           
            clip.name = Regex.Replace(clip.name, "[0-9]", "");
            clip.name=clip.name.Replace(".", "");
            clip.name=clip.name.Replace("ASL-ASL-", "ASL-");


            clip.lockRootHeightY = true;
            clip.keepOriginalPositionY = false;
            clip.heightFromFeet = true;
            //clip.loop=true;
            clip.loopTime=true;
            clip.lockRootRotation=true;
            clip.lockRootPositionXZ=true;
            clip.maskType=ClipAnimationMaskType.CreateFromThisModel;
            clip.ConfigureClipFromMask(avatarMask);
            //clip.heightOffset = -0.1f;
            importer.clipAnimations = clips;
        }
        }
        

/*
        Type modelImporterType = typeof(ModelImporter);
        MethodInfo updateTransformMaskMethodInfo = modelImporterType.GetMethod("UpdateTransformMask", BindingFlags.NonPublic | BindingFlags.Static);

            ModelImporterClipAnimation[] clipAnimations = importer.clipAnimations;
            SerializedObject so = new SerializedObject(importer);
            SerializedProperty clips2 = so.FindProperty("m_ClipAnimations");
            for( int i=0; i<clipAnimations.Length; i++ )
            {
                Debug.Log(clipAnimations[i].name );
                SerializedProperty transformMaskProperty = clips2.GetArrayElementAtIndex(i).FindPropertyRelative("transformMask");
                updateTransformMaskMethodInfo.Invoke(importer, new System.Object[]{avatarMask, transformMaskProperty});

            }
            */




        
    }
    [MenuItem("Assets/Set Animation Options - ybot")]
static void SetAnimationOptions()
{
    var filtered = Selection.GetFiltered(typeof(GameObject), SelectionMode.Assets);
    foreach (var go in filtered) {
        var path = AssetDatabase.GetAssetPath(go);
        var importer = AssetImporter.GetAtPath(path);
        SetAnimationImporterSettings(importer as ModelImporter, "a");
        AssetDatabase.ImportAsset(path);
    }
    Selection.activeObject = null;
}
    [MenuItem("Assets/Set Animation Options - nana")]
static void SetAnimationOptionsNana()
{
    var filtered = Selection.GetFiltered(typeof(GameObject), SelectionMode.Assets);
    foreach (var go in filtered) {
        var path = AssetDatabase.GetAssetPath(go);
        var importer = AssetImporter.GetAtPath(path);
        SetAnimationImporterSettings(importer as ModelImporter, "nana");
        AssetDatabase.ImportAsset(path);
    }
    Selection.activeObject = null;
}


}
#endif