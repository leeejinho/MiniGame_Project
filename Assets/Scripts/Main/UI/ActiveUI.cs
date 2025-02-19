using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class ActiveUI : MonoBehaviour
{
    [SerializeField] private GameObject target;
    RectTransform rect;

    private void Awake()
    {
        target = GameManager.Instance.player.gameObject;
        rect = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        if (gameObject.activeSelf)
            rect.position = Camera.main.WorldToScreenPoint(target.transform.position);
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    void OnActiveGame()
    {
        GameManager.Instance.LoadMiniGame();
    }
}
