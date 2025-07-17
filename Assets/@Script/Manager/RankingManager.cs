using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class RankingEntry
{
    public string playerName;
    public int totalSeconds; 
}

[System.Serializable]
public class RankingData
{
    public List<RankingEntry> rankings = new List<RankingEntry>();
}

public class RankingManager
{
    private const string RankingFileName = "ranking.json";
    private string FilePath => Path.Combine(Application.persistentDataPath, RankingFileName);

    public RankingData LoadRankings()
    {
        if (!File.Exists(FilePath))
            return new RankingData();

        string json = File.ReadAllText(FilePath);

        Debug.Log(json);
        return JsonUtility.FromJson<RankingData>(json);
    }

    public void SaveRanking(string playerName, TimeSpan playTime)
    {
        RankingData data = LoadRankings();

        data.rankings.Add(new RankingEntry
        {
            playerName = playerName,
            totalSeconds = (int)playTime.TotalSeconds
        });

        data.rankings.Sort((a, b) => a.totalSeconds.CompareTo(b.totalSeconds));
        if (data.rankings.Count > 5)
            data.rankings.RemoveRange(5, data.rankings.Count - 5);

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(FilePath, json);

        Debug.Log(FilePath);
    }

    public void ClearRanking()
    {
        if (File.Exists(FilePath))
            File.Delete(FilePath);
    }
}

