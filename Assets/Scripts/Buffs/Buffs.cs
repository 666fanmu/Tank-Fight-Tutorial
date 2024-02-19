using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public int m_PlayerNumber = 1;
    private ShellExplosion m_shellExplosion;
    private TankMovement m_tankMovement;
    private TankArmor m_Armor;
    private TankHealth m_health;
    private TankShooting m_shooting;
    public int BuffNum;
    public bool IsZS=false;
    
    private void Start()
    {
        m_Armor = GetComponent<TankArmor>();
        m_health= GetComponent<TankHealth>();
        m_shooting= GetComponent<TankShooting>();
        m_tankMovement= GetComponent<TankMovement>();
        BuffNum = BuffData.Instance.buffchoose[m_PlayerNumber-1];
        m_shellExplosion = GetComponent<ShellExplosion>();
        if(BuffNum==1)
        {
            ZhouSi();
        }
        else if(BuffNum==2)
        {
            YaDianNa();
        }
        else if(BuffNum==3)
        {
            ARuiSi();
        }
        else if(BuffNum==4)
        {
            PoSaiTong();
        }
        else if(BuffNum==5)
        {
            HerMoSi();
        }

    }
    private void ZhouSi()
    {
        if (BuffNum == 1)
        {
            IsZS = true;
        }
    }
    
    public void YaDianNa()
    {
        m_health.IsYDNUsed = true;
    }
    public void PoSaiTong()
    {
        m_shooting.PSD_Buff = true;
    }
    public void HerMoSi()
    {
        m_tankMovement.m_Speed = 17f;
        m_Armor.waitTime = 0.75f;
    }
    public void ARuiSi()
    {
        m_shooting.ARS_buff = true;
    }
}
