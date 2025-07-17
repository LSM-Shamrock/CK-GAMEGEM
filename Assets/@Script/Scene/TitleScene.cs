using UnityEngine;

public class TitleScene : BaseScene
{
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        Manager.UI.ShowSceneUI<TitleCanvas>();

        return true;
    }
}
