using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Logic for the Sorting Machine
/// </summary>
public class SortingMachineController : MonoBehaviour {
    /// <summary>
    /// Objects sorted left move here
    /// </summary>
    public Transform ExitLeft;
    /// <summary>
    /// Objects sorted right move here
    /// </summary>
    public Transform ExitRight;

    /// <summary>
    /// When an object enters, determine whether or not it is an item and sort it
    /// </summary>
    /// <param name="other">The object that entered</param>
    private void OnTriggerEnter(Collider other)
    {
        var beltItem = other.gameObject.GetComponent<ConveyorItem>();

        // if this is null, then this isn't an item, so stop
        if (beltItem == null)
            return;

        SortItem(beltItem);
    }

    /// <summary>
    /// Sort the incoming item to left or right
    /// </summary>
    /// <param name="item">The item to sort</param>
    private void SortItem(ConveyorItem item)
    {
        switch (item.ItemType)
        {
            case ItemType.Apple:
            case ItemType.Pear:
                MoveItemToExit(item, true);
                break;
            case ItemType.Orange:
            case ItemType.Blueberry:
                MoveItemToExit(item, false);
                break;
            default:
                // If we don't know what object this is, then complain! ;D
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>
    /// Teleports an item to a location
    /// </summary>
    /// <param name="item">The item to teleport</param>
    /// <param name="right">Teleport to right, or left?</param>
    private void MoveItemToExit(ConveyorItem item, bool right)
    {
        if (right)
        {
            item.transform.position = ExitRight.position;
            item.transform.rotation = ExitRight.rotation;
        }
        else
        {
            item.transform.position = ExitLeft.position;
            item.transform.rotation = ExitLeft.rotation;
        }
    }
}
