using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // An array of all the ShopItems in this Inventory (empty on instantiation)
    ShopItem[] _shopItems = null;

    // A 'lazy' initialisation accessor INSTEAD OF a Start()
    public ShopItem[] shopItems
    {
        get
        {
            if (_shopItems == null)
                // Return all sibling ShopItems to the array
                _shopItems = GetComponents<ShopItem>();
            return _shopItems;
        }
    }
}
