using System;
using UnityEngine;

public class Dart : ProjectileBase
{
    public int damage = 1;
    public Rigidbody rb;
    private int speed = 3;
    protected int range = 4;
    private string name;    

    protected override void ProjectileName()
    {
        string name = "Dart";
    }

    public override void ProjectileUsed()
    {
        Console.WriteLine("Player used", name, "for", damage);
    }

    public void Update()
    {
        if (range >= 0)
        {
            ProjectileForce();
            DealDamage();
            DamageDealt();
        }
    }




}