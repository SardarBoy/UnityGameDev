using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;

public class PerformanceLogger : MonoBehaviour
{
    private string logFilePath;
    private List<string> logBuffer = new List<string>();

    void Awake()
    {
        logFilePath = Path.Combine(Application.persistentDataPath, "performance_log.csv");
        if (!File.Exists(logFilePath))
        {
            File.WriteAllText(logFilePath, "timestamp,level,session_id,shots_fired,hits,reaction_time,accuracy,weapon
");
        }
    }

    public void LogPerformance(string level, string sessionId, int shots, int hits, float reactionTime, string weapon)
    {
        float accuracy = shots > 0 ? (float)hits / shots : 0f;
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string line = $"{timestamp},{level},{sessionId},{shots},{hits},{reactionTime:F2},{accuracy:F2},{weapon}\n";
        logBuffer.Add(line);
        Debug.Log("[PerformanceLogger] " + line);
    }

    public void Flush()
    {
        if (logBuffer.Count > 0)
        {
            File.AppendAllLines(logFilePath, logBuffer);
            logBuffer.Clear();
        }
    }

    void OnApplicationQuit()
    {
        Flush();
    }
}