using Newtonsoft.Json;
using NUnit.Framework.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Item>
{
    Dictionary<Key, Item> MakeDic();
    bool Validate();
}
public class DataManager
{
    //public Dictionary<int, StudentData> StudentDatas { get; private set; }
    public Dictionary<int, EndingData> Ending { get; private set; }
    public Dictionary<int, FrologData> Frolog { get; private set; }

    public void Init()
    {
        //LoadJson<StudentDataLoader, int, StudentData>("StudentData.json", (loader) =>
        //{
        //    StudentDatas = loader.MakeDic();
        //    Debug.Log("!");
        //    Manager.Resource.LoadAsync<TextAsset>("StudentData.json", callback: (textAsset) => { Debug.Log(textAsset.text); });
        //    foreach (var a in StudentDatas.Keys) 
        //        Debug.Log(a);
        //});
        LoadJson<EndingDataLoader, int, EndingData>("Ending.json", (loader) => { Ending = loader.MakeDic(); });
        LoadJson<FrologDataLoader, int, FrologData>("Frolog.json", (loader) => { Frolog = loader.MakeDic(); });

    }
    void LoadJson<Loader, Key, Value>(string key, Action<Loader> callback) where Loader : ILoader<Key, Value>
    {
        Manager.Resource.LoadAsync<TextAsset>(key, (textAsset) =>
        {
            Loader loader = JsonUtility.FromJson<Loader>(textAsset.text);
            callback?.Invoke(loader);
        });
    }
    public bool Loaded()
    {
        //if (StudentDatas == null) 
        //    return false;   

        return true;
    }

}
