using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorMachineController : MonoBehaviour {
    /// <summary>
    /// The prefab to spawn
    /// </summary>
    public GameObject ItemToSpawn;
    /// <summary>
    /// Where the item exits from
    /// </summary>
    public Transform Exit;
    /// <summary>
    /// The parent for all spawned items, used for organisation
    /// </summary>
    public Transform ItemParent;

    /// <summary>
    /// How often to spawn an item
    /// </summary>
    public float SpawnItemTime = 0.5f;
    /// <summary>
    /// A timer to determine when to spawn an item
    /// </summary>
    private float _spawnItemTimer = 0;

    private void Update()
    {
        if (!(Time.time > SpawnItemTime + _spawnItemTimer)) return;

        _spawnItemTimer = Time.time;
        SpawnItem();
    }

    /// <summary>
    /// Spawns a random item
    /// </summary>
    private void SpawnItem()
    {
        var spawnedItem = Instantiate(ItemToSpawn, Exit.position, Exit.rotation, ItemParent);

        var item = spawnedItem.GetComponent<ConveyorItem>();

        // if this item doesn't contain this component... then why is it here?
        // Destroy it
        if (item == null)
        {
            Destroy(spawnedItem);
            return;
        }

        item.SetRandomItemType();
    }
}
