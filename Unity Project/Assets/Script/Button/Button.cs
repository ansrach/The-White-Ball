using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{

    ButtonEvent buttonEvent = new ButtonEvent();

    private void Start()
    {
        ButtonManager.AddButtonEventInvoker(this);
    }

    public void AddButtonEventListener(UnityAction listener)
    {
        buttonEvent.AddListener(listener);
    }

    public void ButtonClick()
    {
        print("Start");
        buttonEvent.Invoke();
    }
}
