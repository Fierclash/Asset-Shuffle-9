using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHost : MonoBehaviour
{
    public Movement3D movement;
    public Rigidbody body;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
}
