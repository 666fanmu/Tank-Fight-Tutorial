using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picks : MonoBehaviour
{
    // Start is called before the first frame update
    private TankHealth m_TankHealth;
    private TankArmor m_TankArmor;
    private TankMovement m_movement;
    private ShellExplosion m_shell;
    private TankShooting m_tankShooting;
    public float BuffTime=5f;
    private void Start()
    {
        m_TankHealth = GetComponent<TankHealth>();
        m_TankArmor = GetComponent<TankArmor>();
        m_movement = GetComponent<TankMovement>();
        m_shell = GetComponent<ShellExplosion>();
        m_tankShooting = GetComponent<TankShooting>();

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="BloodPick")
        {
            other.gameObject.SetActive(false);
            m_TankHealth.m_CurrentHealth += 20;
        }
        else if(other.gameObject.tag == "ArmorPick")
        {
            other.gameObject.SetActive(false);
            m_TankArmor.DamageProportion *= 1.5f;
            Invoke("ArmorClean", BuffTime);
        }
        else if(other.gameObject.tag == "SpeedPick")
        {
            other.gameObject.SetActive(false);
            m_movement.m_Speed *= 1.2f;
            Invoke("SpeedClean", BuffTime);
        }
        else if(other.gameObject.tag == "HeartPick")
        {
            other.gameObject.SetActive(false);
            m_tankShooting.FireMode = true;
            m_TankHealth.Buffamount = 1.2f;
            Invoke("HeartClean", BuffTime);
        }
    }
    private void SpeedClean()
    {
        m_movement.m_Speed /= 1.2f;
    }
    private void ArmorClean()
    {
        m_TankArmor.DamageProportion /= 1.5f;
    }
    private void HeartClean()
    {
        
        m_tankShooting.FireMode = false;
        m_TankHealth.Buffamount = 1;
    }

}
