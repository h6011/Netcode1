using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(Rigidbody))]
public class PlayerNetwork : NetworkBehaviour
{
    private Rigidbody rb;

    private float moveSpeed = 10f;

    private bool attachToCharacter = true;




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

    }

    private void attachToCharacterAction()
    {
        if (attachToCharacter)
        {
            Camera MainCam = Camera.main;
            Transform MainCamTrs = MainCam.transform;

            MainCamTrs.position = transform.position;
            MainCamTrs.rotation = transform.rotation;

        }
    }


    private void Update()
    {
        if (!IsOwner) return;

        MoveCharacter();
        attachToCharacterAction();

    }


}
