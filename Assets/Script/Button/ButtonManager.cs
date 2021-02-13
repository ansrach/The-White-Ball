using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonManager : MonoBehaviour
{
    static Button buttonEventInvoker;
    static UnityAction buttonEventListener;

    public static void AddButtonEventInvoker(Button invoker)
    {
        buttonEventInvoker = invoker;
        if (buttonEventListener != null)
        {
            buttonEventInvoker.AddButtonEventListener(buttonEventListener);
        }
    }

    public static void AddButtonEventListener(UnityAction listener)
    {
        buttonEventListener = listener;
        if (buttonEventInvoker != null)
        {
            buttonEventInvoker.AddButtonEventListener(buttonEventListener);
        }
    }


}
