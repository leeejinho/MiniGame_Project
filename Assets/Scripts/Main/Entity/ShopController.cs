using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hasKnight;
    [SerializeField] private TextMeshProUGUI hasLizard;
    [SerializeField] private TextMeshProUGUI failedMessage;

    [SerializeField] private Button btnElf;
    [SerializeField] private Button btnKinght;
    [SerializeField] private Button btnLizard;
    [SerializeField] private Button btnExit;

    private const string unlcokKnightKey = "Knight";
    private const string unlcokLizardKey = "Lizard";

    private const int priceKnight = 100;
    private const int priceLizard = 200;

    private bool unlockKnight = false;
    private bool unlockLizard = false;

    private void Awake()
    {
        btnExit.onClick.AddListener(OnClickExitButton);
        btnElf.onClick.AddListener(OnClickElfButton);
        btnKinght.onClick.AddListener(OnClickKnightButton);
        btnLizard.onClick.AddListener(OnClickLizardButton);

        unlockKnight = Convert.ToBoolean(PlayerPrefs.GetInt(unlcokKnightKey));
        unlockLizard = Convert.ToBoolean(PlayerPrefs.GetInt(unlcokLizardKey));

        if (unlockKnight)
        {
            btnKinght.GetComponentInChildren<TextMeshProUGUI>().text = "변경하기";
            hasKnight.text = "보유 중";
        }

        if (unlockLizard)
        {
            btnLizard.GetComponentInChildren<TextMeshProUGUI>().text = "변경하기";
            hasLizard.text = "보유 중";
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void OnClickExitButton()
    {
        gameObject.SetActive(false);
    }

    private void OnClickElfButton()
    {
        GameManager.Instance.playerResource.ChangeAnimType(AnimType.Elf);
        GameManager.Instance.player.ChangeAnim();
    }

    private void OnClickKnightButton()
    {
        int curGold = GameManager.Instance.playerResource.gold;

        if (unlockKnight)
        {
            GameManager.Instance.playerResource.ChangeAnimType(AnimType.Knight);
            GameManager.Instance.player.ChangeAnim();
        }
        else
        {
            if (curGold < priceKnight)
            {
                ShowMessage();
            }
            else
            {
                GameManager.Instance.playerResource.GetGold(-priceKnight);
                
                unlockKnight = true;
                PlayerPrefs.SetInt(unlcokKnightKey, Convert.ToInt32(unlockKnight));

                btnKinght.GetComponentInChildren<TextMeshProUGUI>().text = "변경하기";
                hasKnight.text = "보유 중";
            }
        }
    }

    private void OnClickLizardButton()
    {
        bool unlock = Convert.ToBoolean(PlayerPrefs.GetInt(unlcokLizardKey));
        int curGold = GameManager.Instance.playerResource.gold;

        if (unlock)
        {
            GameManager.Instance.playerResource.ChangeAnimType(AnimType.Lizard);
            GameManager.Instance.player.ChangeAnim();
        }
        else
        {
            if (curGold < priceLizard)
            {
                ShowMessage();
            }
            else
            {
                GameManager.Instance.playerResource.GetGold(-priceLizard);

                unlockLizard = true;
                PlayerPrefs.SetInt(unlcokLizardKey, Convert.ToInt32(unlockLizard));

                btnLizard.GetComponentInChildren<TextMeshProUGUI>().text = "변경하기";
                hasLizard.text = "보유 중";
            }
        }
    }

    private void ShowMessage()
    {
        TextMeshProUGUI message = Instantiate(failedMessage, transform);

        StartCoroutine(FadeText(message));
    }

    private IEnumerator FadeText (TextMeshProUGUI text)
    {
        Color alpha = text.color;

        float elapse = 0f;
        float fadeDuration = 2f;

        while (elapse < fadeDuration)
        {
            alpha.a = Mathf.Lerp(1, 0, elapse / fadeDuration);
            text.color = alpha;

            elapse += Time.deltaTime;

            yield return null;
        }

        Destroy(text.gameObject);
    }
}
