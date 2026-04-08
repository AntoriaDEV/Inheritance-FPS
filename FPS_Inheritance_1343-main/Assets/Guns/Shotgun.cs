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

        var b = Instantiate(bulletPrefab, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        b.GetComponent<Projectile>().Initialize(10f, 100f, 0.5f, 25f, null); // version without special effect
        //b.GetComponent<Projectile>().Initialize(1, 100, 2, 5, DoThing); // version with special effect

        Instantiate(prefabShotgunFire, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        Instantiate(prefabShotgunSmoke, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        anim.SetTrigger("shoot");
        elapsed = 0;
        ammo -= 1;

        return true;
    }
}
