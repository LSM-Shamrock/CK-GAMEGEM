using UnityEngine;

public class Manager
{
    private static Manager _instance = new Manager();
    private static Manager Instance { get { return _instance; } }

    private UIManager _ui = new UIManager();
    public static UIManager UI { get { return Instance._ui; } }

    private ResourceManager _resource = new ResourceManager();
    public static ResourceManager Resource { get { return Instance._resource; } }

    private GameManager _game = new GameManager();
    public static GameManager Game { get { return Instance._game; } }

    private RankingManager _ranking = new RankingManager();
    public RankingManager Ranking { get { return Instance._ranking; } }
}
