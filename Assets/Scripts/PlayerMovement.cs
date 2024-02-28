using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField]float jumpForce;
    [SerializeField]float dashForce;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }
    void OnEnable()
    {
        InputManager.onDirectionsPressed+=MovePlayer;
        InputManager.onJumpPressed+=JumpPlayer;
        InputManager.onDashPressed+=DashPlayer;
    }
    void OnDisable()
    {
        InputManager.onDirectionsPressed-=MovePlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MovePlayer(float movement)
    {
        rb.velocity=new Vector3(movement,0,0);
    }
    void JumpPlayer()
    {
        rb.AddForce(new Vector3(0,jumpForce,0),ForceMode.Force);
    }
    void DashPlayer()
    {
        rb.AddForce(new Vector3(dashForce,0,0),ForceMode.Impulse);
    }
}
