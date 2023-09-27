using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    public float maxSpeed = 5;
    public float acceleration = 20;
    public float deacceleration = 4;

    //float speed = 6;

    Vector2 position;
    Vector2 velocity;
    Vector2 rawInput;

    Vector2 startPos;

    Rigidbody2D rb;

    Camera cam;
    float height;
    float width;

    public float points = 0;
    public TextMeshProUGUI pointsText;

    private void Start()
    {
        startPos = transform.position;
        position = startPos;

        cam = Camera.main;

        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;

        rb = GetComponent<Rigidbody2D>();

        pointsText.text = "Points: 0";
    }

    void Update()
    {
        rawInput.x = Input.GetAxisRaw("Horizontal");
        rawInput.y = Input.GetAxisRaw("Vertical");
        //acceleration.x += Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        //acceleration.y += Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        //if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        //{
        //    acceleration = velocity * -1;
        //}

        if (rawInput.sqrMagnitude > 1 )
        {
            rawInput.Normalize();
        }

        velocity += rawInput * acceleration * Time.deltaTime;

        if (velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }

        if (rawInput.x == 0 && rawInput.y == 0)
        {
            velocity *= 1 - deacceleration * Time.deltaTime;
        }

        //velocity += acceleration * Time.deltaTime;

        //velocity = Vector2.ClampMagnitude(velocity, maxSpeed);
        //acceleration = Vector2.ClampMagnitude(acceleration, maxSpeed);

        //if (velocity.magnitude < 0.001f)
        //{
        //    velocity = Vector2.zero;
        //}

        //position += velocity * Time.deltaTime;


        //if (transform.position.x < startPos.x - width / 2)
        //{
        //    transform.position = new Vector2(startPos.x + width / 2, transform.position.y);
        //}

        //if (transform.position.x > startPos.x + width / 2)
        //{
        //    transform.position = new Vector2(startPos.x - width / 2, transform.position.y);
        //}

        //if (position.y + 0.5f > startPos.y + height / 2)
        //{
        //    velocity.y = 0;
        //}

        //if (position.y - 0.5f < startPos.y - height / 2)
        //{
        //    velocity.y = 0;
        //}

        //transform.position = position;
        rb.velocity = velocity;
        pointsText.text = "Points: " + points.ToString();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            Destroy(other.gameObject);
            points++;
        }

    }

}
