using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //Directional Inputs
    [SerializeField] private Vector2 lookDirection;
    [SerializeField] private Vector3 moveDirection;
    // Reference to 
    [SerializeField] private CharacterController controller;
    [SerializeField] private Camera head;
    [SerializeField] private float mouseSensitivity;
    //movemnet speed
    [SerializeField] private float movementSpeed;

    // Gravity and Jumpinh settings
    [SerializeField] private float gravityforce;
    [SerializeField] private float jumpForce;

    [SerializeField] private LayerMask groundLayer;

    [Header("Shooting setting")]
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Rigidbody ProjectilePrefab;
    [SerializeField] private float shootingForce;

    // Start is called before the first frame update
    void Start()
    {
        // Control of mouse Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; //Locked to the center of the screen
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection.x += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        lookDirection.y += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        float angleOnY = lookDirection.y;
        lookDirection.y = Mathf.Clamp(angleOnY, -80, 80);


        head.transform.localRotation = Quaternion.Euler(-lookDirection.y, 0, 0);
        transform.rotation = Quaternion.Euler(0, lookDirection.x, 0);
        

       moveDirection.x = Input.GetAxis("Horizontal");
       moveDirection.z = Input.GetAxis("Vertical");

       Vector3 forwardMovement = moveDirection.z * transform.forward;
       Vector3 sidewaysMovement = moveDirection.x * transform.right;
       Vector3 movementVector = forwardMovement + sidewaysMovement;

       bool isOnGround = Physics.CheckSphere(transform.position, 0.01f, groundLayer);

       if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
       {

            gravityforce = jumpForce;
            isOnGround = false;
       }


       controller.Move(movementVector * Time.deltaTime * movementSpeed);

       

       //Gravity is handled here
       if(!isOnGround)
       {
            gravityforce += -10f * Time.deltaTime;

            controller.Move(Vector3.up * gravityforce * Time.deltaTime);
       }
       else
       {
            // Reset Gravity once we get to the ground 
            gravityforce = 0;
       }

       if(Input.GetMouseButtonDown(0))
       {
            Rigidbody cloneRigidbody = Instantiate(ProjectilePrefab, weaponTip.position, weaponTip.rotation);
            cloneRigidbody.AddForce(weaponTip.forward * shootingForce);
            
       }

       

    }
}
