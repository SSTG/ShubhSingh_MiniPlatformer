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
    Vector3 initialPosition;
    void Start()
    {
        initialPosition=transform.position;
        MovePlatform();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
            if(environmentData.isDeadly)
            KillPlayer();
            else{
            other.gameObject.transform.SetParent(childObject);
        }
    }
    }
     void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag("Player")){
         other.gameObject.transform.SetParent(null);
        
       
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
            case EnvironmentData.MovementType.Horizontal: transform.DOMoveX(transform.position.x+environmentData.movementRange,environmentData.movementTime).
            SetLoops(-1, LoopType.Yoyo); break;
            case EnvironmentData.MovementType.Vertical : transform.DOMoveY(transform.position.y+environmentData.movementRange,environmentData.movementTime).
            SetLoops(-1, LoopType.Yoyo); 
            break;
        }
    }
}
