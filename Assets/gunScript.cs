using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 50f;
    public static float ammo = 20f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public AudioClip gunShotSound;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = gunShotSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammo>=1.0f)
        {
            Shoot();
            ammo = ammo - 1;
            GetComponent<AudioSource>().PlayOneShot(gunShotSound);
        }

    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
           print(hit.transform.name);
           Target target = hit.transform.GetComponent<Target>();
            if (target !=null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 0.25f);
        }

    }
}
