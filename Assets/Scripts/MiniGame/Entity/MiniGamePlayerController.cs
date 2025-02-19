using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGamePlayerController : BaseController
{
    private float camOffsetX;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        // 카메라 위치 
        camOffsetX = Camera.main.transform.position.x - transform.localPosition.x;
    }

    protected override void Update()
    {
        FollowCamera();
    }

    protected override void FixedUpdate()
    {
        if (MiniGameManager.Instance.gameOver) { return; }

        Vector2 moveDir = rigid.velocity;
        moveDir.x = statHandler.Speed;
        rigid.velocity = moveDir;
    }

    public override void Death()
    {
        base.Death();
        MiniGameManager.Instance.GameOver();
    }

    public void StopMove()
    {
        Vector2 moveDir = rigid.velocity;
        moveDir.x = 0f;
        rigid.velocity = moveDir;
    }

    void FollowCamera()
    {
        Vector3 camPos = Camera.main.transform.position;
        camPos.x = transform.localPosition.x + camOffsetX;

        Camera.main.transform.position = camPos;
    }

    void OnJump(InputValue inputValue)
    {
        if (inputValue.isPressed && rigid.velocity.y == 0)
            rigid.AddForce(Vector2.up * statHandler.JumpForce, ForceMode2D.Impulse);
    }
}
