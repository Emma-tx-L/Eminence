using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMovement : MonoBehaviour {
    public float rotationSpeed = 30f;
    public float moveSpeed = 1f;
    public float movementInterval = 5f;

    private float timer = 0f;
    private float x;
    private float y;
    private float xScreenOffset = 0.2f;
    private float yScreenOffset = 0.2f;

    void Start()
    {
        timer = 0f;
        RecalculateMovement();
    }

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);

        if (timer >= movementInterval)
        {
            RecalculateMovement();
            timer = 0f;
        }
        else
        {
            Move();
            timer += Time.deltaTime;
        }

        CorrectPosition();
        StayOnScreen();
    }

    /// <summary>
    /// Moves portal towards a random direction at moveSpeed speed
    /// </summary>
    private void Move()
    {
        Vector3 direction = (new Vector3(x, 0, y) * Time.deltaTime) * moveSpeed;
        transform.Translate(direction, Space.World);
    }

    /// <summary>
    /// If Portals hit another Portal, move somewhere else
    /// </summary>
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Portal")
        {
            RecalculateMovement();
            timer = 0f;
        }
    }

    /// <summary>
    /// If Portals hit another Portal, move somewhere else
    /// </summary>
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Portal")
        {
            RecalculateMovement();
            timer = 0f;
        }
    }

    /// <summary>
    /// Ensures Portal stays flat on the plane
    /// </summary>
    private void CorrectPosition()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    /// <summary>
    /// Generates a random x and y for a random movement direction
    /// </summary>
    private void RecalculateMovement()
    {
        x = Random.Range(-1f, 1f);
        y = Random.Range(-1f, 1f);
    }

    /// <summary>
    /// Keeps Portal within xScreenOffset and yScreenOffset screen pixels away from screen edges
    /// </summary>
    private void StayOnScreen()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x <= xScreenOffset || pos.x >= 1-xScreenOffset || pos.y <= yScreenOffset || pos.y >= 1-yScreenOffset)
        {
            RecalculateMovement();
        }

        pos.x = Mathf.Clamp(pos.x, xScreenOffset, 1-xScreenOffset);
        pos.y = Mathf.Clamp(pos.y, yScreenOffset, 1-yScreenOffset);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
