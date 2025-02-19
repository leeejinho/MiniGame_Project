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

        if (GameManager.Instance != null)
        {
            GameManager gameManager = GameManager.Instance;

            gameManager.player.animController.runtimeAnimatorController = gameManager.playerResource.mainAnimController[(int)gameManager.playerResource.animType];
        }

        DontDestroyOnLoad(gameObject);
    }

    protected override void Update()
    {
        base.Update();
        FollowCamera();
    }

    void FollowCamera()
    {
        Vector3 campos = transform.position;
        campos.z = Camera.main.transform.position.z;

        Camera.main.transform.position = campos;
    }

    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;

        if (movementDirection.x != 0)
            lookDirection = movementDirection;
    }

}
