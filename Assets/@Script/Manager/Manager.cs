using UnityEngine;

public class Manager
{
    private static Manager _instance = new Manager();
    private static Manager Instance { get { return _instance; } }

    private ObjectManager _obj;
    public static ObjectManager Obj { get { return Instance._obj; } }


}
