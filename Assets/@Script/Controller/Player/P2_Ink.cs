using UnityEngine;

public class P2_Ink : PlayerController
{
    protected override void Update()
    {
        base.Update();

        int dir = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) dir--;
        if (Input.GetKey(KeyCode.RightArrow)) dir++;
        UpdateMove(dir);

        bool jump = Input.GetKeyDown(KeyCode.UpArrow);
        UpdateJump(jump);
        UpdateFall(Time.deltaTime);

        UpdateSwim();
    }
}