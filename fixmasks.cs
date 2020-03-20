//saves you from agonizing manual clicking "Fix Mask" on each user-created clip,
//when you have updated/edited the original FBX changing the skeleton hierarchy
 
//drop this in your Scripts/Editor folder,
//select FBX's and right click context menu Fix Animation Masks
//tested on Unity 4.7
 
//minor update, sets all transforms of the avatarMask to active (assuming you are just using 'Mask Definition Create From This Model' with all transforms active (Default behavior)
 
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
 
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
    
        static void SetAnimationImporterSettings(ModelImporter importer)
    {
        //AvatarMask avatarMask= AssetDatabase.LoadAssetAtPath("Assets/upperbody.mask",typeof(AvatarMask)) as AvatarMask;
        AvatarMask avatarMask= AssetDatabase.LoadAssetAtPath<AvatarMask>("Assets/upperbody.mask");
        var clips = importer.clipAnimations;

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


        if (clips.Length == 0) clips = importer.defaultClipAnimations;
        foreach (var clip in clips) {
            
            if (clip.name.StartsWith("ASL")==false){
            clip.name="ASL-"+clip.name;
            }
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
        }

        importer.clipAnimations = clips;
    }
    [MenuItem("Assets/Set Animation Options")]
static void SetAnimationOptions()
{
    var filtered = Selection.GetFiltered(typeof(GameObject), SelectionMode.Assets);
    foreach (var go in filtered) {
        var path = AssetDatabase.GetAssetPath(go);
        var importer = AssetImporter.GetAtPath(path);
        SetAnimationImporterSettings(importer as ModelImporter);
        AssetDatabase.ImportAsset(path);
    }
    Selection.activeObject = null;
}
}