using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // ----- InventoryUI member variables  -----
    // 1: An Inventory to create a UI for.
    public Inventory inventory;
    // 2: The base Slot prefab we want to use for this InventoryUI.
    public Slot slotPrefab;
    // 3: An array of Slots to hold ShopItemUI's.
    Slot[] slots;
    // 4: The base ShopItemUI prefab we want to use for this InventoryUI.
    public ShopItemUI shopItemUIPrefab;

    

    private void Start()
    {
        // 1: Cache the size of the inventory which we'll be displaying.
        int inventorySize = inventory.shopItems.Length;

        // 2: Create a Slot in our array for each ShopItem in the passed-in Inventory.
        slots = new Slot[inventorySize];

        // 3: Initialise the array of Slots.
        // 3.1: Iterate through the Slots...
        for (int i = 0; i < inventorySize; i++)
        {
            // 3.1a: For each Slot, create a Slot prefab according to the transform rules of the InventoryUI.
            slots[i] = Instantiate(slotPrefab, transform);

            // 3.1b: For each Slot, create a ShopItemUI prefab as the Slot's own child
            slots[i].shopItemUI = Instantiate(shopItemUIPrefab, slots[i].transform);

            // 3.1c: Assign the Slot's ShopItemUI with the particulars of its ShopItem
            slots[i].shopItemUI.SetItem(inventory.shopItems[i]);

            // 3.1d: Initialise the Slot with the particulars of the ShopItemUI
            slots[i].Init(this, i, slots[i].shopItemUI);
            // ++++++++ Haven't I already done this with the 3 previous expressions? ++++++++
        }
    }
}
