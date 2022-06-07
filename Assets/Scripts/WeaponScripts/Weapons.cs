using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
	public Snowball_Test[] loadout;    //Weapon loadout list, weapons 1,2,3,4.etc
	public Transform weaponParent;
	public Animator t_animation;

    private GameObject currentWeapon;
	private long nextThrowAllowed = 0;
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1)) EquipWeapon(0); //todo, genericize to allow potentially unlimited weapons.
		if (Input.GetKeyDown(KeyCode.Alpha2)) EquipWeapon(1);


		if (currentWeapon != null)
		{
			if(Input.GetMouseButtonDown(0))
			{
				if((long)Time.time < nextThrowAllowed) { return; }
				else
					Shoot();
			}
		}
	}

	void EquipWeapon(int p_ind)
	{
		if (currentWeapon != null) Destroy(currentWeapon);

		GameObject t_newEquipment = Instantiate(loadout[p_ind].prefab, weaponParent.position, weaponParent.rotation, weaponParent) as GameObject;          //Load in weapon, transform to player camera
		t_newEquipment.transform.localPosition = Vector3.zero;
		t_newEquipment.transform.localEulerAngles = Vector3.zero;

		currentWeapon = t_newEquipment;
		t_animation = currentWeapon.GetComponent<Animator>();
	}

	void Shoot()
	{
		WeaponInfo weaponInfo = currentWeapon.GetComponent<WeaponInfo>(); //should probably be made/assigned when weapon's switched
		t_animation.ResetTrigger("Throwing");

		t_animation.SetTrigger("Throwing");

		//woo
		nextThrowAllowed = (long)(Time.time + weaponInfo.throwCooldown + weaponInfo.throwDelay); //woo.
		Invoke("ProjectileSpawn",weaponInfo.throwDelay);

	}

	void ProjectileSpawn()
    {
		Transform t_origin = transform.gameObject.GetComponentInChildren<Camera>().transform;

		WeaponInfo weaponInfo = currentWeapon.GetComponent<WeaponInfo>(); //should probably be made/assigned when weapon's switched

		GameObject weaponProjectile;

		if(weaponInfo.projectileSpawnOverride == null)
			weaponProjectile = Instantiate(weaponInfo.projectilePrefab, t_origin.position, t_origin.rotation);
		else
			weaponProjectile = Instantiate(weaponInfo.projectilePrefab, weaponInfo.projectileSpawnOverride.position, t_origin.rotation);

		ProjectileInfo weaponProjectileInfo = weaponProjectile.GetComponent<ProjectileInfo>();
		if (weaponProjectileInfo != null) //important
		{
			weaponProjectileInfo.projectileOwnerLayer = 6; //magic number. do NOT change, this is the "player" layer.
		}

		Rigidbody ProjRigid = weaponProjectile.GetComponent<Rigidbody>();
		//print("CREATING BALL @" + weaponProjectile.transform.position);

		ProjRigid.AddForce(t_origin.forward * weaponInfo.throwDist);
		//everything done, we can now say we've successfully shot - cooldown time.

	}
}
