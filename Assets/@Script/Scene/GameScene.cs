using UnityEngine;

public class GameScene : BaseScene
{
    [SerializeField] private BoxCollider2D _progressArea;

    private float _goalX;

    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        _goalX = _progressArea.bounds.max.x;

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

        if (Manager.Game.P1.transform.position.x > _goalX && Manager.Game.P2.transform.position.x > _goalX)
        {

        }
    }
}
