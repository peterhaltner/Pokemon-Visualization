using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//camera math inspired by https://answers.unity.com/questions/666905/in-game-camera-movement-like-editor.html

public class CameraController : MonoBehaviour
{
    public float _lookSpeedH = 2f;
    public float _lookSpeedV = 2f;
    public float _zoomSpeed = 50f;
    public float _dragSpeed = 80f;
    public float _moveSpeed = 50f;
    public float _shiftMultipler = 6f;

    float _yaw = 0f;
    float _pitch = 0f;
    bool _canMove;

    [SerializeField] InputField _pokemonSearchField;

    void Start()
    {
        SetMovementActive(true);
    }

    void Update()
    {
        //Only let camera have controls if mouse is not over UI
        if (!EventSystem.current.IsPointerOverGameObject() && _canMove)
        {
            //Look around with Right Mouse
            if (Input.GetMouseButton(1))
            {
                _yaw += _lookSpeedH * Input.GetAxis("Mouse X");
                _pitch -= _lookSpeedV * Input.GetAxis("Mouse Y");

                transform.eulerAngles = new Vector3(_pitch, _yaw, 0f);
            }

            //drag camera around with Middle Mouse
            if (Input.GetMouseButton(2))
            {
                transform.Translate(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * _dragSpeed, -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _dragSpeed, 0);
            }

            //Zoom in and out with Mouse Wheel
            transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed, Space.Self);
        }

        //If typing in input field, do not move
        if(_pokemonSearchField.isFocused)
        {
            return;
        }

        //If left shift is held, ensure multiplier is active
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            _moveSpeed *= _shiftMultipler;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            _moveSpeed /= _shiftMultipler;
        }

        //Moving forward with WASD or arrow key
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, _moveSpeed * Time.deltaTime);
        }

        //Moving backward with WASD or arrow key
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -_moveSpeed * Time.deltaTime);
        }

        //Moving left with WASD or arrow key
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-_moveSpeed * Time.deltaTime, 0, 0);
        }

        //Moving left with WASD or arrow key
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(_moveSpeed * Time.deltaTime, 0, 0);
        }
    }

    public void SetMovementActive(bool active)
    {
        _canMove = active;
        ResetPitchAndYaw();
    }

    public void ResetPitchAndYaw()
    {
        _pitch = transform.localEulerAngles.x;
        _yaw = transform.localEulerAngles.y;
    }
}
