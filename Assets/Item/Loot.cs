using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public ItemSO itemSO;
    public SpriteRenderer _sr;
    public Animator animator;
    public LayerMask player;
    public Rigidbody2D _rb;

    public int quantity;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnValidate()
    {
        if(itemSO == null)
            return;

        UpdateApperance();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((player.value & (1 << collision.gameObject.layer)) > 0)
        {
            _rb.velocity = Vector3.zero;
            _rb.gravityScale = 0;
            animator.Play("pickup");
            Destroy(gameObject,1f);
        }
    }

    private void UpdateApperance()
    {
        this.name = itemSO.name;
        _sr.sprite = itemSO.itemSprite;
    }
}
