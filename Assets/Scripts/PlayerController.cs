using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform camTransform;
    public ParticleSystem muzzleFlash;

    private void Update()
    {
        if (Cursor.lockState != CursorLockMode.None)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ClientSend.PlayerShoot(camTransform.forward);
                muzzleFlash.Play();
            }
        }
    }

    private void FixedUpdate()
    {
        SendInputToServer();
    }

    private void SendInputToServer()
    {
        bool[] _inputs = new bool[]
        {
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.A),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.D),
            Input.GetKey(KeyCode.Space),
            Input.GetKey(KeyCode.LeftShift)
        };

        ClientSend.PlayerMovement(_inputs);
    }
}
