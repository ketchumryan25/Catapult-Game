using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AdjustFruit : MonoBehaviour
{
    public void UpdateFruit(float floatValue, Vector3 vector3Value)
    {
        transform.localScale = Vector3.one * floatValue;
        transform.localPosition = vector3Value;

        Debug.Log($"Fruit moved to {vector3Value} and scaled to {floatValue}");
    }
}
