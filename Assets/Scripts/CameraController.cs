using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//camera math inspired by https://answers.unity.com/questions/666905/in-game-camera-movement-like-editor.html

public class CameraController : MonoBehaviour
{
    public float lookSpeedH = 2f;
    public float lookSpeedV = 2f;
    public float zoomSpeed = 2f;
    public float dragSpeed = 6f;
    public float moveSpeed = 14f;
    public float shiftMultipler = 3f;

    private float yaw = 0f;
    private float pitch = 0f;

    [SerializeField] InputField _pokemonSearchField;

    void Start()
    {
        pitch = transform.localEulerAngles.x;
        yaw = transform.localEulerAngles.y;
    }

    void Update()
    {
        //Only let camera have controls if mouse is not over UI
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            //Look around with Right Mouse
            if (Input.GetMouseButton(1))
            {
                yaw += lookSpeedH * Input.GetAxis("Mouse X");
                pitch -= lookSpeedV * Input.GetAxis("Mouse Y");

                transform.eulerAngles = new Vector3(pitch, yaw, 0f);
            }

            //drag camera around with Middle Mouse
            if (Input.GetMouseButton(2))
            {
                transform.Translate(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * dragSpeed, -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * dragSpeed, 0);
            }

            //Zoom in and out with Mouse Wheel
            transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, Space.Self);
        }

        //If typing in input field, do not move
        if(_pokemonSearchField.isFocused)
        {
            return;
        }

        //If left shift is held, ensure multiplier is active
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= shiftMultipler;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed /= shiftMultipler;
        }

        //Moving forward with WASD or arrow key
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        }

        //Moving backward with WASD or arrow key
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
        }

        //Moving left with WASD or arrow key
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }

        //Moving left with WASD or arrow key
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
