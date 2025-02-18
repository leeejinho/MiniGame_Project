using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlyerController : BaseController
{
    protected override void Update()
    {
        base.Update();
        FollowCamera();
    }
    void FollowCamera()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }

    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;

        if (movementDirection.x != 0)
            lookDirection = movementDirection;
    }
}
