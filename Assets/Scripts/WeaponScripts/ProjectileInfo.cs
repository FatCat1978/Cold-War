using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInfo : MonoBehaviour
{
	// Start is called before the first frame update
	
	public GameObject projectile;
	public int projectileDamage;
	public int projectileSpeed;
	public int projectileOwnerLayer = 7;

	public GameObject particleTrail;
	public GameObject particleImpactPrefab;

	void OnTriggerEnter(Collider other)
	{
		//see if we're hitting ourselves
		//layer
		int impactingLayer = other.gameObject.layer; //are we hitting ourselves/own team?

		if((impactingLayer == projectileOwnerLayer)) //if we are, abort!
		{
			return;
		}
		HittableInfo hit_target;
		if(impactingLayer == 6)
		{ 
		hit_target = other.gameObject.GetComponent<PlayerHittableInfo>();
		}
		else
		{
			print(other.name);
			hit_target = other.gameObject.GetComponentInChildren<HittableInfo>(); //TODO: 
			if(hit_target == null)
			{
				print("backup time!");

				Collider[] hitColliders = Physics.OverlapSphere(this.transform.position,3);

				foreach(var hitCollider in hitColliders)
				{
					hit_target = hitCollider.gameObject.GetComponent<HittableInfo>();
					if (hit_target != null)
						break;
				}

			}
		}                                                                     //destroy self again 
		print("HIT TARGET" + other);
		if (hit_target != null)
		{
			FindObjectOfType<Audio_Manager_Script>().Play("Light_Hit");
			hit_target.on_contact(this);
		}

		if(particleImpactPrefab != null)
			Instantiate(particleImpactPrefab, this.transform.position, this.transform.rotation);
		PreDeletion();
	}

	void PreDeletion()
	{
		{
			if(particleImpactPrefab != null)
			{
				
				GameObject Hnng = this.gameObject.transform.GetChild(0).gameObject;
				GameObject old = Hnng.transform.parent.gameObject;

				Hnng.transform.parent = null; //pls??
				Hnng.transform.localScale = old.transform.localScale;
				DeleteAfterDelay particleTimer = Hnng.GetComponent<DeleteAfterDelay>();
				ParticleSystem particleSystem = Hnng.GetComponent<ParticleSystem>();
				if(particleTimer != null)
				{
					particleTimer.delete_this();
				}

				if(particleSystem != null)
				{
					particleSystem.emissionRate = 0;
				}

				//Destroy(old);
				//Destroy(this.gameObject);
				print(this.gameObject);


			}
			this.gameObject.SetActive(false);
			Destroy(this.gameObject);
		}
	}
}
