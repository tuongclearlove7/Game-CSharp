using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : Singleton<controls>
{
    public bool isOnMobile;
    bool left;
    bool right;
    
    public bool Moveleft { get => left; set => left = value; }
    public bool Moveright { get => right; set => right = value; }
    private void Update()
    {
        if (!isOnMobile)
            PCHandle();
        
    }
    void PCHandle()
    {
        left = Input.GetAxisRaw("Horizontal") < 0;
        right = Input.GetAxisRaw("Horizontal") > 0;

    if(left){
            Debug.Log("You are moving left");
        }
    else if(right){
            Debug.Log("You are moving right");
        }
    }
}




