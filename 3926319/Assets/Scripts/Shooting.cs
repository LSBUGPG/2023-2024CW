using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public float bulletForce;
    private bool ableToShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ableToShoot == true)
        {
            Shoot();
            ableToShoot = false;
            StartCoroutine(ShootCoolDown());
        }
    }
    void Shoot()
    {
        GameObject instBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = instBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    IEnumerator ShootCoolDown()
    {
        yield return new WaitForSeconds(0.2f);
        ableToShoot = true;
    }
}
