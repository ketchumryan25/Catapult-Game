using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEvents : MonoBehaviour
{
    [SerializeField] private GameObject myApple;
    [SerializeField] private GameObject myOrange;
    [SerializeField] private GameObject myGrape;

    public void ToggleApple()
    {
        myApple.SetActive(!myApple.activeSelf);
    }

    public void ToggleOrange()
    {
        myOrange.SetActive(!myOrange.activeSelf);
    }

    public void ToggleGrape()
    {
        myGrape.SetActive(!myGrape.activeSelf);
    }

}
