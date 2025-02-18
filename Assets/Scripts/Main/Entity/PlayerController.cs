using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private Vector3 camOffset;

    private void Start()
    {
        camOffset =  Camera.main.transform.position - transform.localPosition;
    }

    protected override void Update()
    {
        base.Update();
        FollowCamera();
    }

    void FollowCamera()
    {
        Vector3 camPos = transform.position + camOffset;

        Camera.main.transform.position = camPos;
    }

    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;

        if (movementDirection.x != 0)
            lookDirection = movementDirection;
    }
}
