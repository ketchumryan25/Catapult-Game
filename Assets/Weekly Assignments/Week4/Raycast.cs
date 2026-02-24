using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] public float rayDistance = 10f;
    [SerializeField] private GameObject hitParticleEffect;
    [SerializeField] private float minParticleLifetime = 0.1f;
    [SerializeField] private float maxParticleLifetime = 2f;
    RaycastHit2D hit;


    void FixedUpdate()
    {
        DrawRay();
    }

    void DrawRay()
    {
        Vector3 origin = transform.position;
        hit = Physics2D.Raycast(origin, transform.up, rayDistance);
        if(hit.collider != null)
        {
            Debug.DrawRay(origin, hit.point, Color.white);
            Debug.Log($"Ray Hit Object: {hit.collider.gameObject.name}\n" +
                      $"Ray Hit Point: {hit.point}\n" +
                      $"Ray Hit Normal: {hit.normal}");
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
            Debug.DrawRay(origin, origin + transform.up * rayDistance, Color.black);
            Debug.Log("Ray did not Hit");
        }
    }

}