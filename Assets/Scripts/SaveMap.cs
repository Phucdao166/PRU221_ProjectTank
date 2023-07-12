using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveMap : MonoBehaviour
{
    public GameObject map; // Tham chiếu đến đối tượng bản đồ cần lưu

    public void SaveNewMap()
    {
        // Tạo một đường dẫn cho tệp lưu trữ
        string savePath = Application.persistentDataPath + "/mapdata.json";

        // Lấy dữ liệu của bản đồ thành một đối tượng Serializable
        MapData mapData = new MapData(map.transform.position, map.transform.rotation);

        // Chuyển đổi đối tượng thành JSON
        string jsonData = JsonUtility.ToJson(mapData);

        // Lưu JSON vào tệp
        File.WriteAllText(savePath, jsonData);

        Debug.Log("Map saved!");
    }
}

[System.Serializable]
public class MapData
{
    public Vector3 position;
    public Quaternion rotation;

    public MapData(Vector3 pos, Quaternion rot)
    {
        position = pos;
        rotation = rot;
    }
}
