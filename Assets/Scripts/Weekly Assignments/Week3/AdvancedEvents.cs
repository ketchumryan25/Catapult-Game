using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdvancedEvents : MonoBehaviour
{
    [SerializeField] private GameObject myLemon;
    [SerializeField] private GameObject myPeach;
    [SerializeField] private GameObject myCoconut;
    [SerializeField] private GameObject myFruitObject;
    [SerializeField] private TMP_InputField xInput;
    [SerializeField] private TMP_InputField yInput;
    [SerializeField] private TMP_Dropdown fruitDropdown;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float indexFruit;
    [SerializeField] private float indexLemon;
    [SerializeField] private float indexPeach;
    [SerializeField] private float indexCoconut;
    [SerializeField] private Vector3 fruitVector;
    [SerializeField] private float yMinRange;
    [SerializeField] private float yMaxRange;
    [SerializeField] private float xMinRange;
    [SerializeField] private float xMaxRange;

    public void Start()
    {
    }

    public void Update()
    {
    }

    void ValidVector()
    {
        float x, y;

        if (!float.TryParse(xInput.text, out x))
        {
            Debug.LogWarning("Invalid float in the X Input Field");
            return;
        }
        if (x < xMinRange || x > xMaxRange)
        {
            Debug.LogWarning($"X value {x} is out of range ({xMinRange} to {xMaxRange})");
            return;
        }

        if (!float.TryParse(yInput.text, out y))
        {
            Debug.LogWarning("Invalid float in Y Input Field");
            return;
        }
        if (y < yMinRange || y > yMaxRange)
        {
            Debug.LogWarning($"Y value {y} is out of range ({yMinRange} to {yMaxRange})");
            return;
        }

        fruitVector = new Vector3(x, y, 0f);
        Debug.Log("Created Vector3: " + fruitVector);        
    }

    public void SelectFruit()
    {
        int selectedValue = fruitDropdown.value;
        indexFruit = selectedValue;
        if (indexFruit == indexLemon)
            {
                myFruitObject = myLemon;
            }
        else if (indexFruit == indexPeach)
            {
                myFruitObject = myPeach;
            }
        else if (indexFruit == indexCoconut)
            {
                myFruitObject = myCoconut;
            }
        else if (indexFruit != indexLemon && indexFruit != indexPeach && indexFruit != indexCoconut)
        {
            myFruitObject = null;
        }
    }
    
    void MoveFruit()
    {
        if (myFruitObject != null)
        {
            myFruitObject.transform.position = fruitVector;
        }
    }  
    void EnableFruit()
    {
        if (myFruitObject != null)
        {
            myFruitObject.SetActive(true);
        }
    }  
    public void DisableFruit()
    {
        if (myFruitObject != null)
        {
            myFruitObject.SetActive(false);
        }
    }    

    public void SpawnFruit()
    {
        ValidVector();
        MoveFruit();
        EnableFruit();
    }


}
