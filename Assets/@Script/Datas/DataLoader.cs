using System;
using System.Collections.Generic;

[Serializable]
public class StudentData
{
    public int Studentcode;
    public string Name;
    public string Photo;

    private T ParseEnumOrDefault<T>(string value, T defaultValue) where T : struct
    {
        if (Enum.TryParse<T>(value, ignoreCase: true, out var result))
            return result;
        return defaultValue;
    }
}
[Serializable]
public class StudentDataLoader : ILoader<int, StudentData>
{
    public List<StudentData> StudentDatas = new List<StudentData>();
    public Dictionary<int, StudentData> MakeDic()
    {
        Dictionary<int, StudentData> dict = new Dictionary<int, StudentData>();

        foreach (StudentData data in StudentDatas)
            dict.Add(data.Studentcode, data);

        return dict;
    }

    public bool Validate()
    {
        return true;
    }
}

[Serializable]
public class EndingData
{
    public int Idx;
    public string Line;
    private T ParseEnumOrDefault<T>(string value, T defaultValue) where T : struct
    {
        if (Enum.TryParse<T>(value, ignoreCase: true, out var result))
            return result;
        return defaultValue;
    }
}
[Serializable]
public class EndingDataLoader : ILoader<int, EndingData>
{
    public List<EndingData> EndingDatas = new List<EndingData>();
    public Dictionary<int, EndingData> MakeDic()
    {
        Dictionary<int, EndingData> dict = new Dictionary<int, EndingData>();
        foreach (EndingData data in EndingDatas)
            dict.Add(data.Idx, data);
        return dict;
    }
    public bool Validate()
    {
        return true;
    }
}

[Serializable]
public class FrologData
{
    public int Idx;
    public string Line;
    private T ParseEnumOrDefault<T>(string value, T defaultValue) where T : struct
    {
        if (Enum.TryParse<T>(value, ignoreCase: true, out var result))
            return result;
        return defaultValue;
    }
}
[Serializable]
public class FrologDataLoader : ILoader<int, FrologData>
{
    public List<FrologData> FrologDatas = new List<FrologData>();
    public Dictionary<int, FrologData> MakeDic()
    {
        Dictionary<int, FrologData> dict = new Dictionary<int, FrologData>();
        foreach (FrologData data in FrologDatas)
            dict.Add(data.Idx, data);
        return dict;
    }
    public bool Validate()
    {
        return true;
    }
}