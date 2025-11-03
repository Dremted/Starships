using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public ItemSO itemSO;
    public SpriteRenderer _sr;
  
    public LayerMask player;

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
            Destroy(gameObject);
        }
    }

    private void UpdateApperance()
    {
        this.name = itemSO.name;
        _sr.sprite = itemSO.itemSprite;
    }
}
