using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
     public static PlayerInput Instance;
     [SerializeField] private MoveAbility moveAbility;
     [SerializeField] private LookAbility lookAbility;
     [SerializeField] private ShootingAbility shootingAbility;
     [SerializeField] private JumpAbility jumpAbility;
     [SerializeField] private InteractAbility interactAbility;
     [SerializeField] private CommanderAbility commanderAbility;
     //Directional Inputs
     private Vector2 lookDirection;
     [SerializeField] private float mouseSensitivity;


     private void Awake() 
     {
          if(Instance == null)
          {
               Instance = this;
          }
          else
          {
               Destroy(gameObject);
          }     
     }

    
    void Start()
    {
          GetComponent<HealthSystem>().OnDead += () =>
          {
               //this.enabled = false;
          };     
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


          if(commanderAbility && Input.GetMouseButtonDown(1))
          {
              // commanderAbility.Command();
          }

    }

    public void EnableCuser()
    {
          Cursor.visible = true;
          Cursor.lockState = CursorLockMode.None;     
    }


}
