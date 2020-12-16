using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickerMoverQ1_3 : TargetMoverQ1_3
{
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Moves the player to the target clicked block
            Vector3 newTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SetTarget(newTarget);
        }
    }
}
