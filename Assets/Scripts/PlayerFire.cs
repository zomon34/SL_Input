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
            StartCoroutine(FireBulletVolley(bulletsToFire));
        }

        timer += Time.deltaTime;
    }

    IEnumerator FireBulletVolley(int numberOfBullets)
    {
        audioSource.pitch = Random.Range(0.75f, 1.25f);
        audioSource.Play();

        float playerZRotation = transform.eulerAngles.z;
        Vector2 staffHeadPosition = staffHeadTransform.position;

        for (int i = 0; i < numberOfBullets; i++)
        {
            if (numberOfBullets % 2 != 0)
            {
                Vector3 newRotation = GenerateBulletRotationVector(i, playerZRotation, -90);
                Instantiate(laserPrefab, staffHeadPosition, Quaternion.Euler(newRotation));
            }
            else
            {
                Vector3 newRotation = GenerateBulletRotationVector(i, playerZRotation, -93);
                Instantiate(laserPrefab, staffHeadPosition, Quaternion.Euler(newRotation));

                i++;

                newRotation = GenerateBulletRotationVector(i, playerZRotation, -93);
                Instantiate(laserPrefab, staffHeadPosition, Quaternion.Euler(newRotation));
            }
            
            yield return new WaitForSeconds(bulletFireDelay);
        }
    }

    // TODO: create a class that has this function or can be used as an argument
    // Replace the hardcoded 3 with a variable that is sent in as an argument
    // Also add an explanation or make the code simpler for future me
    Vector3 GenerateBulletRotationVector(int i, float zRotation, float baseZ)
    {
        float mod = i * 3 * 2;
        if (i % 2 == 0)
        {
            mod = 3 * -1;
        }
        return new Vector3(0, 0, baseZ - i * 3 + mod + zRotation);
    }

    class BulletVolley
    {
        // NOT FINISHED, no idea if this is even a reasonably solution, or if it's better
        int numberOfBullets;
        float playerZRotation;
        float baseZ;
        public List<BulletInVolley> bullets;


        public BulletVolley(int numberOfBullets, float playerZRotation, float baseZ)
        {
            this.numberOfBullets = numberOfBullets;

            for (int i = 0; i < numberOfBullets; i++)
            {
                BulletInVolley newBullet = new BulletInVolley(i, playerZRotation, baseZ);
                bullets.Add(newBullet);
            }
        }

    }

    class BulletInVolley
    {
        int positionInVolley;
        GameObject laserPrefab;
        Vector3 rotationVector;

        public BulletInVolley(int positionInVolley, float zRotation, float baseZ)
        {
            this.positionInVolley = positionInVolley;
            rotationVector = GenerateRotationVector(positionInVolley, zRotation, baseZ);
        }
        private Vector3 GenerateRotationVector(int i, float zRotation, float baseZ)
        {
            float mod = i * 3 * 2;
            if (i % 2 == 0)
            {
                mod = 3 * -1;
            }
            return new Vector3(0, 0, baseZ - i * 3 + mod + zRotation);
        }
    }
}
