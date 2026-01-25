using System;
using UnityEngine;

public class Bullet : ProjectileBase
{
    public int damage = 4;
    public Rigidbody rb;
    private int speed = 7;
    protected int range = 12;
    private string name;    

    protected override void ProjectileName()
    {
        string name = "Bullet";
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