using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class InputManager : Singleton<InputManager>
{
    // Start is called before the first frame update
    private bool isJumpPressed;
    private bool isDashPressed;
    public delegate void OnDirectionsPressed(float horizontal);
    public static event Action onJumpPressed;
    public static event Action onDashPressed;
    public static OnDirectionsPressed onDirectionsPressed;

    // Update is called once per frame
    void Update()
    {
        onDirectionsPressed?.Invoke(Input.GetAxis("Horizontal"));
        isJumpPressed=Input.GetKeyDown(KeyCode.Space);
        isDashPressed=Input.GetKeyDown(KeyCode.LeftShift);
        if(isJumpPressed)
        JumpPress();
        if(isDashPressed)
        DashPress();
    }
    void JumpPress()
    {
        Debug.Log("Jump");
        onJumpPressed?.Invoke();
    }
    void DashPress()
    {
        onDashPressed?.Invoke();
        Debug.Log("Dash");
    }
}
