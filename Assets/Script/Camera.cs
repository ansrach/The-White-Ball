using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float moveSpeed = 1;
    public Transform player;
    //public Transform followPlatform;
    //private Vector3 offset = new Vector3(0, 1, -5);

    void Update()
    {
        Vector3 newPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, moveSpeed); //ตรง moveSpeed ถ้าเติม * Time.deltaTime กล้องจะขยับเอง

        transform.LookAt(player);
        //followPlatform.position = new Vector3(Player.position.x, 0, 0) + offset;
    }
}
