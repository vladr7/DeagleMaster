using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeagleScript : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform shootPoint; 
    public int bulletSpeed;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetButtonDown("Fire1")) 
        {
            ShootBullet(direction.normalized);
        }
    }

    void ShootBullet(Vector2 direction)
    {
        if (bulletPrefab && shootPoint)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb)
            {
                rb.AddForce(direction * bulletSpeed);
            }
        }
    }
}