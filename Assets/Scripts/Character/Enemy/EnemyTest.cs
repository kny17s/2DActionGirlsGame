using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour,IDamagable
{
    public float _HitPoint = 100.0f;

    public void AddDamage(float damage)
    {
        _HitPoint -= damage;
        Debug.Log("add: " + damage + "hp: " + _HitPoint);

        if (_HitPoint <= 0)
        {
            Debug.Log("Enemy‚ð“|‚µ‚½");
        }
    }
}
