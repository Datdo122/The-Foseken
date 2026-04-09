using UnityEngine;
using System.IO;

public class SaveGame : MonoBehaviour
{
    private  string saveFilePath;
    void Awake()
    {
        saveFilePath = Application.dataPath + "/SaveGame/savegame.json";
    }
    public void SavePosition(Vector3 positionPlayer, int checkpointID)
    {
        GameData data = new GameData();
        data.lastCheckpointID = checkpointID;
        // Lưu tọa độ người chơi vào data.playerPosition
        data.playerPosition = new float[3];
        data.playerPosition[0] = positionPlayer.x;
        data.playerPosition[1] = positionPlayer.y;
        data.playerPosition[2] = positionPlayer.z;

        string json = JsonUtility.ToJson(data, true);
        System.IO.File.WriteAllText(saveFilePath, json);
        Debug.Log("Đã lưu game tại: " + saveFilePath);

    }
}
