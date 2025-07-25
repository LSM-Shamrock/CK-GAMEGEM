using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : BaseScene
{
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        Manager.Game.playTime = TimeSpan.Zero;

        Manager.Game.LevelCount = FindObjectsByType<Savepoint>(FindObjectsSortMode.None).Length;
        Manager.Game.CurLevel = 0;

        Manager.UI.ShowSceneUI<GameCanvas>();

        return true;
    }

    private void Update()
    {
        Manager.Game.playTime += TimeSpan.FromSeconds(Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
            Manager.UI.ClosePopupUI();
    }
}
