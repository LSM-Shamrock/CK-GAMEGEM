using UnityEngine;

public class Manager
{
    private static Manager _instance = null;
    public static Manager Instance { get { Init(); return _instance; } }

    private UIManager _ui = new UIManager();
    public static UIManager UI { get { return Instance._ui; } }

    private ResourceManager _resource = new ResourceManager();
    public static ResourceManager Resource { get { return Instance._resource; } }

    private GameManager _game = new GameManager();
    public static GameManager Game { get { return Instance._game; } }

    private RankingManager _ranking = new RankingManager();
    public static RankingManager Ranking { get { return Instance._ranking; } }

    private DataManager _data = new DataManager();
    public static DataManager Data { get { return Instance._data; } }

    public static void Init()
    {
        if (_instance != null)
            return;

        _instance = new Manager();
        _instance._data.Init();
    }
}
