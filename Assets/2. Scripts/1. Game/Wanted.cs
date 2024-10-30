using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Wanted : MonoBehaviour
{
    Image[] WantedCriminals;

    int cutomer_cnt;

    private void OnEnable()
    {
        GameManager.OnUIInit += Init;
    }

    private void Init()
    {
        WantedCriminals = new Image[EnumManager.WANTED];
        cutomer_cnt = GameManager.Instance.GetResourceManager.CustomerList.Count;

        for (int i=0; i < EnumManager.WANTED; i++)
        {
            WantedCriminals[i] = transform.GetChild(i).GetComponentInChildren<Image>();
        }

        NewWantedCriminal();
    }

    private void NewWantedCriminal()
    {
        // TODO : 같은 수배범 나올 경우 배제해야함
        for(int i=0; i < EnumManager.WANTED; i++)
        {
            while (GameManager.Instance.WantedCriminals[i] == -1)
            {
                int new_criminal = Random.Range(0, cutomer_cnt);
                if(!Array.Exists(GameManager.Instance.WantedCriminals, element => element == new_criminal))
                {
                    GameManager.Instance.WantedCriminals[i] = new_criminal;
                    WantedCriminals[i].sprite = GameManager.Instance.GetResourceManager.CustomerList[new_criminal];
                }
            }
        }
    }

    private void OnDisable()
    {
        GameManager.OnUIInit -= Init;
    }
}
