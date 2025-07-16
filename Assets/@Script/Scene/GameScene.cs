using UnityEngine;

public class GameScene : BaseScene
{
    [SerializeField] private BoxCollider2D _progressArea;

    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        Manager.Game.LevelCount = FindObjectsByType<SavePoint>(FindObjectsSortMode.None).Length;
        Manager.Game.CurLevel = 0;

        Manager.UI.ShowSceneUI<GameCanvas>(callback: (gameCanvas) =>
        {

        });

        return true;
    }

    private void Update()
    {
        Manager.Game.Sec += Time.deltaTime;
    }
}
