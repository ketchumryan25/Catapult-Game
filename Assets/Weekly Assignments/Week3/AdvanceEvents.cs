using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class AdvanceEvents : MonoBehaviour
{
    [SerializeField] public UnityEvent<float, Vector3> AdvanceEvent;
    [SerializeField] private float yMinRange;
    [SerializeField] private float yMaxRange;
    [SerializeField] private float xMinRange;
    [SerializeField] private float xMaxRange;
    [SerializeField] private float minScaleFactor;
    [SerializeField] private float maxScaleFactor;

    public void Start()
    {
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var (floatValue, vector3Value) = RandomizeValues();
            AdvanceEvent.Invoke(floatValue, vector3Value);
        }
    }    

    public (float, Vector3) RandomizeValues()
    {
        float randomScaleFactor = Random.Range(minScaleFactor, maxScaleFactor);
        float randomFloatX = Random.Range(xMinRange, xMaxRange);
        float randomFloatY = Random.Range(yMinRange, yMaxRange);
        Vector3 randomPosition = new Vector3(randomFloatX, randomFloatY, transform.localPosition.z);
        return (randomScaleFactor, randomPosition);
    }

}
