﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : BaseScene
{
    [SerializeField] CompositeCollider2D _progressArea;

    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        Manager.Game.playTime = TimeSpan.Zero;

        Manager.Game.LevelCount = FindObjectsByType<SavePoint>(FindObjectsSortMode.None).Length;
        Manager.Game.CurLevel = 0;

        Manager.UI.ShowSceneUI<GameCanvas>(callback: (gameCanvas) =>
        {

        });

        return true;
    }

    private void Update()
    {
        Manager.Game.playTime += TimeSpan.FromSeconds(Time.deltaTime);
    }
}
