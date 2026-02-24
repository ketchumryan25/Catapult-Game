using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class IntermediateEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> ParticleEvent;
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;
    [SerializeField] private float speed;
    [SerializeField] private bool movingUp;

    public void Update()
    {
        if (movingUp)
        {
            MoveObjectUp(speed);
        }
        else
        {
            MoveObjectDown(speed);
        }
    }

    public void MoveObjectUp(float moveSpeed)
    {
        float deltaY = moveSpeed * Time.deltaTime;
        transform.localPosition += new Vector3(0, deltaY, 0);

        if (transform.localPosition.y >= maxHeight)
        {
            Vector3 maxPosition = new Vector3(transform.localPosition.x, maxHeight, transform.localPosition.z);
            transform.localPosition = maxPosition;
            float height = maxPosition.y;
            ParticleEvent.Invoke(height);
            movingUp = false;
        }
    }
    
    public void MoveObjectDown(float moveSpeed)
    {
        float deltaY = moveSpeed * Time.deltaTime;
        transform.localPosition += new Vector3(0, -deltaY, 0);

        if (transform.localPosition.y <= minHeight)
        {
            Vector3 minPosition = new Vector3(transform.localPosition.x, minHeight, transform.localPosition.z);
            transform.localPosition = minPosition;
            float height = minPosition.y;
            ParticleEvent.Invoke(height);
            movingUp = true;
        }
    }

}
