using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
     [SerializeField] private MoveAbility moveAbility;
     [SerializeField] private LookAbility lookAbility;
     [SerializeField] private ShootingAbility shootingAbility;
     [SerializeField] private JumpAbility jumpAbility;
     [SerializeField] private InteractAbility interactAbility;
     //Directional Inputs
     private Vector2 lookDirection;
     [SerializeField] private float mouseSensitivity;





    
    void Start()
    {
          // Control of mouse Cursor
          Cursor.visible = false;
          Cursor.lockState = CursorLockMode.Locked; //Locked to the center of the screen
    }

    
    void Update()
    {
          if (moveAbility)
          {
               //getting input for movement and moving the player
               moveAbility.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
          }
      
          if(lookAbility)
          {
               lookDirection.x += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
               lookDirection.y += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

               float angleOnY = lookDirection.y;
               lookDirection.y = Mathf.Clamp(angleOnY, -80, 80);

               lookAbility.Look(lookDirection);

          }
          
          if(shootingAbility != null && Input.GetMouseButtonDown(0))
          {

               shootingAbility.Shoot();
      
          }

          if(interactAbility && Input.GetKeyDown(KeyCode.F))
          {
               interactAbility.Interact();
          }

          if(Input.GetKeyDown(KeyCode.Space))
          {

               jumpAbility.Jump();

          } 

    }
}
