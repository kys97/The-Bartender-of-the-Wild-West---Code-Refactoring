using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TutorialBtn : UIEventHandler
{
    [SerializeField] GameObject Tutorial_Panel;

    private void Start()
    {
        if (Tutorial_Panel == null)
        {
            Tutorial_Panel = FindAnyObjectByType<Canvas>().transform.Find("Tutorial_Pn").gameObject;
        }
    }

    protected override void OnPointerClick(PointerEventData data)
    {
        // Sound
        GameManager.Instance.GetAudioManager.PlaySFX(EnumManager.SFXAudioName.Tutorial.ToString());
        
        // Scene
        Tutorial_Panel.SetActive(true);
    }
}
