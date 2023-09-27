using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform staffHeadTransform;

    public float fireRate = 0.5f;
    public int bulletsToFire = 3;
    public float bulletFireDelay = 0.01f;

    float timer;

    public AudioClip[] laserAudio;
    AudioSource audioSource;

    void Start()
    {
        timer = fireRate;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        transform.right = direction;

        if (Input.GetMouseButton(0) && timer >= fireRate)
        {
            timer = 0;
            StartCoroutine(FireBullets(bulletsToFire));
        }

        timer += Time.deltaTime;
    }

    IEnumerator FireBullets(int numberOfBullets)
    {
        audioSource.pitch = Random.Range(0.75f, 1.25f);
        audioSource.Play();

        float playerZRotation = transform.eulerAngles.z;
        Vector2 staffHeadPosition = staffHeadTransform.position;

        for (int i = 0; i < numberOfBullets; i++)
        {
            if (numberOfBullets % 2 != 0)
            {
                Vector3 newRotation = GenerateBulletRotationVector(i, playerZRotation, 3, -90);
                Instantiate(laserPrefab, staffHeadPosition, Quaternion.Euler(newRotation));
            }
            else
            {
                Vector3 newRotation = GenerateBulletRotationVector(i, playerZRotation, 3, -93);
                Instantiate(laserPrefab, staffHeadPosition, Quaternion.Euler(newRotation));

                i++;

                newRotation = GenerateBulletRotationVector(i, playerZRotation, 3, -93);
                Instantiate(laserPrefab, staffHeadPosition, Quaternion.Euler(newRotation));
            }
            
            yield return new WaitForSeconds(bulletFireDelay);
        }
    }

    // TODO: decrease the amount of arguments this needs (probably best solved with a new class)
    // Also add an explanation or make the code simpler for future me
    Vector3 GenerateBulletRotationVector(int i, float zRotation, float angleVariance, float baseZ)
    {
        float mod = i * angleVariance * 2;
        if (i % 2 == 0)
        {
            mod = angleVariance * -1;
        }
        return new Vector3(0, 0, baseZ - i * angleVariance + mod + zRotation);
    }
}
