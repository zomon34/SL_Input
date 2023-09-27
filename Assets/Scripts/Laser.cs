using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject explosion;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position += transform.up * 8 * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject newExplosion = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(newExplosion, 0.5f);
        Destroy(gameObject);
    }
}
