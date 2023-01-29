using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CI.QuickSave;

public class GameSaveData : MonoBehaviour
{
    [SerializeField]
    string _nameKey;

    [SerializeField]
    string _positionKey;

    [SerializeField]
    string _timeKey;

    [SerializeField]
    GameObject _gb;
    private void Start()
    {
        // �f�[�^�̕ۑ����Application.dataPath�ɕύX
        QuickSaveGlobalSettings.StorageLocation = Application.dataPath;

        // QuickSaveSettings�̃C���X�^���X���쐬
        QuickSaveSettings settings = new QuickSaveSettings();

        // �Í����̕��@ 
        settings.SecurityMode = SecurityMode.None;

        // Aes�̈Í����L�[
        settings.Password = "Pass";

        // ���k�̕��@
        settings.CompressionMode = CompressionMode.Gzip;

        // QuickSaveWriter�̃C���X�^���X���쐬
        QuickSaveWriter writer = QuickSaveWriter.Create("Player", settings);

        // �f�[�^����������
       /* writer.Write("Name", "Raiun");
        writer.Write("Position", Vector3.zero);
        writer.Write("Time", 30);
        */

        writer.Write(_nameKey, "Aoi");
        writer.Write(_positionKey, new Vector3(1,1,1));
        writer.Write(_timeKey, 25);

        // �ύX�𔽉f
        writer.Commit();

        // QuickSaveReader�̃C���X�^���X���쐬
        QuickSaveReader reader = QuickSaveReader.Create("Player", settings);

        // �f�[�^��ǂݍ���
        string name = reader.Read<string>("Name");
        Vector3 position = reader.Read<Vector3>("Position");
        int time = reader.Read<int>("Time");

        // ����m�F
        Debug.Log("name: " + name + ", position: " + position + ", time: " + time);
    }
}