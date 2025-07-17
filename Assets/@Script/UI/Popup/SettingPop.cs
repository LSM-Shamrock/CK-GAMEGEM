using UnityEngine;

public class SettingPop : UI_Popup
{
    public enum Sliders
    {
        VolumeSlider,
    }

    public enum Images
    {
        Vol0,
        Vol25,
        Vol50,
        Vol100,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindSlider(typeof(Sliders));
        BindImage(typeof(Images));

        GetSlider((int)Sliders.VolumeSlider).onValueChanged.AddListener((value) =>
        {
            Manager.Sound.MasterVolume = value;
        });

        return true;
    }
}
