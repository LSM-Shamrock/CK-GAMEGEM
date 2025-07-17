using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RankingPop : UI_Popup
{
    public enum TextPros
    {
        Text,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindTextPro(typeof(TextPros));

        List<RankingEntry> rankings = Manager.Ranking.LoadRankings().rankings;

        string text = "";
        if (rankings.Count > 0)
            text += $"1st - {(rankings[0].totalSeconds / 60):D2}:{(rankings[0].totalSeconds % 60):D2}\n";
        if (rankings.Count > 1)
            text += $"2nd - {(rankings[1].totalSeconds / 60):D2}:{(rankings[1].totalSeconds % 60):D2}\n";
        if (rankings.Count > 2)
            text += $"3rd - {(rankings[2].totalSeconds / 60):D2}:{(rankings[2].totalSeconds % 60):D2}\n";

        GetTextPro((int)TextPros.Text).text = text;

        return true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Manager.UI.ClosePopupUI(this);
    }
}
