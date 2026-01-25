using System;
using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    public int damage = 0;
    public Rigidbody rb;
    private int speed = 3;
    protected int range = 2;
    protected int playerHealth = 20;

    

    public int DealDamage()
    {
        return playerHealth -= damage;
    }

    private void DamageDealt()
    {
        int result = DealDamage();
        Console.WriteLine("Player Dealt", result);
    }

    protected void ProjectileForce()
    {
        rb.AddForce(Vector3.forward * range, ForceMode.Force);
        rb.velocity = transform.forward * speed;
    } 

    protected abstract void ProjectileName();

    public virtual void ProjectileUsed()    
    {
        Console.WriteLine("Player used nothing for", damage);
    }




}