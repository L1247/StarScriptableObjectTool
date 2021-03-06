﻿using System.IO;
using UnityEditor;
using UnityEngine;

public static class ScriptableObjectUtility
{
        /// <summary>
        //	This makes it easy to create, name and place unique new ScriptableObject asset files.
        /// </summary>
        public static void CreateAsset<T> () where T : ScriptableObject
        {
                T asset = ScriptableObject.CreateInstance<T>();
                string path = AssetDatabase.GetAssetPath( Selection.activeObject );
                if ( path == "" )
                {
                        path = "Assets";
                }
                else if ( Path.GetExtension( path ) != "" )
                {
                        path = path.Replace( Path.GetFileName( AssetDatabase.GetAssetPath( Selection.activeObject ) ) , "" );
                }

                string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath( path + "/New " + typeof( T ).ToString() + ".asset" );

                AssetDatabase.CreateAsset( asset , assetPathAndName );

                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = asset;
        }

        public static void CrateAsset ( System.Type type , string ClassName)
        {
                ScriptableObject asset = ScriptableObject.CreateInstance( ClassName );
                string path = AssetDatabase.GetAssetPath( Selection.activeObject );
                if ( path == "" )
                {
                        path = "Assets";
                }
                else if ( Path.GetExtension( path ) != "" )
                {
                        path = path.Replace( Path.GetFileName( AssetDatabase.GetAssetPath( Selection.activeObject ) ) , "" );
                }

                string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath( path+"/" + /*"/New " + type.ToString() +*/
                ClassName + ".asset" );

                AssetDatabase.CreateAsset( asset , assetPathAndName );

                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = asset;
        }
}