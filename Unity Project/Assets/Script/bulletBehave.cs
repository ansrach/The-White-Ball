using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehave : MonoBehaviour
{
    private float speed = 10;
    private Player player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    void Update()
    {
        BulletMove();
    }
    void BulletMove()
    {
        if (player.moveRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (!player.moveRight)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("pipe"))
        {
            Destroy(gameObject);
        }
    }
}
