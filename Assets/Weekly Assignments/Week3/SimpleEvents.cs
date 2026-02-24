using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SimpleEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent ToggleState;
    [SerializeField] private Button myButton;

    public void Start()
    {
        if (myButton != null)
        {
            myButton.onClick.AddListener(InvokeUnityEvent);
        }
    }

    public void InvokeUnityEvent()
    {
        ToggleState.Invoke();
    }

}
