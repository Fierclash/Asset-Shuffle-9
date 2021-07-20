using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Basic Movement Script for a 3D Top Down game
/// </summary>
public class Movement3D : MonoBehaviour
{
    public Transform cameraHolder;      // Transform that holds the camera (not the camera transform itself)
    public Transform lookAtTarget;      // Transform for the player to look at
    public float baseSpeed = 5f;        // Force factor at which the player moves at
    public float cameraSpeed = 100f;    // Speed factor at which the camera follows the player at


    private Vector3 offset;             // Readonly variable to mark the camera offset

    void Awake()
    {
        offset = cameraHolder.position - transform.position;    // Set offset
    }

    void FixedUpdate()
    {
        MoveCamera();
    }

    /// <summary>
    /// Moves the camera to follow the player
    /// </summary>
    private void MoveCamera()
    {
        // Adjust transform position with offset
        cameraHolder.position = Vector3.Lerp(cameraHolder.position, 
                                            transform.position + offset, 
                                            Time.deltaTime * cameraSpeed);
    }

    #region Movement Functions
    /// <summary>
    /// Moves the player body
    /// </summary>
    /// <param name="body"></param>
    /// <param name="direction"></param>
    /// <param name="force"></param>
    public void Move(Rigidbody body, Vector3 direction, float force)
    {
        body.AddForce(direction.normalized * force);
    }

    /// <summary>
    /// Moves the player body
    /// </summary>
    /// <param name="body"></param>
    /// <param name="direction"></param>
    public void Move(Rigidbody body, Vector3 direction) =>
        Move(body, direction, baseSpeed);


    /// Rotates a transform either to a specific angle or by a relative amount
    public void Face(Rigidbody obj, Vector3 direction, bool relative = false)
    {
        // Ignore empty inputs
        if (direction == Vector3.zero)
            return;

        lookAtTarget.position = obj.position + direction * 1f;
        obj.transform.LookAt(lookAtTarget);
    }
    #endregion

}
