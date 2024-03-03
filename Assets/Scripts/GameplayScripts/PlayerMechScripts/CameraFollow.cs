using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    public Vector3 offset;
    Vector3 initialPos;
    void Start()
    {
        initialPos=transform.position;
        player=GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(player);
        transform.position=Vector3.MoveTowards(transform.position,new Vector3(player.position.x,player.position.y,initialPos.z)+offset,1f);
    }
}
