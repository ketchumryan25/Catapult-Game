using UnityEngine;

public class WheelControl : MonoBehaviour
{
    public Transform wheelModel;

    [HideInInspector] public WheelCollider WheelCollider;

    // Create properties for the CarControl script
    // (You should enable/disable these via the 
    // Editor Inspector window)
    public bool steerable;
    public bool motorized;

    Vector3 position;
    Quaternion rotation;

    // Start is called before the first frame update
    private void Start()
    {
        WheelCollider = GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the Wheel collider's world pose values and
        // use them to set the wheel model's position and rotation
        WheelCollider.GetWorldPose(out position, out rotation);
        wheelModel.transform.position = position;
        wheelModel.transform.rotation = rotation;
    }

    void FixedUpdate()
    {
        WheelHit hit;
        if (WheelCollider.GetGroundHit(out hit))
        {
            WheelFrictionCurve forwardFriction = WheelCollider.forwardFriction;
            WheelFrictionCurve sidewaysFriction = WheelCollider.sidewaysFriction;

            float groundFriction = hit.collider.material.staticFriction;
            forwardFriction.stiffness = groundFriction;
            sidewaysFriction.stiffness = groundFriction;

            WheelCollider.forwardFriction = forwardFriction;
            WheelCollider.sidewaysFriction = sidewaysFriction;
        }
    }
}
