using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorialPanel : MonoBehaviour, IPointerClickHandler
{
    Image TutorialImage;
    int tutorial_index = 0;

    void Start()
    {
        gameObject.SetActive(false);

        if (!gameObject.activeSelf)
            Debug.Log("Active false");

        TutorialImage = GetComponent<Image>();
        TutorialImage.sprite = GameManager.Instance.GetResourceManager.TutorialImageList[tutorial_index];
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.GetAudioManager.PlaySFX(EnumManager.SFXAudioName.Button.ToString());

        if(++tutorial_index < GameManager.Instance.GetResourceManager.TutorialImageList.Length)
            TutorialImage.sprite = GameManager.Instance.GetResourceManager.TutorialImageList[tutorial_index];
        else
        {
            tutorial_index = 0;
            gameObject.SetActive(false);
            TutorialImage.sprite = GameManager.Instance.GetResourceManager.TutorialImageList[tutorial_index];
        }
    }
}
