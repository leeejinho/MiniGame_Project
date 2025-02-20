using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIState { Home, Game, GameOver }

public class UIManager : MonoBehaviour
{
    HomeUI homeUI;
    GameUI gameUI;
    GameOverUI gameOverUI;
    ShopController shopController;

    private UIState currentState;

    private void Awake()
    {
        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI?.Init(this);

        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI?.Init(this);

        gameOverUI = GetComponentInChildren<GameOverUI>(true);
        gameOverUI?.Init(this);

        shopController = GetComponentInChildren<ShopController>(true);

        ChangeState(UIState.Home);
    }

    public void SetPlayGame()
    {
        ChangeState(UIState.Game);
    }

    public void SetGameOver()
    {
        ChangeState(UIState.GameOver);
    }
  
    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI?.SetActive(currentState);
        gameOverUI?.SetActive(currentState);
    }

    public void ChangePlayerGold()
    {
        gameUI?.UpdateGoldText();
    }

    public void ShowShop()
    {
        shopController.Show();
    }
}
