using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DamageStarShip : MonoBehaviour
{
    public int damage = 1;

    [SerializeField]private Collider2D _col;
    [SerializeField] private LayerMask playerMask;

    public static event Action<int> addDamage;

    private void Awake()
    {
        if(_col == null)
            _col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((playerMask.value & (1 << collision.gameObject.layer)) > 0)
        {
            Debug.Log("DamageStart");
            addDamage?.Invoke(-damage);
        }
    }
}
