using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that handles all movement relating to conveyor belts
/// </summary>
public class BeltMovement : MonoBehaviour {
    /// <summary>
    /// The speed and direction at which the belt moves
    /// </summary>
    public float Speed = 5;
    /// <summary>
    /// The material of the belt
    /// </summary>
    private Material _beltMaterial;
    /// <summary>
    /// The value that the texture of the belt moves with the force it's providing
    /// </summary>
    private const float SpeedObjectModifier = 11.25f;

    private void Start()
    {
        _beltMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        MoveBelt();
    }
    
    /// <summary>
    /// Moves the texture on the belt
    /// </summary>
    private void MoveBelt()
    {
        var uvPosition = _beltMaterial.mainTextureOffset;
        uvPosition.y += -1 * Speed * Time.deltaTime;
        _beltMaterial.mainTextureOffset = uvPosition;
    }

    /// <summary>
    /// Translates whatever cube is on the belt
    /// </summary>
    /// <param name="collisionInfo">The object we collide with</param>
    void OnCollisionStay(Collision collisionInfo)
    {
        var movement = transform.forward * Speed / SpeedObjectModifier * Time.deltaTime;
        collisionInfo.rigidbody.MovePosition(collisionInfo.rigidbody.position + movement);
    }
}
