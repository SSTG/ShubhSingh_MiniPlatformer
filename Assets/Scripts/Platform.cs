using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]EnvironmentData environmentData;
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
        if(other.gameObject.CompareTag("Player") && environmentData.isDeadly)
        KillPlayer();
    }
    void KillPlayer(){Debug.Log("Dead!");}
    void MovePlatform()
    {
        switch(environmentData.movementType)
        {
            case EnvironmentData.MovementType.Horizontal: transform.DOMoveX(environmentData.movementRange,environmentData.movementTime).
            SetLoops(-1, LoopType.Yoyo); break;
            case EnvironmentData.MovementType.Vertical : transform.DOMoveY(environmentData.movementRange,environmentData.movementTime).
            SetLoops(-1, LoopType.Yoyo); 
            break;
        }
    }
}
