using UnityEngine;

public class StartScene : BaseScene
{
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        Manager.UI.ShowSceneUI<StartCanvas>();

        return true;
    }
}
