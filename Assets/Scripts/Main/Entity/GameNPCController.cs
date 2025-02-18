using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameNPCController : MonoBehaviour
{
    [SerializeField] private ActiveUI activeUI;
    
    private const string targetTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.tag.Equals(targetTag))
            return;

        // 상호작용 메세지 on
        activeUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.tag.Equals(targetTag))
            return;

        // 상호작용 메세지 off
        activeUI.SetActive(false);
    }
}
