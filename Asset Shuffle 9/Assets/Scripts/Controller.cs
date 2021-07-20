using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Controller script that detects player input
/// </summary>
public class Controller : MonoBehaviour
{
    public PlayerHost host;     // Transform holding player

    void FixedUpdate()
    {
        host.movement.Move(host.body, GetMovementInput());
        host.movement.Face(host.body, GetMovementInput());
    }

    /// <summary>
    /// Generates a Vector3 based on the current input
    /// </summary>
    /// <returns></returns>
    private Vector3 GetMovementInput()
    {
        /*  
         *  Vector3 Movement works as follows (assuming facing forward):
         *  x: Left/Right           (A/D)
         *  y: Up/Down
         *  z: Forward/Backward     (W/S)
         */ 
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
    }
}
