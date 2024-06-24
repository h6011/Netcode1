using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(Rigidbody))]
public class PlayerNetwork : NetworkBehaviour
{
    private Rigidbody rb;

    private float moveSpeed = 10f;

    private bool isFirstPerson = true;




    private void Awake()
    {
        inital();
    }

    private void initalCamera()
    {
        Camera cam = Camera.main;
        Transform camTransform = cam.transform;

        camTransform.position = transform.position + Vector3.one * 5f;
        camTransform.SetParent(transform);
        camTransform.rotation = Quaternion.LookRotation(Vector3.one * -5);
    }

    private void inital()
    {
        rb = GetComponent<Rigidbody>();
        //initalCamera();
    }

    private void MoveCharacter()
    {
        float vertical = Input.GetAxisRaw("Vertical"); // w s
        float horizontal = Input.GetAxisRaw("Horizontal"); // a d

        Vector3 _vel = new Vector3(horizontal, 0, vertical) * moveSpeed;

        rb.velocity = _vel;

    }

    private void MoveCamera()
    {
        Camera MainCam = Camera.main;
        Transform MainCamTrs = MainCam.transform;

        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        Vector3 ve3 = new Vector3(-y, x, 0);
        MainCamTrs.Rotate(ve3);
    }

    private void FirstPersonAction()
    {
        if (isFirstPerson)
        {
            Camera MainCam = Camera.main;
            Transform MainCamTrs = MainCam.transform;
            MainCamTrs.SetParent(transform);

            MainCamTrs.position = transform.position;

            MoveCamera();

            


        }
    }


    private void Update()
    {
        if (!IsOwner) return;

        MoveCharacter();
        FirstPersonAction();

    }


}
