using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour
{
    public GameObject jetpackPU;
    private CharacterController _charController;
    private Vector3 playerVelo;
    private bool grounded;
    private bool canJump;
    private bool sprinting = false;
    public bool jetpack = false;
    public float speed = 6.0f;
    public float grav = -9.8f;
    public float jumpHeight = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = _charController.isGrounded;
        if(grounded && canJump == false) canJump = true;
        if(grounded && playerVelo.y < 0) playerVelo.y = 0f;
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        if (Input.GetButtonDown("Jump") && canJump) {
            if(!jetpack) canJump = false;
            playerVelo.y = Mathf.Sqrt(jumpHeight * -3.0f * grav);
        }
        playerVelo.y += grav * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && !sprinting) { 
            speed *= 2; 
            sprinting = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && sprinting) {
            speed /= 2;
            sprinting = false;
        }

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
        _charController.Move(playerVelo * Time.deltaTime);
    }
}
