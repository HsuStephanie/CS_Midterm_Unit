using System;
using UnityEngine;

namespace MidtermTuringTest
{
    [RequireComponent(typeof(Camera))]
    public class CameraMovementBehavior : MonoBehaviour
    {
        [SerializeField] PlayerInput _input;
        [SerializeField] float turnSpeed;
        [SerializeField] bool invertedMouse;

        float _camXRotation;



        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //lock cursor to center and turn visibility off
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            RotateCamera();
        }

        void RotateCamera()
        {
            _camXRotation += Time.deltaTime * _input.mouseY * turnSpeed * (invertedMouse ? 1 : -1);
            _camXRotation = Mathf.Clamp(_camXRotation, -85f, 85f);
            transform.localRotation = Quaternion.Euler(_camXRotation, 0f, 0f);

        }

    }
}
 