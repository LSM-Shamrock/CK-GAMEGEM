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
    //public Dictionary<int, HeroData> HeroDatas { get; private set; }
    //public Dictionary<int, Skills> SkillDatas { get; private set; }
    //public Dictionary<int, AnimationData> AnimDatas { get; private set; }
    //public Dictionary<int, MonsterData> MonDatas { get; private set; }
    //public Dictionary<int, ChestData> ChestDatas { get; private set; }
    //public Dictionary<Define.HeroRating, UpgradeData> UpgradeDatas { get; private set; }
    public Dictionary<int, StudentData> StudentDatas { get; private set; }


    public void Init()
    {
        //LoadJson<HeroLoader, int, HeroData>("HeroData.json", (loader) => { HeroDatas = loader.MakeDic(); });
        //LoadJson<SkillLoader, int, Skills>("SkillData.json", (loader) => { SkillDatas = loader.MakeDic(); });
        //LoadJson<AnimationLoader, int, AnimationData>("AnimData.json", (loader) => { AnimDatas = loader.MakeDic(); });
        //LoadJson<MonsterLoader, int, MonsterData>("MonData.json", (loader) => { MonDatas = loader.MakeDic(); });
        //LoadJson<UpgradeDataLoader, Define.HeroRating, UpgradeData>("UpgradeData.json", (loader) => { UpgradeDatas = loader.MakeDic(); });
        //LoadJson<HeroUpgradeDataLoader, int, HeroUpgradeData>("HeroUpgradeData.json", (loader) => HeroUpgradeDatas = loader.MakeDic());
        LoadJson<StudentDataLoader, int, StudentData>("StudentData.json", (loader) =>
        {
            StudentDatas = loader.MakeDic();
            Debug.Log("!");
            Manager.Resource.LoadAsync<TextAsset>("StudentData.json", callback: (textAsset) => { Debug.Log(textAsset.text); });
            foreach (var a in StudentDatas.Keys) 
                Debug.Log(a);
        });

    }
    void LoadJson<Loader, Key, Value>(string key, Action<Loader> callback) where Loader : ILoader<Key, Value>
    {
        Manager.Resource.LoadAsync<TextAsset>(key, (textAsset) =>
        {
            //Loader loader = JsonConvert.DeserializeObject<Loader>(textAsset.text);
            Loader loader = JsonUtility.FromJson<Loader>(textAsset.text);
            callback?.Invoke(loader);
        });
    }
    public bool Loaded()
    {
        //if (HeroDatas == null)
        //    return false;
        //if (SkillDatas == null)
        //    return false;
        //if (AnimDatas == null)
        //    return false;
        //if (MonDatas == null)
        //{
        //    Debug.Log("너녀");
        //    return false;
        //}
        if (StudentDatas == null) 
            return false;   


        return true;
    }

}
