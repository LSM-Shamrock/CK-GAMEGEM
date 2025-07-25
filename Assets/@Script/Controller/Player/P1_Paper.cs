using UnityEngine;

public class P1_Paper : PlayerController
{
    protected override void Update()
    {
        base.Update();

        int dir = 0;
        if (Input.GetKey(KeyCode.A)) dir--;
        if (Input.GetKey(KeyCode.D)) dir++;
        UpdateMove(dir);

        bool jump = Input.GetKeyDown(KeyCode.W);
        UpdateJump(jump);
        UpdateFall(Time.deltaTime);

        UpdateSwim();
    }
}
