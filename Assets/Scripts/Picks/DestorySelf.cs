using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorySelf : MonoBehaviour
{
    // Start is called before the first frame update
    public float DesToryTime = 10f;

    // Update is called once per frame
    void Start()
    {
        Destroy(gameObject, DesToryTime);
    }
}
