using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventHandler : MonoBehaviour
{
    private EventTrigger eventTrigger;
    private Vector3 originalScale;

    void Awake()
    {
        eventTrigger = gameObject.AddComponent<EventTrigger>();
        originalScale = transform.localScale;

#if UNITY_ANDROID || UNITY_IOS
        EventTrigger.Entry entry_PointerDown = new EventTrigger.Entry();
        entry_PointerDown.eventID = EventTriggerType.PointerDown;
        entry_PointerDown.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_PointerDown);

        EventTrigger.Entry entry_PointerUp = new EventTrigger.Entry();
        entry_PointerUp.eventID = EventTriggerType.PointerUp;
        entry_PointerUp.callback.AddListener((data) => { OnPointerUp((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_PointerUp);

#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX
        EventTrigger.Entry entry_PointerEnter = new EventTrigger.Entry();
        entry_PointerEnter.eventID = EventTriggerType.PointerEnter;
        entry_PointerEnter.callback.AddListener((data) => { OnPointerEnter((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_PointerEnter);

        EventTrigger.Entry entry_PointerExit = new EventTrigger.Entry();
        entry_PointerExit.eventID = EventTriggerType.PointerExit;
        entry_PointerExit.callback.AddListener((data) => { OnPointerExit((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_PointerExit);

#endif

        EventTrigger.Entry entry_Click = new EventTrigger.Entry();
        entry_Click.eventID = EventTriggerType.PointerClick;
        entry_Click.callback.AddListener((data) => { OnPointerClick((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_Click);
    }

#if UNITY_ANDROID || UNITY_IOS
    protected virtual void OnPointerDown(PointerEventData data)
    {
        transform.localScale = originalScale * 1.2f;
    }
    protected virtual void OnPointerUp(PointerEventData data)
    {
        transform.localScale = originalScale;
    }

 #elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX
    protected virtual void OnPointerEnter(PointerEventData data)
    {
        transform.localScale = originalScale * 1.2f;
    }
    protected virtual void OnPointerExit(PointerEventData data)
    {
        transform.localScale = originalScale;
    }

#endif

    protected virtual void OnPointerClick(PointerEventData data)
    {
        // UI Å¬¸¯
    }

}
