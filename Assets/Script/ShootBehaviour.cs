using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootBehaviour : MonoBehaviour
{
    [SerializeField] Text ammoText;

    [SerializeField] int maxAmmo;
    [SerializeField] int maxLoadedAmmo;
    [SerializeField] int currentAmmo;
    [SerializeField] int currentLoadedAmmo;

    [SerializeField] GameObject hitEffect;
    [SerializeField] Animator animator;

    [SerializeField] float fireRate;
    float coolDown = 0;

    bool isReloading = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isReloading) 
        {
            if (coolDown <= 0 && currentLoadedAmmo>=1) {
                Shoot();
            }
        }

        if (Input.GetButtonDown("Reload"))
        {
            Reload();
        }

        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }

        ammoText.text = currentLoadedAmmo + "/" + (currentAmmo-currentLoadedAmmo);
    }

    void Reload()
    {
        if (currentLoadedAmmo < maxLoadedAmmo && currentAmmo > 0)
        {
            animator.SetTrigger("Reload");
            isReloading = true;
        }
    }

    public void OnEndReload()
    {
        Debug.Log("End reload");
        isReloading = false;
        int toLoad = (currentAmmo >= maxLoadedAmmo) ? maxLoadedAmmo : currentAmmo;
        currentLoadedAmmo = toLoad;
    }

    void Shoot()
    {
        coolDown = fireRate;
        animator.SetTrigger("Shoot");
        currentLoadedAmmo--;
        currentAmmo--;
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward, out hit))
        {
            GameObject effect = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(effect, 2.0f);
        }
    }
}
