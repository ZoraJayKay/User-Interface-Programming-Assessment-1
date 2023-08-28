using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionList : MonoBehaviour
{
    // An array of all sibling Actions (empty on instntiation)
    Action[] _actions = null;

    // A 'lazy' initialisation accessor INSTEAD OF a Start()
    public Action[] actions
    {
        get
        {
            if (_actions == null)
                // Return all sibling Actions to the array
                _actions = GetComponents<Action>();
                return _actions;
        }
    }
}
