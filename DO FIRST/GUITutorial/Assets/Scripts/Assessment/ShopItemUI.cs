using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// This for the click and drag funtionality
using UnityEngine.EventSystems;

// This so that I can make generic reference to ShopItems that aren't specific instances
using static ShopItem;
using Unity.VisualScripting;

// Inherit 3 Unity classes for drag and drop, each of which requires a function in the class
public class ShopItemUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // ************ Member variables ************
    public ShopItem _shopItem;
    public Slot _slot;

    // Create a header in the public component viewer 
    [Header("Child Components")]
    // +++ Public variables for setting in Unity +++
    // 1: An image for use by this object's ShopItemUI
    public Image _icon;

    // 3: Text strings
    public TextMeshProUGUI _itemName;
    public TextMeshProUGUI _itemDescription;

    // 4: Requirements   
    public TextMeshProUGUI _itemPrice;
    public TextMeshProUGUI _itemWeight;

    // 5: Other type constraints
    public TextMeshProUGUI _itemTypeTag;
    public TextMeshProUGUI _classTypeTag;

    ShopItem.itemType _thisItemType;    
    ShopItem.classRequired _thisItemClass;

    // 6: The parent Transform and parent Canvas
    [Header("Parent Components")]
    public Transform _originalParent;
    public Canvas _canvas;

    // 7: Drag and drop variables
    bool dragging = false;
    // ************  ************


    // Make the ShopItemUI moveable with click and drag
    // 1: On mouse button down...
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Cache the original Parent's Transform
        if (_originalParent == null){
            _originalParent = transform.parent;
        }

        // Find the overall parent Canvas
        if (_canvas == null){
            _canvas = GetComponentInParent<Canvas>();
        }

        // To make sure that the dragged object appears above all others, make this ShopItemUI the child of the Canvas for the duration of the drag
        transform.SetParent(_canvas.transform, true);
        transform.SetAsLastSibling();



        // Set dragging indicator to true
        dragging = true;
    }

    // 2: For the duration of the drag...
    public void OnDrag(PointerEventData eventData) 
    { 
        // While dragging, make the position of the ShopItemUI equal to the position of the cursor
        if (dragging)
        {
            transform.position = eventData.position;
        }
    }

    // 3: On mouse button up, see if there�s a Slot under the mouse using EventSystem.RaycastAll.
    // Make a list of the results from checking under the cursor
    List<RaycastResult> hits = new List<RaycastResult>();

    public void OnEndDrag(PointerEventData eventData)
    {
        // Is there a slot underneath the cursor? Start with a null result by default
        Slot slotFound = null;

        // Keep a list of the things we mouse over 
        EventSystem.current.RaycastAll(eventData, hits);

        // For everything we mouse over...
        foreach (RaycastResult hit in hits)
        {
            // Check whether the thing we're mousing over has a Slot
            Slot s = hit.gameObject.GetComponent<Slot>();
            if (s)
            {
                // FROM TUTE AND EXAMPLE    
                // If yes, keep a reference to that Slot that was under the mouse
                slotFound = s;
                Debug.Log("FOUND A SLOT UNDER THE MOUSE");

                // Swap the underlying ShopItems of this ShopItemUI and the 
                Swap(slotFound);

                transform.SetParent(_originalParent);
                transform.localPosition = Vector3.zero;
            }

            else if (!s)
            {
                Debug.Log("NO SLOT FOUND UNDER THE MOUSE");

                //transform.SetParent(_originalParent);

                //transform.localPosition = Vector3.zero;
            }
        }

        dragging = false;
    }


    // A function for assigning a ShopItemUI with the particulars of a ShopItem
    public void SetItem(ShopItem i)
    {
        // Give this ShopItemUI a reference to its ShopItem 
        _shopItem = i;

        if (_shopItem)
        {
            // Bring in the sprite and its colour if they exist
            if (_icon)
            {

                _icon.sprite = _shopItem.icon;
                _icon.color = _shopItem.colour;
            }

            // Bring in the strings if they exist
            if (_itemName)
            {
                _itemName.SetText(_shopItem.itemName.ToString());
            }

            if (_itemDescription)
            {
                _itemDescription.SetText(_shopItem.itemDescription.ToString());
            }

            SetItemType(_shopItem.GetItemType());
            SetClassType(_shopItem.GetClassRequired());

            // Set the constraints
            _itemPrice.SetText("Price: " + _shopItem.itemPrice.ToString());
            _itemWeight.SetText("Weight: " + _shopItem.itemWeight.ToString());

            // Set the other constraints
            _itemTypeTag.SetText(_thisItemType.ToString());
            _classTypeTag.SetText("Class: " + _thisItemClass.ToString());
        }
        
        gameObject.SetActive(_shopItem != null);
    }

    // Assign the ShopItemUI an item type according to its ShopItem
    private void SetItemType(int itemType)
    {
        switch(itemType)
        {
            case 1: 
                _thisItemType = ShopItem.itemType.Weapon; 
                break;
            case 2:
                _thisItemType = ShopItem.itemType.Armour;
                break;
            case 3:
                _thisItemType = ShopItem.itemType.Consumable;
                break;
        }
    }

    // Assign the ShopItemUI a required class according to its ShopItem
    private void SetClassType(int classRequired)
    {
        switch (classRequired)
        {
            case 1:
                _thisItemClass = ShopItem.classRequired.Warrior;
                break;
            case 2:
                _thisItemClass = ShopItem.classRequired.Mage;
                break;
            case 3:
                _thisItemClass = ShopItem.classRequired.Cleric;
                break;
            case 4:
                _thisItemClass = ShopItem.classRequired.All;
                break;
        }
    }

    protected void Swap(Slot newParent)
    {
        ShopItemUI other = newParent.shopItemUI as ShopItemUI;

        if (other)
        {
            ShopItem ours = _shopItem;
            ShopItem theirs = other._shopItem;

            _slot.UpdateItem(theirs);
            other._slot.UpdateItem(ours);
        }
    }
}
