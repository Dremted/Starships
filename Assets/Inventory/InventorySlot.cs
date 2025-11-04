using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public ItemSO itemSO;
    public int quantity;

    public TMP_Text textSlotQuantity;
    public Image iconSlot;

    public void UpdateUI()
    {
        if(itemSO != null)
        {
            iconSlot.sprite = itemSO.itemSprite;
            iconSlot.gameObject.SetActive(true);
            textSlotQuantity.text = quantity.ToString();
        }
        else
        {
            iconSlot.gameObject.SetActive(false);
            textSlotQuantity.text = "";
        }
    }
}
