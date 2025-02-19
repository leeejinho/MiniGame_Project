using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI goldText;

    private void Awake()
    {
        UpdateGoldText();
    }

    protected override UIState GetUIState()
    {
        return UIState.Game;
    }

    public void UpdateGoldText()
    {
        if (GameManager.Instance == null)
        {
            goldText.text = "0";
            return;
        }

        goldText.text = GameManager.Instance.playerResource.gold.ToString();
    }
}
