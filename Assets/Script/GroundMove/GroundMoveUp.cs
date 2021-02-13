using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoveUp : GroundMove
{
    protected override void GroundMovee()
    {
        if (moveRight)
        {
            transform.Translate(0, 2 * Time.deltaTime * boxSpeed, 0);
        }
        else
        {
            transform.Translate(0, -2 * Time.deltaTime * boxSpeed, 0);
        }
    }    
}


