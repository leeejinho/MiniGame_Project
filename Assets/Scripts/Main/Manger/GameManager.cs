using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UIManager uiManager;

    public PlayerController player { get; private set; }
    public ResourceController playerResource { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            player = FindAnyObjectByType<PlayerController>();

            playerResource = player.GetComponent<ResourceController>();
        }
        else
        {
            Instance.player.gameObject.SetActive(true);

            Destroy(gameObject);

            //// 새로운 Player 삭제
            //PlayerController newPlayer = FindAnyObjectByType<PlayerController>();

            //if (newPlayer == Instance.player)
            //{
            //    newPlayer = FindAnyObjectByType<PlayerController>();
            //    Destroy(newPlayer.gameObject);
            //}
            //else
            //    Destroy(newPlayer.gameObject);

        }

        Instance.uiManager = FindAnyObjectByType<UIManager>();
    }

    private void Start()
    {

    }

    public void LoadMiniGame()
    {
        player.gameObject.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }
}
