using UnityEngine;

public class GameScene : BaseScene
{
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        Manager.UI.ShowSceneUI<GameCanvas>();


        return true;
    }
}
