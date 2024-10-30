using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    TMP_Text MoneyText;

    private void OnEnable()
    {
        GameManager.OnUIInit += Init;
    }

    private void Init()
    {
        MoneyText = GetComponent<TMP_Text>();
        MoneyText.text = "0";
    }

    private void OnDisable()
    {
        GameManager.OnUIInit -= Init;
    }
}
