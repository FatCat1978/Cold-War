using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HittableInfo : MonoBehaviour
{
	//this is the base class. don't use this. ask connor.
	public int MaxHP;
	private int HP;

	private int TimeOfDeath; // how long ago did the character "die"? For despawning the ragdolls/other shit


	// Start is called before the first frame update
	void Start()
	{
		HP = MaxHP;
	}

	public abstract void on_contact(ProjectileInfo incomingProjectile);

	//TODO:
	//genericize this - have a "ondeath" script reference???
}
