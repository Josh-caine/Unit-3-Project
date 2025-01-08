using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAbility : MonoBehaviour
{

    [Header("Shooting setting")]
     [SerializeField] private Transform weaponTip;
     [SerializeField] private Rigidbody ProjectilePrefab;
     [SerializeField] private float shootingForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        Rigidbody cloneRigidbody = Instantiate(ProjectilePrefab, weaponTip.position, weaponTip.rotation);
        cloneRigidbody.AddForce(weaponTip.forward * shootingForce);
    }
}
