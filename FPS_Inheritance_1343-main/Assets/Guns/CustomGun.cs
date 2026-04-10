using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGun : Gun
{

    [SerializeField] GameObject AutomaticFire;
    [SerializeField] GameObject AutomaticSmoke;
    public override bool AttemptFire()
    {
        if (!base.AttemptFire())
            return false;

        var b = Instantiate(bulletPrefab, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        b.GetComponent<Projectile>().Initialize(3, 100, 2, 5, RandomForce);

        Instantiate(AutomaticFire, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        Instantiate(AutomaticSmoke, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);

        anim.SetTrigger("shoot");
        elapsed = 0;
        ammo -= 1;

        return true;
    }

    void RandomForce(HitData data) {
        Vector3 impactLocation = data.location;

        var colliders = Physics.OverlapSphere(impactLocation, 1f);

        foreach (var c in colliders)
        {
            Rigidbody rb = c.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 randomDirection = Random.onUnitSphere;
                rb.AddForce(randomDirection * 50f, ForceMode.Impulse);
            }
        }
    }
}