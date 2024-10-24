using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public Sprite[] TutorialImageList { get; private set; }

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


    }
}
