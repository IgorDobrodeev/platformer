using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float speed;
    // You spin me right 'round
    void Update()
    {
        transform.Rotate(0, 0, speed);
    }
}
