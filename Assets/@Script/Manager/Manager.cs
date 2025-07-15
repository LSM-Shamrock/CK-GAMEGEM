using UnityEngine;

public class Manager
{
    private static Manager _instance = new Manager();
    private static Manager Instance { get { return _instance; } }

    private ObjectManager _obj = new ObjectManager();
    public static ObjectManager Obj { get { return Instance._obj; } }

    private UIManager _ui = new UIManager();
    public static UIManager UI { get { return Instance._ui; } }

    private ResourceManager _resource = new ResourceManager();
    public static ResourceManager Resource { get { return Instance._resource; } }
}
