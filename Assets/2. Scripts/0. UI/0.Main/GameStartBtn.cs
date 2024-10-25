using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameStartBtn : UIEventHandler
{
    protected override void OnPointerClick(PointerEventData data)
    {
        SceneManager.LoadScene(EnumManager.SceneName.Level.ToString());
    }
}
