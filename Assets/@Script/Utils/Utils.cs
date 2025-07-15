using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using UnityEngine;

public class Utils
{
    public static T ParseEnum<T>(string value, bool ignoreCase = true)
    {
        return (T)Enum.Parse(typeof(T), value, ignoreCase);
    }

	public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }

    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        if (recursive == false)
        {
            Transform transform = go.transform.Find(name);
            if (transform != null)
                return transform.GetComponent<T>();
        }
        else
        {
            foreach (T component in go.GetComponentsInChildren<T>(true))
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }

    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform != null)
            return transform.gameObject;
        return null;
    }

/*	public static string GetText(string textID)
	{
		// TEMP : 일단은 한국어로
		if (Managers.Data.Texts.TryGetValue(textID, out TextData textData))
			return textData.Kor;

		return textID;
	}*/

	public static string GetGoldText(long gold)
	{
		return string.Format("{0:n0}", gold);
	}

    public static class DirectionUtil
    {
        public static Vector2Int ToVector2Int(Define.Direction dir)
        {
            switch (dir)
            {
                case Define.Direction.Up: return Vector2Int.up;
                case Define.Direction.Down: return Vector2Int.down;
                case Define.Direction.Left: return Vector2Int.left;
                case Define.Direction.Right: return Vector2Int.right;
                default: return Vector2Int.zero;
            }
        }

        public static Define.Direction FromVector2Int(Vector2Int vec)
        {
            if (vec == Vector2Int.up) return Define.Direction.Up;
            if (vec == Vector2Int.down) return Define.Direction.Down;
            if (vec == Vector2Int.left) return Define.Direction.Left;
            if (vec == Vector2Int.right) return Define.Direction.Right;
            return Define.Direction.None;
        }
    }

  
}
