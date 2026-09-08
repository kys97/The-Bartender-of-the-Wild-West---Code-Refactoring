using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public abstract class LevelButton : UIEventHandler
{
    protected abstract int Level { get; }

    protected override void OnPointerClick(PointerEventData data)
    {
        GameManager.GameLevel = Level;
        GameManager.Instance.GetAudioManager.PlaySFX(EnumManager.SFXAudioName.GameStart.ToString());
        SceneManager.LoadScene(EnumManager.SceneName.Game.ToString());
    }
}
