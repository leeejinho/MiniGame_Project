using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hasKnight;
    [SerializeField] private TextMeshProUGUI hasLizard;

    [SerializeField] private Button btnElf;
    [SerializeField] private Button btnKinght;
    [SerializeField] private Button btnLizard;
    [SerializeField] private Button btnExit;

    private void Awake()
    {
        btnExit.onClick.AddListener(OnClickExitButton);

        btnKinght.GetComponentInChildren<TextMeshProUGUI>().text = "º¸À¯Áß";
    }

    public void OnClickExitButton()
    {
        this.gameObject.SetActive(false);
    }
}
