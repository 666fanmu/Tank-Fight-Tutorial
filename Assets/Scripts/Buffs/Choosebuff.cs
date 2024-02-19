using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Choosebuff : MonoBehaviour
{
    int i;
    public Text[] m_text;
    public void Start()
    {
        i = 0;
    }
    public void Update()
    {
        if(i==2)
        {
            SceneManager.LoadScene("FirstGround");
        }
    }
    public void ChooseZS()
    {
        BuffData.Instance.buffchoose[i] = 1;
        m_text[0].text = "Player" + Mathf.Max(i, i + 1);
        i++;
    }
    public void ChooseYDN()
    {
        BuffData.Instance.buffchoose[i] = 2;
        m_text[1].text = "Player" + Mathf.Max(i, i + 1);
        i++;
    }
    public void ChooseARS()
    {
        BuffData.Instance.buffchoose[i] = 3;
        m_text[2].text = "Player" + Mathf.Max(i, i + 1);
        i++;
    }
    public void ChooseBSD()
    {
        BuffData.Instance.buffchoose[i] = 4;
        m_text[3].text = "Player" + Mathf.Max(i, i + 1);
        i++;
    }
    public void ChooseHEMS()
    {
        BuffData.Instance.buffchoose[i] = 5;
        m_text[4].text = "Player" + Mathf.Max(i, i + 1);
        i++;
    }

}
