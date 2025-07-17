using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCanvas : UI_Scene
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("StageTest");
        }
    }
}
