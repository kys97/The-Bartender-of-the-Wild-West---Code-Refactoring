using UnityEngine;
using UnityEngine.UI;

public class Plate : MonoBehaviour
{
    Image Drink;

    private void OnEnable()
    {
        GameManager.OnUIInit += Init;
    }

    private void Init()
    {
        Drink = transform.GetComponentInChildren<Image>();
        Drink.sprite = null;
    }

    private void OnDisable()
    {
        GameManager.OnUIInit -= Init;
    }
}
