using UnityEngine;
using UnityEngine.TextCore.Text;

public class SettingPop : UI_Popup
{
    public enum Sliders
    {
        VolumeSlider,
    }

    public enum Buttons
    {
        ScreenModeL,
        ScreenModeR,
    }

    public enum TextPros
    {
        ScreenModeText,
    }

    public enum Objects
    {
        VolumeButtonGroup,
    }

    private bool IsFullScreen
    {
        get { return Screen.fullScreen; }
        set
        {
            Screen.fullScreen = value;
            if (Screen.fullScreen == true)
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            else
                Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindSlider(typeof(Sliders));
        BindButton(typeof(Buttons));
        BindTextPro(typeof(TextPros));
        BindObject(typeof(Objects));

        GetSlider((int)Sliders.VolumeSlider).onValueChanged.AddListener((value) =>
        {
            Manager.Sound.MasterVolume = value;
        });
        Transform volumeButtonGroup = GetObject((int)Objects.VolumeButtonGroup).transform;
        int volumeButtonCount = volumeButtonGroup.childCount;
        for (int i = 0; i < volumeButtonCount; i++)
        {
            int idx = i;
            BindEvent(volumeButtonGroup.GetChild(idx).gameObject, () =>
            {
                float volume = (float)idx / (volumeButtonCount - 1);
                GetSlider((int)Sliders.VolumeSlider).value = volume;
                Manager.Sound.MasterVolume = volume;
            });
        }

        GetTextPro((int)TextPros.ScreenModeText).text = $"창 모드 : {(IsFullScreen ? "전체화면" : "창")}";
        GetButton((int)Buttons.ScreenModeL).onClick.AddListener(() =>
        {
            IsFullScreen = !IsFullScreen;
            GetTextPro((int)TextPros.ScreenModeText).text = $"창 모드 : {(IsFullScreen ? "전체화면" : "창")}";
        });
        GetButton((int)Buttons.ScreenModeR).onClick.AddListener(() =>
        {
            IsFullScreen = !IsFullScreen;
            GetTextPro((int)TextPros.ScreenModeText).text = $"창 모드 : {(IsFullScreen ? "전체화면" : "창")}";
        });

        return true;
    }
}
