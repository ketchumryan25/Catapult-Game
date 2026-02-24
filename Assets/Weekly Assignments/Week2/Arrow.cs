using System;
using UnityEngine;

public class Arrow : ProjectileBase
{
    void Start()
    {
        damage = 5;
        SetSpeed(4);
        range = 8;
        lifetime = 6;
        isPiercing = false;        
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
        Console.WriteLine("This is attached to a Arrow");
    }
    public override void DebugPiercing()
    {
        Console.WriteLine("This Arrow does not have Piercing");
    }

}