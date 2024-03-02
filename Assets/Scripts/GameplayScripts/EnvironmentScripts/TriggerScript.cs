using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent onTrigger;
    public UnityEvent onUntrigger;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        onTrigger?.Invoke();
    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        onUntrigger?.Invoke();
    }
}
