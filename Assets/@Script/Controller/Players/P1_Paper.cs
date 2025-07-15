using UnityEngine;

public class P1_Paper : PlayerController
{
    protected override float _moveSpeed { get; set; } = 8f;

    protected override bool _isSwim { get; set; } = false;
    protected override int _maxJumpCount { get; set; } = 2;
    protected override int _curJumpCount { get; set; } = 0;
    protected override float _jumpPower { get; set; } = 20f;
    protected override float _fallSpeed { get; set; } = 60f;


    private void Update()
    {
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
