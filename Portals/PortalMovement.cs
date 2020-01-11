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

        StayOnScreen();
    }

    private void Move()
    {
        Vector3 direction = (new Vector3(x, 0, y) * Time.deltaTime) * moveSpeed;
        transform.Translate(direction, Space.World);
    }

    private void RecalculateMovement()
    {
        x = Random.Range(-1f, 1f);
        y = Random.Range(-1f, 1f);
    }

    private void StayOnScreen()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x <= 0.03f || pos.x >= 0.97 || pos.y <= 0.1f || pos.y >= 0.9f)
        {
            RecalculateMovement();
        }

        pos.x = Mathf.Clamp(pos.x, 0.03f, 0.97f);
        pos.y = Mathf.Clamp(pos.y, 0.1f, 0.9f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
