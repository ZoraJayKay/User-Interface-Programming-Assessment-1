using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionListUI : MonoBehaviour
{
    // The list of available actions the player can choose
    public ActionList actionList;
    // Reference to a prefab UI object which will be cloned as a child of this object
    public ActionUI prefab;

    // Perform a start function that returns an iterator over the Actions of the Player
    // Start is called before the first frame update
    IEnumerator Start()
    {
        // Set the Player object equal to the one we've attached the ActionListUI to 
        Player player = actionList.GetComponent<Player>();

        // For each action in the player's list of actions, instantiate a prefab at the transform per the LayoutGroup
        foreach (Action a in actionList.actions)
        {
            ActionUI ui = Instantiate(prefab, transform);
            ui.SetAction(a);

            // Also invoke a lambda function to initialise the onClick behaviour of the button for each of the player's actions
            ui.Init(player);
        }

        // yield return only returns those items required / calculated by a function, so that function will exit early if it would otherwise calculate more than needed.
        yield return new WaitForEndOfFrame();

        // Turn off the content size fitter component
        GetComponent<ContentSizeFitter>().enabled = false;

        // Turn off the layout group component
        GetComponent<LayoutGroup>().enabled = false;
    }
}
