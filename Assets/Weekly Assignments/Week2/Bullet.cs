using System;
using UnityEngine;

public class Bullet : ProjectileBase
{
    void Start()
    {
        damage = 9;
        SetSpeed(8);
        range = 15;
        lifetime = 10;
        isPiercing = true;        
    }

    void ProjectileLifeCycle()
    {
        CallDestroyProjectile();
    }

    public void DebugStats()
    {
        DebugDamage();
        DebugSpeed();
    }

    public override void AttachedObject()
    {
        Console.WriteLine("This is attached to a Bullet");
    }
    public override void DebugPiercing()
    {
        Console.WriteLine("This Bullet does have Piercing");
    }

}
