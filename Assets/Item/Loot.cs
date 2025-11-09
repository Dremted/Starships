using System;
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
    public Collider2D _col;

    public int quantity;

    public bool canBePicked = true;

    public static event Action<ItemSO, int> OnItemLooted;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _col = GetComponent<Collider2D>();
        if (_sr == null )
            GetComponent<SpriteRenderer>();
    }

    private void OnValidate()
    {
        if(itemSO == null)
            return;

        UpdateApperance();

    }

    public void Initialize(ItemSO itemSO, int quantity)
    {
        this.itemSO = itemSO;
        this.quantity = quantity;
        canBePicked = false;
        UpdateApperance();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((player.value & (1 << collision.gameObject.layer)) > 0 && canBePicked)
        {
            if (itemSO.isItem)
                OnItemLooted?.Invoke(itemSO, quantity);

            _rb.velocity = Vector3.zero;
            _rb.gravityScale = 0;
            animator.Play("pickup");
            _col.enabled = false;
            Destroy(gameObject,1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((player.value & (1 << collision.gameObject.layer)) > 0)
        {
            canBePicked = true;
        }
    }

    private void UpdateApperance()
    {
        if(this.name == null)
            this.name = itemSO.name;
        _sr.sprite = itemSO.itemSprite;
    }
}
