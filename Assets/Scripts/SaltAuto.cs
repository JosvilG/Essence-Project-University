using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltAuto : MonoBehaviour
{

    public float jumpForce;
    public CharacterController player;
    public float playerSpeed;
    public Vector3 movePlayer;
    public bool comp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)//quan el jugador ho toca li treu el control i fa el seguent
    {
        //player.enabled = false;
        comp = true;
        movePlayer = new Vector3(-5, 10, 0);
        movePlayer = movePlayer * playerSpeed;
        player.Move(movePlayer * Time.deltaTime);

    }
}
