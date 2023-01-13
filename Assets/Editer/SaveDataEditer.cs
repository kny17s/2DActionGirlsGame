using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SaveController))]
public class TestEditer : Editor
{

    /// <summary>
    /// Inspector��GUI���X�V
    /// </summary>
    public override void OnInspectorGUI()
    {
        //����Inspector������\��
        base.OnInspectorGUI();

        SaveController saveController = target as SaveController;

        if (GUILayout.Button("�L�����N�^�[�o�^"))
        {
            saveController.Rgister();
        }

        if (GUILayout.Button("�L�����N�^�[�o�^����"))
        {
            saveController.UnRegister();
        }
    }

}