using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffData : MonoBehaviour
{
    public static BuffData Instance;
    public int[] buffchoose;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
