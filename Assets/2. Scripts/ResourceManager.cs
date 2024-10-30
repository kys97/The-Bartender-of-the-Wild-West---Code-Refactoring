using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public Sprite[] TutorialImageList { get; private set; }
    public List<Sprite> CustomerList { get; private set; }
    public Dictionary<string, Sprite> DrinkList { get; private set; }

    public void Init()
    {
        SpriteSetting();
    }

    void Start()
    {

    }

    void SpriteSetting()
    {
        TutorialImageList = Resources.LoadAll<Sprite>("2. Sprite/Tutorial");

        CustomerList = new List<Sprite>();
        foreach(Sprite customer in Resources.LoadAll<Sprite>("2. Sprite/Customer"))
        {
            CustomerList.Add(customer);
        }

        DrinkList = new Dictionary<string, Sprite>();
        foreach(Sprite drink in Resources.LoadAll<Sprite>("2. Sprite/Bottle"))
        {
            DrinkList.Add(drink.name, drink);
        }
    }
}
