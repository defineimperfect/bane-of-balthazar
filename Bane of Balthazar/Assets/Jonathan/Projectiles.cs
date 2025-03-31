using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    //bullet
    public GameObject bullet;

    // bullet force
    public float shootForce, upwardForce;

    //Gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //bools 
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;

    //bug fixing
    public bool allowInvoke = true;

    private void Awake()
    {
        //make sure magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;

    }
    private void update()
    {
        Myinput();
    }
    private void Myinput()
    {
        //Check if allowed to hold down button and take corresponding input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //Set bullets shot to 0
            bulletsShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //Find the exact hit position during raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        //check if ray hits
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else targetPoint = ray.GetPoint(75);

        //Calculate direction from attackPoint to targetpoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        //Instantate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

        //Rotate bullet in shooting direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        bulletsLeft--;
        bulletsShot++;

        //invoke resetShot function
        if (allowInvoke)
        {
            Invoke("Resetshot", timeBetweenShooting);
            allowInvoke = false;

        }
    }
}