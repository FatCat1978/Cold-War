using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
	public GameObject Player;
	public GameObject weaponProjectile;
	public GameObject weaponSpawn;
	public float Distance;
	public bool playerInRange;
	public Animator t_animation;

	public float throwSpeed = 1200;

	public NavMeshAgent _agent;
	long timeThrown;

	private float lookspeed = 3f;
	private Coroutine lookCoroutine;

	// Start is called before the first frame update
	void Start()
	{

	}

	private void FixedUpdate()
	{
		{
			Distance = Vector3.Distance(Player.transform.position, this.transform.position);


			if (Distance < 10)
			{
				playerInRange = true;
			}

			if (Distance > 10)
			{
				playerInRange = false;
				t_animation.ResetTrigger("Throwing");

			}

			if (playerInRange)
			{
				_agent.isStopped = true;
				_agent.SetDestination(Player.transform.position);
			}

			if (!playerInRange)
			{
				if(lookCoroutine != null)
					StopCoroutine(lookCoroutine);

				_agent.isStopped = false;
			}
			else
			{
				_agent.isStopped = true;
				lookCoroutine = StartCoroutine(LookTowards());
			}
			
			
			
			if (playerInRange)
			{
				if ((long)Time.time < timeThrown) { return; }
				else
				{
					Vector3 newDirection = Vector3.RotateTowards(this.transform.forward, Player.transform.position - this.transform.position, 360, 0.0f);
					transform.rotation = Quaternion.LookRotation(newDirection);
					t_animation.SetTrigger("Throwing");

				}
			}


		}
	}

	private IEnumerator LookTowards()
	{
		Transform target = Player.transform;
		Quaternion LookRotation = Quaternion.LookRotation(target.position - transform.position);
		float time = 0;
		while(time < 1)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation,LookRotation, time);
			time += Time.deltaTime * lookspeed;
			yield return null;
		}
	}	

	public void ThrowSnowball() //called via animation event so it's synched. 
		{

			GameObject projectileInstance = Instantiate(weaponProjectile, weaponSpawn.transform.position, weaponSpawn.transform.rotation);

			ProjectileInfo weaponProjectileInfo = weaponProjectile.GetComponent<ProjectileInfo>();

			Rigidbody ProjRigid = projectileInstance.GetComponent<Rigidbody>();

			Vector3 Aimpoint = Player.transform.position;
			Aimpoint.y += 2;

			weaponSpawn.transform.LookAt(Aimpoint);


			GameObject CH_BOY = this.transform.GetChild(0).gameObject;

			ProjRigid.AddForce(weaponSpawn.transform.forward * throwSpeed);
			//everything done, we can now say we've successfully shot - cooldown time.

			timeThrown = (long)(Time.time + 3); //woo.
		}
	}