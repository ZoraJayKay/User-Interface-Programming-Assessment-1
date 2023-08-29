using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A front-end class for the empty Slots which sit in the Inventory, with or without items inside them.
public class Slot : MonoBehaviour
{
    // The specific ShopItemUI object for this Slot
    public ShopItemUI shopItemUI;

    // A function for initialising the Slots of an InventoryUI with the particulars of its ShopItemUI; link up references between the Slot, the ShopItemUI, and the InventoryUI
    public void Init(InventoryUI invUI, int i, ShopItemUI _shopItemUI)
    {
        // Store a reference to the ShopItemUI that's passed in (because it is the one for this Slot)
        shopItemUI = _shopItemUI;
    }



    //// Add a lambda function to the Player's onClick button function
    //public void Init(Player _player)
    //{
    //    // Store a reference to the button of this Action (Init is being called in a loop so this will get done for all of the Actions)
    //    Button button = GetComponentInChildren<Button>();

    //    // The lambda function here creates a local unnamed function that gets called when the button is pressed, with a copy of the stack at the time it was set up.
    //    if (button)
    //    {
    //        button.onClick.AddListener(() => { player.DoAction(action); });
    //    }
    //}
}
