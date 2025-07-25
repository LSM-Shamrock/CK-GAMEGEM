﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCanvas : UI_Scene
{
    public enum Buttons
    {
        PlayButton,
        RankingButton,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButton(typeof(Buttons));

        GetButton((int)Buttons.PlayButton).onClick.AddListener(() =>
        {
            SceneManager.LoadScene("GameScene");
        });

        GetButton((int)Buttons.RankingButton).onClick.AddListener(() =>
        {
            Manager.UI.ShowPopupUI<RankingPop>(callback: (rankingPop) =>
            {

            });
        });

        return true;
    }
}
