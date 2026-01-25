using System;
using UnityEngine;

public class Arrow : ProjectileBase
{
    public int damage = 2;
    public Rigidbody rb;
    private int speed = 5;
    protected int range = 7;
    private string name;

    protected override void ProjectileName()
    {
        string name = "Arrow";
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