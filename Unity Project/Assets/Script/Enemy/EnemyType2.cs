using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType2 : Enemy
{
    protected override void EnemyMove()
    {
        if (moveRight)
        {
            transform.Translate(0, 2 * Time.deltaTime * enemySpeed, 0);
        }
        else
        {
            transform.Translate(0, -2 * Time.deltaTime * enemySpeed, 0);
        }
    }
}
