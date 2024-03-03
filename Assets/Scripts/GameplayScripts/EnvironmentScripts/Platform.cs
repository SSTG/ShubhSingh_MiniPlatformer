using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]EnvironmentData environmentData;
    [SerializeField]Transform childObject;
    public UnityEvent onPlayerDeath;
    Rigidbody rb;
    Vector3 initialPosition;
    
    void Start()
    {
        initialPosition=transform.position;
        rb=GetComponent<Rigidbody>();
        MovePlatform();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player") && environmentData.isDeadly)
        {
            KillPlayer();
            
        }
       //other.gameObject.GetComponent<PlayerMovement>().MovePlayer(rb.velocity.x);
        //other.gameObject.GetComponent<PlayerMovement>().jumpForce-=rb.velocity.y;
    }
   
     
    void KillPlayer()
    {
        onPlayerDeath?.Invoke();
    Debug.Log("Dead!");
    }
    void MovePlatform()
    {
        switch(environmentData.movementType)
        {
            case EnvironmentData.MovementType.Horizontal: rb.DOMoveX(transform.position.x+environmentData.movementRange,environmentData.movementTime).
            SetLoops(-1, LoopType.Yoyo); break;
            case EnvironmentData.MovementType.Vertical : rb.DOMoveY(transform.position.y+environmentData.movementRange,environmentData.movementTime).
            SetLoops(-1, LoopType.Yoyo); 
            break;
        }
    }
}
