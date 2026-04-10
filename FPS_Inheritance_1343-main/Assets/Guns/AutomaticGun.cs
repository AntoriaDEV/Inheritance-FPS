using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticGun : Gun
{

    [SerializeField] GameObject AutomaticFire;
    [SerializeField] GameObject AutomaticSmoke;

    public override bool AttemptFire()
    {
        if (!base.AttemptFire())
            return false;

        var b = Instantiate(bulletPrefab, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        b.GetComponent<Projectile>().Initialize(3, 100, 2, 2, null);

        Instantiate(AutomaticFire, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        Instantiate(AutomaticSmoke, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);

        anim.SetTrigger("shoot");
        elapsed = 0;
        ammo -= 1;

        return true;
    }
}
