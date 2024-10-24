using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ExitBtn : UIEventHandler
{
    protected override void OnPointerClick(PointerEventData data)
    {
#if UNITY_ANDROID
        Application.Quit();
        System.Diagnostics.Process.GetCurrentProcess().Kill();
#elif UNITY_WEBGL
        // Application.OpenURL("https://www.example.com"); // 원하는 페이지로 리다이렉트
#endif
    }
}
