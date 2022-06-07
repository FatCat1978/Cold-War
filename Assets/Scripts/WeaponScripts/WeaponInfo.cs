using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public int throwDist = 0; //TODO: rename throwSpeed
    public float throwDelay = 0; //how many seconds until the projectile is spawned - time for animation!
    public float throwCooldown = 0; //how many seconds until the projectile is allowed to be thrown again! adds the throwdelay by default, so don't bother, shitlord!
    public GameObject projectilePrefab; //what projectile are we using?
    public Transform projectileSpawnOverride = null; //if set, spawns the projectile here! sneaky!
}
