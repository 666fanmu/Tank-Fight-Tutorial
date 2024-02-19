using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] m_Pick;//拾取物
    public float BornTime = 7f;//生成间隔
    public float t1 = 0;
    private void Update()
    {
        
        t1 += Time.deltaTime;
        if(t1>BornTime)
        {
            int x = Random.Range(-30, 30);
            int z = Random.Range(-30, 30);
            Vector3 vector3 = new Vector3(x, 1f, z);
            Instantiate(m_Pick[Random.Range(0, 4)], vector3, this.transform.rotation);
            t1 = 0;
        }
    }

}
