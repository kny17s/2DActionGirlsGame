using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterDataController))]
public class SaveDataEditer : Editor
{

    /// <summary>
    /// InspectorのGUIを更新
    /// </summary>
    public override void OnInspectorGUI()
    {
        //元のInspector部分を表示
        base.OnInspectorGUI();

        CharacterDataController saveController = target as CharacterDataController;

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