using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemy;
    public float speed = 3;
    Transform target;
    Rigidbody2D rb;
    bool hit = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Laser>() != null && !hit)
        {
            hit = true;
            //float x = Random.Range(-10, 10);
            //float y = Random.Range(-10, 10);

            //Instantiate(enemy, new Vector2(x, y), transform.rotation);
            //Instantiate(enemy, new Vector2(-x, -y), transform.rotation);

            FindObjectOfType<EnemySpawner>().SpawnMoreEnemies();
            //Destroy(other.gameObject);
            Destroy(gameObject);
            //Invoke("Death", 0.01f);

        }
    }
    void Death()
    {
        Destroy(gameObject);
    }
}
