using UnityEngine;

public class Boxcast : MonoBehaviour
{
    [SerializeField] public float rayDistance = 10f;
    [SerializeField] public Vector2 boxSize;
    [SerializeField] public float boxAngle = 90f;
    [SerializeField] private GameObject hitParticleEffect;
    [SerializeField] private float minParticleLifetime = 0.1f;
    [SerializeField] private float maxParticleLifetime = 2f;
    RaycastHit2D hit;


    void FixedUpdate()
    {
        DrawBox();
    }

    void DrawBox()
    {
        Vector3 origin = transform.position;
        hit = Physics2D.BoxCast(transform.position, boxSize, boxAngle, transform.up, rayDistance);
        Vector3 hitPoint = new Vector3(hit.point.x, hit.point.y, 0f);
        if(hit.collider != null)
        {
            Debug.DrawRay(transform.position, hit.point, Color.white);
            Debug.Log($"Box Hit Object: {hit.collider.gameObject.name}\n" +
                      $"Box Hit Point: {hit.point}\n" +
                      $"Box Hit Normal: {hit.normal}");
                      
            GameObject particle = Instantiate(hitParticleEffect, hit.point, Quaternion.LookRotation(hit.normal));
  
            float hitX = hit.point.x;
            float hitY = hit.point.y;
            float hitZ = 0f;
                
            float originX = origin.x;
            float originY = origin.y;
            float originZ = 0f;

            Vector3 dirToOrigin = new Vector3
            (
                originX - hitX,
                originY - hitY,
                originZ - hitZ
            );

            if (dirToOrigin != Vector3.zero)
            {
                Quaternion rot = Quaternion.LookRotation(dirToOrigin);
                particle.transform.rotation = rot;
            }
            
            Destroy(particle, Random.Range(minParticleLifetime, maxParticleLifetime));  
        }
        else
        {
            Debug.DrawRay(transform.position, transform.position + transform.up * rayDistance, Color.black);
            Debug.Log("Box did not Hit");
        }
    }

}