using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameStartBtn : UIEventHandler
{
    protected override void OnPointerClick(PointerEventData data)
    {
        // Sound
        GameManager.Instance.GetAudioManager.PlaySFX(EnumManager.SFXAudioName.GameStart.ToString());
        
        // Scene
        SceneManager.LoadScene(EnumManager.SceneName.Level.ToString());
    }
}
