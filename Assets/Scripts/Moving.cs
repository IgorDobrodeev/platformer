using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public int tier;
    public int maxTier;
    public float speed;

    void Update()
    {
        if (tier == maxTier*2) {
            tier = 0;
        }
        else if (tier < maxTier) {
            transform.position += new Vector3(speed, 0, 0);
            tier += 1;
        }
        else if (tier < maxTier*2) {
            transform.position += new Vector3(-speed, 0, 0);
            tier += 1;
        }
        
    }
}
