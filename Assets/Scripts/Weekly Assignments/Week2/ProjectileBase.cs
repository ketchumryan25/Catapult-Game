using System;
using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    public int damage = 0;
    public bool isPiercing = false;
    private int speed = 0;
    protected int range = 0;
    protected int lifetime = 1;
    protected GameObject thisObject;

    private void DestroyProjectile()
    {
        Destroy(thisObject, lifetime);
    }
    
    public void CallDestroyProjectile()
    {
        DestroyProjectile();
    }

    public void SetSpeed(int newSpeed)
    {
        speed = newSpeed;
    }

    public void DebugSpeed()
    {
        Console.WriteLine("The Speed of this Projectile is" + speed);
    }
    
    protected void DebugDamage()
    {
        Console.WriteLine("The Speed of this Projectile is" + damage);
    }

    public abstract void AttachedObject();

    public virtual void DebugPiercing()
    {
        if (isPiercing == true)
        {
            Console.WriteLine("This Projectile has Piercing");
        }
        else
        {
            Console.WriteLine("This Projectile does not have Piercing");
        }
    }

}