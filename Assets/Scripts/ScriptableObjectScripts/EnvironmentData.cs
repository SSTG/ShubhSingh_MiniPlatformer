using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Environment Data")]
public class EnvironmentData : ScriptableObject
{
    // Start is called before the first frame update
    [Tooltip("How the platform will move, in what direction")]
    public MovementType movementType;

    [Tooltip("If the object will kill the player")]
    public bool isDeadly=false;
    [Tooltip("Range Of Movement")]
    public float movementRange;
    [Tooltip("Time taken to complete one journey")]
    public float movementTime;
    
    public enum MovementType{ Horizontal, Vertical};
   
}
