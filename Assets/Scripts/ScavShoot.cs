using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScavShoot : MonoBehaviour {

    public float reloadTime, accuracy, rateOfFire;
    public int mag;
    private float damage;
    private bool reload = false;
    private float timer, shotTimer = 0f;
    private int curMag = 0;

    public Transform aim;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    LineRenderer gunLine;

    void Start()
    {
        reloadTime = Random.Range(0.5f, 2.0f);
        accuracy = Random.Range(60f, 80f);
        rateOfFire = Random.Range(0.04f, 0.1f);
        mag = Random.Range(5, 20);

        damage = 4f;
        if (rateOfFire > 0.06f) damage += 2f;
        if (rateOfFire > 0.08f && rateOfFire < 0.11f) damage += 2f;
        if (accuracy < 74f) damage += 0.5f;
        if (accuracy < 68f) damage += 0.5f;
        if (accuracy < 64f) damage += 0.5f;

        shootableMask = LayerMask.GetMask("Default");
        gunLine = GetComponent<LineRenderer>();
        curMag = mag;
    }

    void Update()
    {
        if (reload == true) timer += Time.deltaTime;
        if (timer >= reloadTime) reload = false;
        else timer = 0f;

        if (timer == reloadTime) reload = false;
        shotTimer += Time.deltaTime;
    }

    public void disableShoot()
    {
        gunLine.enabled = false;
    }

    public void Shoot(int range)
    {
        if (shotTimer >= rateOfFire)
        {
            shotTimer = 0f;
            if (curMag == 0) reload = true;
            if (reload == false)
            {
                curMag -= 1;

                gunLine.enabled = true;
                gunLine.SetPosition(0, transform.position);

                shootRay.origin = aim.transform.position;
                shootRay.direction = aim.transform.right;

                if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
                {
                    playerHealth playerHealth = shootHit.collider.GetComponent<playerHealth>();
                    if (playerHealth != null) playerHealth.takeDamage(damage);
                    Vector3 shotPoint;
                    shotPoint.x = shootHit.point.x;
                    shotPoint.y = shootHit.point.y;
                    shotPoint.z = shootHit.point.z;
                    gunLine.SetPosition(1, shotPoint);
                }
                else
                {
                    gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
                }
            }
        }
    }
}
