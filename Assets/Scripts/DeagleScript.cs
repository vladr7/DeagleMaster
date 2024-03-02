using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DeagleScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public int bulletSpeed;
    public List<ParticleSystem> shootSmokeList = new List<ParticleSystem>();
    public GameObject smokeUnderFeetPosition;
    public VisualEffect smokeUnderFeet;
    public AudioClip shootSoundClip; // Change to AudioClip

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
                PlayGunshotSound();
                PlaySmokeUnderFeetVFX();
                PlayShootSmokeVFX();
                rb.AddForce(direction * bulletSpeed);
            }
        }
    }

    private void PlayGunshotSound()
    {
        // Create a temporary GameObject to host the AudioSource component
        GameObject tempAudioSource = new GameObject("TempAudio");
        AudioSource audioSource = tempAudioSource.AddComponent<AudioSource>();
        audioSource.clip = shootSoundClip;
        audioSource.Play();

        // Destroy the temporary GameObject after the clip finishes playing
        Destroy(tempAudioSource, shootSoundClip.length);
    }

    private void PlaySmokeUnderFeetVFX()
    {
        smokeUnderFeet.transform.position = smokeUnderFeetPosition.transform.position;
        smokeUnderFeet.Play();
        smokeUnderFeet.transform.parent = null;
    }

    private void PlayShootSmokeVFX()
    {
        int index = 0;

        while (index < shootSmokeList.Count)
        {
            shootSmokeList[index].Play();
            index++;
        }
    }
}
