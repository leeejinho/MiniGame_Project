using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public enum NPCType { MiniGame, Shop }

public class NPCController : MonoBehaviour
{
    [SerializeField] private ActiveUI activeUI;
    [SerializeField] private NPCType npcType;

    private bool onTrigger = false;

    private const string targetTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(targetTag))
            return;

        // 상호작용 메세지 on
        activeUI.SetActive(true);
        onTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag(targetTag))
            return;

        // 상호작용 메세지 off
        activeUI.SetActive(false);
        onTrigger = false;
    }

    void OnActive()
    {
        if (!onTrigger) return;

        switch (npcType)
        {
            case NPCType.MiniGame:
                GameManager.Instance.LoadMiniGame();
                break;
            case NPCType.Shop:
                GameManager.Instance.uiManager.ShowShop();
                break;
        }
    }
}
