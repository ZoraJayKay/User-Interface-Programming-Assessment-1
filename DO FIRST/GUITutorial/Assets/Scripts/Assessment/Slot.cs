using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A front-end class for the empty Slots which sit in the Inventory, with or without items inside them.
public class Slot : MonoBehaviour
{
    // The specific ShopItemUI object for this Slot
    [HideInInspector]
    public ShopItemUI shopItemUI;

    //// A second ShopItemUI reference exclusively for the purposes of drag and drop item swapping
    [HideInInspector]
    public ShopItemUI tempItemUI;

    [HideInInspector]
    public InventoryUI inventoryUI;
    
    [HideInInspector]
    public int arrayIndex;

    // A function for initialising the Slots of an InventoryUI with the particulars of its ShopItemUI; link up references between the Slot, the ShopItemUI, the InventoryUI, and the Slot's index in the array
    public void Init(InventoryUI invUI, int i, ShopItemUI _shopItemUI)
    {
        // Store a reference to the ShopItemUI that's passed in (because it is the one for this Slot)
        shopItemUI = _shopItemUI;
        inventoryUI = invUI;
        arrayIndex = i;
        shopItemUI._slot = this;
    }

    public void SetShopItemUI(ShopItemUI _shopItemUI) { 
        shopItemUI = _shopItemUI;
    }

    public ShopItemUI GetShopItemUI()
    {
        return shopItemUI;
    }

    public void UpdateItem(ShopItem item)
    {
        // Update the raw data in the inventory
        inventoryUI.inventory.shopItems[arrayIndex] = item;

        // Update the UI
        tempItemUI.SetItem(item);
    }

    public Inventory GetInventory()
    {
        return inventoryUI.GetInventory();
    }

    //public ShopItem GetShopItem(Slot slot, int index)
    //{
    //    ShopItem temp = slot.GetComponentInParent<InventoryUI>().inventory.shopItems[index];

    //    return temp;
    //}
}
