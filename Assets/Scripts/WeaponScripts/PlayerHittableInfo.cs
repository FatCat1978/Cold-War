using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHittableInfo : HittableInfo
{
    public int HP;
    public override void on_contact(ProjectileInfo incomingProjectile)
	{
        if (incomingProjectile == null) //should NEVER happen. ever. at all.
        {
            return;
        }
        print("OW!");
        HP -= incomingProjectile.projectileDamage;
        print(HP);
        if (HP > 0)
            return;
    }

	// Start is called before the first frame update
	void Start()
    {
        HP = MaxHP;
    }
}
