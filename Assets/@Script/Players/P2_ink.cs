using UnityEngine;

public class P2_Ink : PlayerController
{
    protected override float _moveSpeed { get; set; } = 8f;

    protected override bool _isSwim { get; set; } = true;
    protected override int _maxJumpCount { get; set; } = 1;
    protected override int _curJumpCount { get; set; } = 0;
    protected override float _jumpPower { get; set; } = 5f;
    protected override float _fallSpeed { get; set; } = 5f;


    private void Update()
    {
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