using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{

    [SerializeField] GameObject prefabShotgunSmoke;
    [SerializeField] GameObject prefabShotgunFire;
    public override bool AttemptFire()
    {
        if (!base.AttemptFire())
            return false;

        int bulletCount = 5;
        float angle = 10f;

        for (int i = 0; i < bulletCount; i++)
        {
            Vector2 randomCircle = Random.insideUnitCircle * angle;
            Quaternion spreadRotation = gunBarrelEnd.rotation * Quaternion.Euler(randomCircle.x, randomCircle.y, 0);

            var b = Instantiate(bulletPrefab, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);

            b.GetComponent<Projectile>().Initialize(20f, 100f, 0.5f, 10f, null);
        }

        Instantiate(prefabShotgunFire, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        Instantiate(prefabShotgunSmoke, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);

        anim.SetTrigger("shoot");
        elapsed = 0;
        ammo -= 1;

        return true;
    }
}
