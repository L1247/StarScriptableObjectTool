using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
public class ScriptableObjectWindow : EditorWindow
{
    ScriptableObject mono;
    public UnityEngine.Object source;
    // Add menu named "My Window" to the Window menu
    [MenuItem( "StarTools/ScriptableObjectWindow" )]
    static void Init ( )
    {
        // Get existing open window or if none, make a new one:
        ScriptableObjectWindow window = ( ScriptableObjectWindow ) EditorWindow.GetWindow( typeof( ScriptableObjectWindow ) );
        window.Show();
    }

    void OnGUI ( )
    {
        GUILayout.Label( "Put A Sub-Object Of ScriptableObject On The Field" , EditorStyles.boldLabel );
        EditorGUILayout.BeginHorizontal();
        source = EditorGUILayout.ObjectField( source , typeof( UnityEngine.Object ) , true );
        EditorGUILayout.EndHorizontal();
        if ( GUILayout.Button( "Generate ScriptableObject!" ) )
        {
            Type t = source.GetType();
            string ClassName = source.name;
            Type type = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany( x => x.GetTypes() )
                       .FirstOrDefault( x => x.Name == ClassName );

            bool IsValid = type.IsSubclassOf( typeof( ScriptableObject ) );
            if ( IsValid == false )
            {
                Debug.LogError( "所放入的物件沒有繼承 ScriptableObject ，故無法產生。" );
                return;
            }
            ScriptableObjectUtility.CrateAsset( t , ClassName );
        }
    }
}