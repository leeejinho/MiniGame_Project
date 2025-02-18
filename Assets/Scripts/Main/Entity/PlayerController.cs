using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : BaseController
{
    private float camOffsetX;

    private void Start()
    {
        // ī�޶� ��ġ 
        camOffsetX =  Camera.main.transform.position.x - transform.localPosition.x;
    }

    protected override void Update()
    {
        base.Update();
        FollowCamera();
    }

    protected override void FixedUpdate()
    {
        //base.FixedUpdate();
        Vector2 moveDir = rigid.velocity;
        moveDir.x = statHandler.Speed;

        rigid.velocity = moveDir;
    }

    void FollowCamera()
    {
        Vector3 camPos = Camera.main.transform.position;
        camPos.x = transform.localPosition.x + camOffsetX;

        Camera.main.transform.position = camPos;
    }

    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;

        if (movementDirection.x != 0)
            lookDirection = movementDirection;
    }

    void OnJump(InputValue inputValue)
    {
        if (inputValue.isPressed)
            rigid.AddForce(Vector2.up * statHandler.JumpForce, ForceMode2D.Impulse);
    }
}
