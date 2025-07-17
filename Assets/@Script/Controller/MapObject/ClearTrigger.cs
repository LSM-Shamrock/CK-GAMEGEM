using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearTrigger : MonoBehaviour
{
    private bool _isOnP1;
    private bool _isOnP2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == Manager.Game.P1.transform)
            _isOnP1 = true;
        if (collision.transform == Manager.Game.P2.transform)
            _isOnP2 = true;

        if (_isOnP1 && _isOnP2)
        {
            SceneManager.LoadScene("EndingScene");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform == Manager.Game.P1.transform)
            _isOnP1 = false;
        if (collision.transform == Manager.Game.P2.transform)
            _isOnP2 = false;
    }
}
