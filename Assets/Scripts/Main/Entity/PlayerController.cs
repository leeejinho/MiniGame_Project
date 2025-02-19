using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : BaseController
{
    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
    }

    protected override void Update()
    {
        base.Update();
        FollowCamera();
    }

    void FollowCamera()
    {
        Camera.main.transform.position = transform.position;
    }

    void OnMove(InputValue inputValue)
    {
        if (MiniGameManager.Instance.gameOver)
            return;

        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;

        if (movementDirection.x != 0)
            lookDirection = movementDirection;
    }

}
