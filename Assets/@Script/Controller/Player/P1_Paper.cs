using UnityEngine;

public class P1_Paper : PlayerController
{
    protected override float MoveSpeed { get; set; } = 8f;

    protected override bool IsSwim { get; set; } = false;
    protected override int MaxJumpCount { get; set; } = 2;
    protected override int CurJumpCount { get; set; } = 0;
    protected override float JumpPower { get; set; } = 20f;
    protected override float FallSpeed { get; set; } = 60f;


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
