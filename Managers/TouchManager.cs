using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {

    public GameObject Joystick;
    public GameObject canvas;

    private RectTransform joystickRect;
    private RectTransform canvasRect;
    private Vector2 uiOffset;

    void Start () {
        joystickRect = GetComponent<RectTransform>();
        canvasRect = canvas.GetComponent<RectTransform>();
        uiOffset = new Vector2((float)canvasRect.sizeDelta.x / 2f, (float)canvasRect.sizeDelta.y / 2f);

    }
	
	void Update () {

        if (Input.touchCount > 0)
        {
            Debug.Log("touched the screen");
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Joystick.SetActive(true);
                Vector3 tapPosition = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, transform.position.z);
                MoveToClickPoint(tapPosition);
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Joystick.SetActive(false);
            }

        }

    }

    public void MoveToClickPoint(Vector3 tapPosition)
    {
        // Get the position on the canvas
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(tapPosition);
        Vector2 proportionalPosition = new Vector2(ViewportPosition.x * canvasRect.sizeDelta.x, ViewportPosition.y * canvasRect.sizeDelta.y);

        // Set the position and remove the screen offset
        joystickRect.localPosition = proportionalPosition - uiOffset;
    }
}
