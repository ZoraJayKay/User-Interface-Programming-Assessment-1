using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// A scriptable object back-end class that specifies the particulars for each item
public class ShopItem : MonoBehaviour
{
    // +++ Public variables for setting in Unity +++
    // 1: An image for use by this object's ShopItemUI
    public Sprite icon;

    // 2: A colour for differentiating the Sprite
    public Color colour;

    // 3: Text strings and constraints
    public string itemName;
    public string itemDescription;
    public float itemPrice;
    public float itemWeight;

    // 4: Other constraints
    public enum itemType { Weapon, Armour, Consumable };
    public itemType thisItemType;

    public enum classRequired { Warrior, Mage, Cleric };
    public classRequired thisItemClass;

    // A function for the ShopItemUI to invoke to return the ShopItem's item type
    public int GetItemType()
    {
        // A temporary variable which will represent the type of return to send back to the ShopItemUI
        int type = 0;

        switch (thisItemType)
        {
            case itemType.Weapon: 
                type = 1;
                break;

            case itemType.Armour: 
                type = 2;
                break;

            case itemType.Consumable:
                type = 3;
                break;
            
                // Assume an object is a consumable of not specified (this shouldn't ever bee needed but just in case)
            default: 
                type = 3;
                break;
        }

        // Send the integer representation of the type back to the ShopItemUI
        return type;
    }


    // A function for the ShopItemUI to invoke to return which class can use the ShopItem
    public int GetClassRequired()
    {
        // A temporary variable which will represent the class to return to the ShopItemUI
        int _classRequired = 0;

        switch (thisItemClass)
        {
            case classRequired.Warrior:
                _classRequired = 1;
                break;

            case classRequired.Mage:
                _classRequired = 2;
                break;

            case classRequired.Cleric:
                _classRequired = 3;
                break;

            // Assume an object is for a Warrior if not specified (this shouldn't ever be needed but just in case)
            default:
                _classRequired = 1;
                break;
        }

        // Send the integer representation of the class back to the ShopItemUI
        return _classRequired;
    }
}
