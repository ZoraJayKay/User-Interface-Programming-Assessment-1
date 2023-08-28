using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static ShopItem;

public class ShopItemUI : MonoBehaviour
{
    public enum itemType { Weapon, Armour, Consumable };
    public enum classRequired { Warrior, Mage, Cleric };

    // Create a header in the public component viewer 
    [Header("Child Components")]
    // +++ Public variables for setting in Unity +++
    // 1: An image for use by this object's ShopItemUI
    public Image _icon;

    // 2: A colour for differentiating the Sprite
    //Color _colour;

    // 3: Text strings
    public TextMeshProUGUI _itemName;
    public TextMeshProUGUI _itemDescription;

    // 4: Requirements   
    public TextMeshProUGUI _itemPrice;
    public TextMeshProUGUI _itemWeight;

    // 5: Other type constraints
    public TextMeshProUGUI _itemTypeTag;
    public TextMeshProUGUI _classTypeTag;

    itemType _thisItemType;    
    classRequired _thisItemClass;

    // A function for assigning a ShopItemUI with the particulars of a ShopItem
    public void SetItem(ShopItem item)
    {
        // Bring in the sprite and its colour if they exist
        if (_icon) {
            _icon.sprite = item.icon;
            _icon.color = item.colour;
        }

        // Bring in the strings if they exist
        if (_itemName)
        {
            _itemName.SetText(item.itemName.ToString());
        }

        if (_itemDescription)
        {
            _itemDescription.SetText(item.itemDescription.ToString());
        }

        SetItemType(item.GetItemType());
        SetClassType(item.GetClassRequired());

        // Set the constraints
        _itemPrice.SetText("Price: " + item.itemPrice.ToString());
        _itemWeight.SetText("Weight: " + item.itemWeight.ToString());

        // Set the other constraints
        _itemTypeTag.SetText(_thisItemType.ToString());
        _classTypeTag.SetText("Class: " + _thisItemClass.ToString());
    }

    // Assign the ShopItemUI an item type according to its ShopItem
    private void SetItemType(int itemType)
    {
        switch(itemType)
        {
            case 1: 
                _thisItemType = ShopItemUI.itemType.Weapon; 
                break;
            case 2:
                _thisItemType = ShopItemUI.itemType.Armour;
                break;
            case 3:
                _thisItemType = ShopItemUI.itemType.Consumable;
                break;
        }
    }

    // Assign the ShopItemUI a required class according to its ShopItem
    private void SetClassType(int classRequired)
    {
        switch (classRequired)
        {
            case 1:
                _thisItemClass = ShopItemUI.classRequired.Warrior;
                break;
            case 2:
                _thisItemClass = ShopItemUI.classRequired.Mage;
                break;
            case 3:
                _thisItemClass = ShopItemUI.classRequired.Cleric;
                break;
        }
    }
}
