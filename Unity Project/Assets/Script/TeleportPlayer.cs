using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject pointin;
    //public GameObject pointinUN;
    public GameObject pointout;
    public GameObject pointout2;
    //public GameObject pointout3;
    //public GameObject pointout4;

    public bool warpIn;
    //public bool intoUnderGround;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (warpIn)
            {
                this.transform.position = pointout.transform.position;
                // ถ้าชนบริเวณที่มีแท็ก pointin จะวาร์ปไปยังบริเวณที่มีแท็ก pointout
            }
            //if (intoUnderGround)
            //{
            //    this.transform.position = pointout3.transform.position;
            //}
        }        
    }    
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("pointin"))
        {
            if (transform.position.x > 0)
            {
                print("canWarpIN");
                warpIn = true;
            }

            if (transform.position.x < 0)
            {
                print("canWarpOUT");
                this.transform.position = pointout2.transform.position;
            }
        }
        //else if (collision.gameObject.CompareTag("pointinUN"))
        //{
        //    print("intoTheUnKnown");
        //    intoUnderGround = true;
        //}
        //else if (collision.gameObject.CompareTag("pointin3"))
        //{
        //    this.transform.position = pointout4.transform.position;
        //}
        else
        {
            warpIn = false;
            //intoUnderGround = false;
        }
    }
}
