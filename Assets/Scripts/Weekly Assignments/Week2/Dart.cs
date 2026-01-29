using System;
using UnityEngine;

public class Dart : ProjectileBase
{
    void Start()
    {
        damage = 2;
        SetSpeed(2);
        range = 5;
        lifetime = 3;
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
        Console.WriteLine("This is attached to a Dart");
    }
    public override void DebugPiercing()
    {
        Console.WriteLine("This Dart does not have Piercing");
    }

}
