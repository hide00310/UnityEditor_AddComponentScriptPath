using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AddComponentScriptPathEditor : EditorWindow
{
    [MenuItem("My Window/Add Component Script")]
    public static void Execute()
    {
        // Cubeを検索
        var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        GameObject Cube = null;
        foreach (var obj in scene.GetRootGameObjects())
        {
            if (obj.name == "Cube") Cube = obj;
        }
        // CubeにAddComponentScriptPathScriptコンポーネントを追加
        AddComponentScript(Cube, "Assets/UdonSharp_AddComponentScriptPath/AddComponentScriptPathScript.cs");
    }
    static MonoBehaviour AddComponentScript(GameObject obj, string path)
    {
        var script = AssetDatabase.LoadAssetAtPath<MonoScript>(path);
        Debug.Assert(script != null, $"{obj.name} {path}");
        MonoBehaviour component = (MonoBehaviour)Undo.AddComponent(obj, script.GetClass());
        return component;
    }
}
