using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene : UI_Base
{
	public override bool Init()
	{
		if (base.Init() == false)
			return false;


        GameObject go = GameObject.Find("EventSystem");
        if (go == null)
        {
            Manager.Resource.Instantiate("EventSystem", null, (go) =>
            {
                go.name = "EventSystem";
            });
        }

        Manager.UI.SetCanvas(gameObject, false);
		return true;
	}
}
