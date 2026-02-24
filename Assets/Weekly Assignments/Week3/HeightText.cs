using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeightText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpText;

    public void UpdateText(float height)
    {
        string objectName = gameObject.name;
        string heightString = height.ToString();

        if (tmpText != null)
        {
            if (!string.IsNullOrEmpty(objectName))
            {
                tmpText.text = objectName + " Changed Direction after reaching " + heightString;
            }
            else
            {
                tmpText.text = "No Object";
            }
        }
    }
}
