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
        // データの保存先をApplication.dataPathに変更
        QuickSaveGlobalSettings.StorageLocation = Application.dataPath;

        // QuickSaveSettingsのインスタンスを作成
        QuickSaveSettings settings = new QuickSaveSettings();

        // 暗号化の方法 
        settings.SecurityMode = SecurityMode.None;

        // Aesの暗号化キー
        settings.Password = "Pass";

        // 圧縮の方法
        settings.CompressionMode = CompressionMode.Gzip;

        // QuickSaveWriterのインスタンスを作成
        QuickSaveWriter writer = QuickSaveWriter.Create("Player", settings);

        // データを書き込む
       /* writer.Write("Name", "Raiun");
        writer.Write("Position", Vector3.zero);
        writer.Write("Time", 30);
        */

        writer.Write(_nameKey, "Aoi");
        writer.Write(_positionKey, new Vector3(1,1,1));
        writer.Write(_timeKey, 25);

        // 変更を反映
        writer.Commit();

        // QuickSaveReaderのインスタンスを作成
        QuickSaveReader reader = QuickSaveReader.Create("Player", settings);

        // データを読み込む
        string name = reader.Read<string>("Name");
        Vector3 position = reader.Read<Vector3>("Position");
        int time = reader.Read<int>("Time");

        // 動作確認
        Debug.Log("name: " + name + ", position: " + position + ", time: " + time);
    }
}