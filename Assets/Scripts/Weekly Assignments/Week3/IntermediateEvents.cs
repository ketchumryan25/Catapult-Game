using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntermediateEvents : MonoBehaviour
{
    [SerializeField] private Slider mySlider;
    [SerializeField] private GameObject myKiwi;
    [SerializeField] private GameObject myBanana;
    [SerializeField] private GameObject myCherry;
    [SerializeField] private float indexFruit;
    [SerializeField] private float indexKiwi;
    [SerializeField] private float indexBanana;
    [SerializeField] private float indexCherry;

    public void SliderValue()
    {
        indexFruit = mySlider.value; 
    }
    
    public void ToggleFruit(float indexFruit)
    {
        if (indexFruit == indexCherry)
            {
                myCherry.SetActive(true);
                myKiwi.SetActive(false);
                myBanana.SetActive(false);
            }
        else if (indexFruit == indexKiwi)
            {
                myKiwi.SetActive(true);
                myBanana.SetActive(false);
                myCherry.SetActive(false);
            }
        else if (indexFruit == indexBanana)
            {
                myBanana.SetActive(true);
                myCherry.SetActive(false);
                myKiwi.SetActive(false);
            }
        else if (indexFruit != indexCherry && indexFruit != indexKiwi && indexFruit != indexBanana)
            {
                myBanana.SetActive(false);
                myCherry.SetActive(false);
                myKiwi.SetActive(false);
            }
    }

}
