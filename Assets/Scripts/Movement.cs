using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    public float maxSpeed = 5;
    public float acceleration = 20;
    public float deacceleration = 4;

    Vector2 velocity;
    Vector2 rawInput;

    Rigidbody2D rb;

    public float points = 0;
    public TextMeshProUGUI pointsText;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pointsText.text = "Points: 0";
    }

    void Update()
    {
        rawInput.x = Input.GetAxisRaw("Horizontal");
        rawInput.y = Input.GetAxisRaw("Vertical");

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

        if (rawInput.sqrMagnitude == 0)
        {
            velocity *= 1 - deacceleration * Time.deltaTime;
        }

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
