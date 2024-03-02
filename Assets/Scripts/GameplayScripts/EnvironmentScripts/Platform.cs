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
    FixedJoint fixedJoint;
    void Start()
    {
        initialPosition=transform.position;
        rb=GetComponent<Rigidbody>();
        MovePlatform();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Velocity "+GetComponent<Rigidbody>().velocity);
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player") && environmentData.isDeadly)
        {
            KillPlayer();
            
        }
        
    // if(environmentData.movementType==EnvironmentData.MovementType.Horizontal)
    other.transform.SetParent(childObject,true);
     other.gameObject.GetComponent<Rigidbody>().isKinematic=true;
    }
     void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag("Player")){
        other.gameObject.GetComponent<Rigidbody>().isKinematic=false;
        
       
    }
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
