using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum HUDType { Health, Gold }

public class HUD : MonoBehaviour
{
    [SerializeField] private HUDType type;
    [SerializeField] private List<Sprite> sprites;

    private Image[] images;
    private TextMeshProUGUI text;

    private void Awake()
    {
        images = GetComponentsInChildren<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case HUDType.Health:
                UpdateHealth();
                break;
            case HUDType.Gold:
                int curGold = MiniGameManager.Instance.playerResource.gold;
                text.text = "x " + curGold.ToString();
                break;
        }
    }

    private void UpdateHealth()
    {
        for (int i = 0; i < images.Length; i++)
        {
            if (i < MiniGameManager.Instance.playerResource.CurrentHealth)
            {
                images[i].sprite = sprites[1];
            }
            else
                images[i].sprite = sprites[0];
        }
    }
}
