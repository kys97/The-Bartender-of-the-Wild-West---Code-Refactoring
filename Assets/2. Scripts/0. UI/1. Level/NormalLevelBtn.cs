using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NormalLevelBtn : UIEventHandler
{
    protected override void OnPointerClick(PointerEventData data)
    {
        // Level Set
        GameManager.GameLevel = 2;

        // Play Effect Sound
        GameManager.Instance.GetAudioManager.PlaySFX(EnumManager.SFXAudioName.GameStart.ToString());

        // Scene Load
        SceneManager.LoadScene(EnumManager.SceneName.Game.ToString());
    }
}
