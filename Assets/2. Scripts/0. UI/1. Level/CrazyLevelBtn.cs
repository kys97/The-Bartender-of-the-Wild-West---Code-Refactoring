using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CrazyLevelBtn : UIEventHandler
{
    protected override void OnPointerClick(PointerEventData data)
    {
        // Level Set
        GameManager.GameLevel = 4;

        // Play Effect Sound
        GameManager.Instance.GetAudioManager.PlaySFX(EnumManager.SFXAudioName.GameStart.ToString());

        // Scene Load
        SceneManager.LoadScene(EnumManager.SceneName.Game.ToString());
    }
}
