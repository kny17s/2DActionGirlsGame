using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SaveController))]
public class TestEditer : Editor
{

    /// <summary>
    /// InspectorのGUIを更新
    /// </summary>
    public override void OnInspectorGUI()
    {
        //元のInspector部分を表示
        base.OnInspectorGUI();

        SaveController saveController = target as SaveController;

        if (GUILayout.Button("キャラクター登録"))
        {
            saveController.Rgister();
        }

        if (GUILayout.Button("キャラクター登録解除"))
        {
            saveController.UnRegister();
        }
    }

}