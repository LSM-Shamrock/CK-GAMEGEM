using UnityEngine;

public class GameCanvas : UI_Scene
{
    public enum TextPros
    {
        TimeText,
    }

    public enum Buttons
    {
        SettingButton
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindTextPro(typeof(TextPros));
        BindButton(typeof(Buttons));

        Manager.Game.Sec = 0f;


        GetButton((int)Buttons.SettingButton).onClick.AddListener(() =>
        {
            Manager.UI.ShowPopupUI<SettingPop>();
        });


        _init = true;
        return true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
            Screen.fullScreen = !Screen.fullScreen;
    }

    private void LateUpdate()
    {
        Manager.Game.Sec += Time.deltaTime;
        int h = (int)Manager.Game.Sec / 60 / 60;
        int m = (int)Manager.Game.Sec / 60 % 60;
        int s = (int)Manager.Game.Sec % 60;
        GetTextPro((int)TextPros.TimeText).text = $"{h} : {m:D2} : {s:D2}";
    }
}
