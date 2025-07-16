using UnityEngine;

public class GameCanvas : UI_Scene
{
    public enum TextPros
    {
        TimeText,
        CurLevelText,
    }

    public enum Buttons
    {
        SettingButton,
    }

    public enum Images
    {
        ProgressFill,
    }

    public enum Objects
    {
        LevelGroup,
    }

    LevelFragment[] _levelFragments;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindTextPro(typeof(TextPros));
        BindButton(typeof(Buttons));
        BindImage(typeof(Images));
        BindObject(typeof(Objects));

        Manager.Game.Sec = 0f;

        GetButton((int)Buttons.SettingButton).onClick.AddListener(() =>
        {
            Manager.UI.ShowPopupUI<SettingPop>(callback: (settingPop) =>
            {

            });
        });

        _levelFragments = new LevelFragment[Manager.Game.LevelCount];
        for (int i = 0; i < _levelFragments.Length; i++)
        {
            int idx = i;
            Manager.UI.MakeSubItem<LevelFragment>(parent: GetObject((int)Objects.LevelGroup).transform, callback: (levelFragment) =>
            {
                _levelFragments[idx] = levelFragment;
                _levelFragments[idx].SetInfo(idx + 1);
            });
        }


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
        RefreshTime();
        RefreshProgress();

        if (Manager.UI.PeekPopupUI<UI_Popup>() == null)
            Time.timeScale = 1;
        else 
            Time.timeScale = 0;
    }

    private void RefreshTime()
    {
        int h = (int)Manager.Game.Sec / 60 / 60;
        int m = (int)Manager.Game.Sec / 60 % 60;
        int s = (int)Manager.Game.Sec % 60;
        GetTextPro((int)TextPros.TimeText).text = $"{h} : {m:D2} : {s:D2}";
    }

    private void RefreshProgress()
    {
        GetTextPro((int)TextPros.CurLevelText).text = $"{Manager.Game.CurLevel}";
        GetImage((int)Images.ProgressFill).fillAmount = (float)Manager.Game.CurLevel / (Manager.Game.LevelCount + 1);
    }
}
