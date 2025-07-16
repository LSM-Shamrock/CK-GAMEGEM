using UnityEngine;

public class LevelFragment : UI_Base
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

        return true;
    }

    public void SetInfo(int num)
    {
        Init();
        GetTextPro((int)TextPros.Text).text = $"{num}";
    }
}
