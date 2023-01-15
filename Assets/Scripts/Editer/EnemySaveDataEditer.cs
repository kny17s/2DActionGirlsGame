using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemySaveController))]
public class EnemySavaDataEditer : Editor
{

    /// <summary>
    /// Inspector��GUI���X�V
    /// </summary>
    public override void OnInspectorGUI()
    {
        //����Inspector������\��
        base.OnInspectorGUI();

        EnemySaveController enemySaveController = target as EnemySaveController;

        if (GUILayout.Button("�L�����N�^�[�o�^"))
        {
            enemySaveController.EnemyRgister();
        }

        if (GUILayout.Button("�L�����N�^�[�o�^����"))
        {
            enemySaveController.EnemyUnRegister();
        }
    }

}