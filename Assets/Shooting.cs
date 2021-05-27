using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public bool is_shooting = false;

    public float fireRate = 1f;
    private float nextFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (is_shooting && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shoot();

            is_shooting = false;
        }
    }
    void shoot()
    {
        if (this.name == "Talasum")
        {
            FindObjectOfType<AudioManager>().Play("HadoukenAttack");
        }
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }

    public void shoot_click()
    {
        is_shooting = true;
        
    }
}

