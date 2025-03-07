using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
        public GameObject player;
        public Transform spawn;
        public HealthSystem healthSystem;
        [SerializeField] private PlayerInput playerInput;
        

    // Update is called once per frame
    void Update()
    {

        GetComponent<HealthSystem>().OnDead += () =>
        {
            RespawnPlayer();
            healthSystem.currentHealth = 100;
        };
    }

    private void RespawnPlayer()
    {
        player.SetActive(false);
        player.transform.position = spawn.transform.position;
        player.SetActive(true);
    
        
        
    }
}
