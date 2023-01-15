using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemySaveController))]
public class EnemySavaDataEditer : Editor
{

    /// <summary>
    /// InspectorのGUIを更新
    /// </summary>
    public override void OnInspectorGUI()
    {
        //元のInspector部分を表示
        base.OnInspectorGUI();

        EnemySaveController enemySaveController = target as EnemySaveController;

        if (GUILayout.Button("キャラクター登録"))
        {
            enemySaveController.EnemyRgister();
        }

        if (GUILayout.Button("キャラクター登録解除"))
        {
            enemySaveController.EnemyUnRegister();
        }
    }

}