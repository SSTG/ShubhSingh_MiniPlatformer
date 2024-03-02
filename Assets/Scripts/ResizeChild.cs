using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale=new Vector3(transform.localScale.x/transform.parent.localScale.x,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
