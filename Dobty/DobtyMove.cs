using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DobtyMove : MonoBehaviour {

    public bl_Joystick Joystick;
    public float Speed = 1;

    private Camera cameraRect;
    private Vector3 up;
    private float height;

    private void Start()
    {
        up = transform.up;
        height = transform.position.y;
    }


    private void Update()
    {
        float v = Joystick.Vertical; 
        float h = Joystick.Horizontal;

        Vector3 direction = new Vector3(h, 0, v) * Time.deltaTime * Speed;

        if (direction != Vector3.zero)
        {
            MoveDobty(direction);
        }
  
        StayOnScreen();
    }

    private void MoveDobty(Vector3 direction)
    {
        transform.Translate(direction, Space.World);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction, up), 0.5f);
    }

    private void StayOnScreen()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.03f, 0.97f);
        pos.y = Mathf.Clamp(pos.y, 0.1f, 0.9f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }
}
