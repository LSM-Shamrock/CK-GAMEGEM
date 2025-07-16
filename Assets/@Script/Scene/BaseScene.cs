using UnityEngine;

public class BaseScene : MonoBehaviour
{
    protected bool _init = false;

    public void Awake()
    {
        Init();
    }

    protected virtual bool Init()
    {
        if (_init)
            return false;

        _init = true;

        GameObject go = GameObject.Find("EventSystem");
        if (go == null)
        {
            Manager.Resource.Instantiate("EventSystem", null, (go) =>
            {
                go.name = "EventSystem";
            });
        }

        return true;
    }
}
