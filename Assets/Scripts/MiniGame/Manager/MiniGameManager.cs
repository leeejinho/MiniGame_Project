using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance;

    private GameManager gameManager;
    private ObjectManager objectManager;
    private UIManager uiManager;

    public MiniGamePlayerController player;
    public ResourceController playerResource;

    public bool gameStart = false;

    private void Awake()
    {
        Instance = this;

        gameManager = GameManager.Instance;
        objectManager = GetComponentInChildren<ObjectManager>();
        uiManager = FindAnyObjectByType<UIManager>();

        player = FindAnyObjectByType<MiniGamePlayerController>();
        playerResource = player.GetComponent<ResourceController>();
    }

    public void GameStart()
    {
        gameStart = true;

        uiManager.SetPlayGame();
        objectManager.StartSpawn();
    }

    public void GameOver()
    {
        gameStart = false;

        uiManager.SetGameOver();
        player.StopMove();
        objectManager.StopSpawn();

        // º¸»ó È¹µæ
        gameManager.playerResource.GetGold(playerResource.gold);
    }
}
