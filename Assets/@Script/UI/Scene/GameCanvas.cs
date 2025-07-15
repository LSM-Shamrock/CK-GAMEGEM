using UnityEngine;

public class GameCanvas : UI_Scene
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;



        _init = true;
        return true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
            Screen.fullScreen = !Screen.fullScreen;
    }
}
