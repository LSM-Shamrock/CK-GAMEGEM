using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using static Define;

[Serializable]
public class HeroData
{
    public int HeroID;
    public string ElementType;
    [SerializeField] private string ArangeType;
    [SerializeField] private string HeroRating;
    [SerializeField] private string HeroAbility;
    public float BaseAttack;
    public HeroType Arange_Type => ParseEnumOrDefault(ArangeType, Define.HeroType.Close);
    public HeroRating Hero_Rating => ParseEnumOrDefault(HeroRating, Define.HeroRating.Common);
    public HeroAbility Hero_Ability => ParseEnumOrDefault(HeroAbility, Define.HeroAbility.Atkker);

    private T ParseEnumOrDefault<T>(string value, T defaultValue) where T : struct
    {
        if (Enum.TryParse<T>(value, ignoreCase: true, out var result))
            return result;
        return defaultValue;
    }

    public List<LevelData> LevelData = new List<LevelData>();
}
[Serializable]
public class LevelData
{
    public string HeroName;
    public int Level;
    public string Sprite;
    public string HeroInduce;
    public string HeroSprite;

    public HeroLevelData HeroLevelData;
    public SkillMapping SkillMapData;

    [SerializeField] private string AtkArange;
    public Define.AtkArange Atk_Arange => ParseEnumOrDefault(AtkArange, Define.AtkArange.Single);

    private T ParseEnumOrDefault<T>(string value, T defaultValue) where T : struct
    {
        if (Enum.TryParse<T>(value, true, out var result))
            return result;
        return defaultValue;
    }

}
[Serializable]
public class HeroLevelData
{
    public float Attack;
    public float Arange;
    public float AtkSpeed;
    public float Upgrade;
}
[Serializable]
public class SkillMapping
{
    public int SkillID;
    public int AnimationID;
}

[Serializable]
public class HeroLoader : ILoader<int, HeroData>
{
    public List<HeroData> heroes = new List<HeroData>();
    public Dictionary<int, HeroData> MakeDic()
    {
        Dictionary<int, HeroData> heroDic = new Dictionary<int, HeroData>();

        foreach (var hero in heroes)
        {
            heroDic.Add(hero.HeroID, hero);
        }


        return heroDic;
    }

    public bool Validate()
    {
        return true;
    }
}

[Serializable]
public class Skills
{
    public int SkillID;
    public string SkillPre;
    public string SkillType;

    public SkillType SkillT { get { return ParseEnumOrDefault<SkillType>(SkillType, Define.SkillType.Single); } }
    private T ParseEnumOrDefault<T>(string value, T defaultValue) where T : struct
    {
        if (Enum.TryParse<T>(value, ignoreCase: true, out var result))
            return result;
        return defaultValue;
    }
}

[Serializable]
public class SkillLoader : ILoader<int, Skills>
{
    public List<Skills> skills = new List<Skills>();
    public Dictionary<int, Skills> MakeDic()
    {
        Dictionary<int, Skills> skillDic = new Dictionary<int, Skills>();
        foreach (var skill in skills)
            skillDic.Add(skill.SkillID, skill);

        return skillDic;
    }

    public bool Validate()
    {
        return true;
    }
}

[Serializable]
public class AnimationData
{
    public int AnimationID;
    public string AnimationPre;
}
[Serializable]
public class AnimationLoader : ILoader<int, AnimationData>
{
    public List<AnimationData> anims = new List<AnimationData>();
    public Dictionary<int, AnimationData> MakeDic()
    {
        Dictionary<int, AnimationData> animDic = new Dictionary<int, AnimationData>();
        foreach (var animation in anims)
            animDic.Add(animation.AnimationID, animation);

        return animDic;
    }

    public bool Validate()
    {
        return true;
    }
}

[Serializable]
public class MonsterData
{
    public int MonsterID;
    public string MonsterName;
    public float Speed;
    public float Hp;
    public float Money;
}
[Serializable]
public class MonsterLoader : ILoader<int, MonsterData>
{
    public List<MonsterData> monsters = new List<MonsterData>();
    public Dictionary<int, MonsterData> MakeDic()
    {
        Dictionary<int, MonsterData> monDic = new Dictionary<int, MonsterData>();
        foreach (var mon in monsters)
            monDic.Add(mon.MonsterID, mon);

        return monDic;
    }

    public bool Validate()
    {
        return true;
    }
}
[Serializable]
public class ProductData
{
    public int ProductID;
    public string ProductName;
    public string Type;
    public string ProductSpriteKey;
    public int Price;
    public int CardID;
    public int GainGoods;
    public int Qnt;
    public string Pay;
    public Define.ProductType ProductType => ParseEnumOrDefault<Define.ProductType>(Type, Define.ProductType.Card);
    public Define.PayType PayType => ParseEnumOrDefault<Define.PayType>(Pay, Define.PayType.Gold);

    private T ParseEnumOrDefault<T>(string value, T defaultValue) where T : struct
    {
        if (Enum.TryParse<T>(value, true, out var result))
            return result;
        return defaultValue;
    }
}
[Serializable]
public class ProductLoader : ILoader<int, ProductData>
{
    public List<ProductData> products = new List<ProductData>();
    public Dictionary<int, ProductData> MakeDic()
    {
        Dictionary<int, ProductData> dict = new Dictionary<int, ProductData>();

        for (int i = 0; i < products.Count; i++)
        {
            dict.Add(products[i].ProductID, products[i]);
        }
        return dict;
    }

    public bool Validate()
    {
        return true;
    }
}
[Serializable]
public class UpgradeData
{
    public string Grade;
    public List<UpgradeCondition> Levels = new List<UpgradeCondition>();

    public HeroRating HeroGrade { get { return ParseEnumOrDefault<HeroRating>(Grade, HeroRating.Common); } }
    private T ParseEnumOrDefault<T>(string value, T defaultValue) where T : struct
    {
        if (Enum.TryParse<T>(value, ignoreCase: true, out var result))
            return result;
        return defaultValue;
    }
}

[Serializable]
public class UpgradeCondition
{
    public int RequiredCardNumber;
    public int Price;
}
[Serializable]
public class UpgradeDataLoader : ILoader<HeroRating, UpgradeData>
{
    public List<UpgradeData> upgradeDatas = new List<UpgradeData>();
    public Dictionary<HeroRating, UpgradeData> MakeDic()
    {
        Dictionary<HeroRating, UpgradeData> dict = new Dictionary<HeroRating, UpgradeData>();

        foreach (UpgradeData upgrade in upgradeDatas)
        {
            dict.Add(upgrade.HeroGrade, upgrade);
        }
        return dict;
    }

    public bool Validate()
    {
        return true;
    }
}
[Serializable]
public class HeroUpgradeData
{
    public int HeroId;
    public float AttackIncreaseAmount;
}
[Serializable]
public class HeroUpgradeDataLoader : ILoader<int, HeroUpgradeData>
{
    public List<HeroUpgradeData> HeroUpgradeDatas = new List<HeroUpgradeData>();
    public Dictionary<int, HeroUpgradeData> MakeDic()
    {
        Dictionary<int, HeroUpgradeData> dict = new Dictionary<int, HeroUpgradeData>();

        foreach (HeroUpgradeData upgrade in HeroUpgradeDatas)
            dict.Add(upgrade.HeroId, upgrade);

        return dict;
    }

    public bool Validate()
    {
        return true;
    }
}

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