using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHittableInfo : HittableInfo
{
    private int HP;
    private GameObject _hitUI;
    private HitMarkerHandler _hitImage;

    private void Start()
    {
        HP = MaxHP;
        _hitUI = GameObject.Find("HitHost");
        _hitImage = _hitUI.GetComponent<HitMarkerHandler>();
    }
    public override void on_contact(ProjectileInfo incomingProjectile)
    {
        

        if (incomingProjectile == null) //should NEVER happen. ever. at all.
        {
            return;
        }

        HP -= incomingProjectile.projectileDamage;
        if (HP > 0)
        {
            _hitImage._fixedTimer = 0;
            _hitImage.showHit = true;
            return;
        }

        _hitImage._fixedTimer = 0;
        _hitImage.showFinish = true;
        

        Animator KidAnimator = GetComponentInChildren<Animator>();
        KidAnimator.enabled = false;
        CapsuleCollider caps = GetComponent<CapsuleCollider>();
        caps.enabled = false;
        Enemy_AI AI = GetComponent<Enemy_AI>();
        AI.enabled = false;
    }

}
