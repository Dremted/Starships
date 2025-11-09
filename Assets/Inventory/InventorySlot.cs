using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public int quantity;
    public int stackSize;

    public ManagerInventory managerInventory;
    public ItemSO itemSO;

    public TMP_Text textSlotQuantity;
    public Image iconSlot;



    private void Start()
    {
        managerInventory = GetComponentInParent<ManagerInventory>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (quantity > 0)
            {
                managerInventory.UseItem(this);
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            managerInventory.DropItem(this);
        }
    }

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
