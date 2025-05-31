using UnityEngine;
using System.Collections;
using System.Text;

public class GameStatsUploader : MonoBehaviour
{
    public string endpointURL = "https://fake-server.com/api/uploadStats";

    public IEnumerator UploadStats(string level, int kills, float accuracy, float avgReactionTime)
    {
        string jsonData = JsonUtility.ToJson(new StatPayload
        {
            level = level,
            kills = kills,
            accuracy = accuracy,
            avgReactionTime = avgReactionTime,
            timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        });

        Debug.Log("[GameStatsUploader] Simulating upload: " + jsonData);

        yield return new WaitForSeconds(1.0f); // Simulate network delay

        Debug.Log("[GameStatsUploader] Upload complete.");
    }

    [System.Serializable]
    public class StatPayload
    {
        public string level;
        public int kills;
        public float accuracy;
        public float avgReactionTime;
        public string timestamp;
    }
}