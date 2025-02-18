using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ActiveUI : MonoBehaviour
{
    [SerializeField] private GameObject target;
    RectTransform rect;

    private void Awake()
    {
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
        if (EventSystem.current.IsPointerOverGameObject())
            return;
    }
}
