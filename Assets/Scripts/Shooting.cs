using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject turret;
    public GameObject turretTip;
    public TextMeshProUGUI ammoText;
    public AudioClip shootingSound;

    private RaycastHit hit;
    private bool canShoot = true;
    private int ammo = 30;

    private void Start()
    {
        InvokeRepeating("AmmoRegen", 2.5f, 2.5f);
    }

    private void Update()
    {
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
        turret.transform.LookAt(hit.point);

        if (Input.GetMouseButton(0) && canShoot && ammo > 0 && !Camera.main.GetComponent<CameraMovement>().isPaused)
        {
            ammo--;
            ammoText.text = ammo.ToString();
            StartCoroutine("Shoot");
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;

        GameObject bulletObject = Instantiate(bullet, turretTip.transform.position, Quaternion.identity);
        bulletObject.GetComponent<Bullet>().GetDirection((hit.point - transform.position).normalized);

        yield return new WaitForSeconds(0.3f);
        canShoot = true;
    }

    private void AmmoRegen()
    {
        ammo++;
        ammoText.text = ammo.ToString();
    }

    public void BonusAmmo()
    {
        ammo += 10;
        ammoText.text = ammo.ToString();
    }

    public void StopShooting()
    {
        CancelInvoke();
        ammo = 0;
    }
}