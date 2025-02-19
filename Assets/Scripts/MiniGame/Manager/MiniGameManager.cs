using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance;

    private GameManager gameManager;
    private ObjectManager objectManager;

    public MiniGamePlayerController player;

    public bool gameOver = false;

    private void Awake()
    {
        Instance = this;

        gameManager = GameManager.Instance;
        objectManager = GetComponentInChildren<ObjectManager>();

        player = FindAnyObjectByType<MiniGamePlayerController>();
    }

    private void Start()
    {
        GameStart();
    }

    private void Update()
    {
        // 임시 종료
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameOver();
        }
    }

    public void GameStart()
    {
        objectManager.StartSpawn();
    }

    public void GameOver()
    {
        gameOver = true;
        player.StopMove();
        objectManager.StopSpawn();
    }
}
