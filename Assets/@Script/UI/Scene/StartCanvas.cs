using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCanvas : UI_Scene
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;



        return true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameScene");
        }

        if (Input.GetKeyDown(KeyCode.R) && Manager.UI.PeekPopupUI<UI_Popup>() == null)
        {
            Manager.UI.ShowPopupUI<RankingPop>(callback: (rankingPop) =>
            {

            });
        }
    }
}
