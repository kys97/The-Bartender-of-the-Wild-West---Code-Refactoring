using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public Sprite[] TutorialImageList { get; private set; }
    public List<Sprite> CustomerList { get; private set; }
    public Dictionary<string, Sprite> DrinkList { get; private set; }

    public void Init()
    {
        TutorialImageList = Resources.LoadAll<Sprite>("2. Sprite/Tutorial");
        CustomerList = new List<Sprite>(Resources.LoadAll<Sprite>("2. Sprite/Customer"));

        DrinkList = new Dictionary<string, Sprite>();
        foreach(Sprite drink in Resources.LoadAll<Sprite>("2. Sprite/Bottle"))
        {
            DrinkList.Add(drink.name, drink);
        }
    }
}
