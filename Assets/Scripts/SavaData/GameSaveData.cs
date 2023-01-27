using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CI.QuickSave;
public class GameSaveData : MonoBehaviour
{
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
        writer.Write("Name", "Raiun");
        writer.Write("Position", Vector3.zero);
        writer.Write("Time", 30);

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