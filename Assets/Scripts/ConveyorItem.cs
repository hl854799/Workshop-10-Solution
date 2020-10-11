using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

/// <summary>
/// Holds data relating to an item
/// </summary>
public class ConveyorItem : MonoBehaviour
{
    /// <summary>
    /// The type of the item
    /// </summary>
    public ItemType ItemType;

    private void Start()
    {
        SetItemColor();
    }

    /// <summary>
    /// This sets the item color according to the ItemType
    /// </summary>
    private void SetItemColor()
    {
        GetComponent<Renderer>().material.color = GetColorForType(ItemType);
    }

    /// <summary>
    /// Sets the item type to a random value
    /// </summary>
    public void SetRandomItemType()
    {
        var itemArray = Enum.GetValues(typeof(ItemType)).Cast<ItemType>().ToArray();

        var rand = new Random();
        ItemType = itemArray[rand.Next(itemArray.Length)];
    }

    /// <summary>
    /// Retrieves the colour for a certain colour type
    /// </summary>
    /// <param name="itemType">The type that you want to query</param>
    /// <returns>The resultant colour, if the item is not found then return white</returns>
    private Color GetColorForType(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Apple:
                return ColorFromRGB(230, 33, 23);
            case ItemType.Pear:
                return ColorFromRGB(119, 179, 67);
            case ItemType.Orange:
                return ColorFromRGB(255, 128, 0);
            case ItemType.Blueberry:
                return ColorFromRGB(84, 107, 157);
            default:
                return new Color(1, 1, 1);
        }
    }

    /// <summary>
    /// Helper method to convert RGB into a color
    /// </summary>
    /// <param name="r">red (0-255)</param>
    /// <param name="g">green (0-255)</param>
    /// <param name="b">blue (0-255)</param>
    /// <returns>The resulting color</returns>
    private Color ColorFromRGB(int r, int g, int b)
    {
        return new Color(r / 255f, g / 255f, b / 255f);
    }
}

/// <summary>
/// These are the types an item can be
/// </summary>
public enum ItemType
{
    Apple,
    Pear,
    Orange,
    Blueberry
}
