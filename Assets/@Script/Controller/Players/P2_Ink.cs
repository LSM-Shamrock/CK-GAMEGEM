using UnityEngine;

public class P2_Ink : PlayerController
{
    protected override float MoveSpeed { get; set; } = 8f;

    protected override bool IsSwim { get; set; } = true;
    protected override int MaxJumpCount { get; set; } = 1;
    protected override int CurJumpCount { get; set; } = 0;
    protected override float JumpPower { get; set; } = 5f;
    protected override float FallSpeed { get; set; } = 5f;


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