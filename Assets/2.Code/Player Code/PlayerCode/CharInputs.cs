using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharInputs : MonoBehaviour
{
    public event EventHandler <Vector2> OnInputMove;
    public event EventHandler <bool> OnInputJump;
    // public event EventHandler <bool> OnInputDash;


    private Vector2 _vc2 =  Vector2.zero;
    private bool jumpPressed;
    private bool dashPressed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputMove(_vc2);
        InputJump(jumpPressed);
    }
    void InputMove(Vector2 vc2)
    {
        vc2 = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        this._vc2 = vc2;
        OnInputMove?.Invoke(this, _vc2);
    }

    void InputJump(bool jumpPress)
    {
        jumpPress = Input.GetButtonDown("Jump");
        this.jumpPressed = jumpPress;

        OnInputJump?.Invoke(this, jumpPressed);
        
    }
    // void InputDash(bool dashPress)
    // {
    // dashPress = Input.GetButtonDown("Fire1");
    // this.dashPressed = dashPress;
    // OnInputDash?.Invoke(this, dashPressed);
    // 
    // }
}
