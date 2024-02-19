using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TankArmor : MonoBehaviour
{
    public int m_PlayerNumber = 1;
    public GameObject shell;                //子弹
    public float StartArmor = 100f;         //初始护甲
    public  float CurrentArmor;             //实际护甲
    public Slider Armorslider;              //护甲滑块
    public Image m_FillImage;
    public Color FullArmorColor = Color.gray;//满甲
    public Color EmptyArmorColor = Color.red;//空甲
    private string HealthName;               //回甲名称
    public float waitTime=2f;               //等待时间
    public float currentTime;               //实际时间
    public float ReturnArmor=10f;           // 回复数值
    public float DamageProportion=1f;          //伤害比例
    public GameObject Tank;
    public Transform[] point;
    private void Awake()
    {
        DamageCount();
    }
    private void OnEnable()
    {
        HealthName = "Health" + m_PlayerNumber;
        CurrentArmor = StartArmor;
        SetArmorUIPlace();
        SetArmorUI();
        DamageCount();
        
    }
    // Update is called once per frame
    
    public void TakeBigDamage()
    {

        CurrentArmor -= 25f;
        DamageCount();
    }
    public void TakeSmallDamage()
    {

        CurrentArmor -= 10f;
        DamageCount();
    }
    public void Update()
    {
        SetArmorUI();
        
        
    }

    private void SetArmorUI()
    {
        Armorslider.value = CurrentArmor;                                                              
        m_FillImage.color = Color.Lerp(EmptyArmorColor, FullArmorColor, CurrentArmor / StartArmor);
    }
    private void SetArmorUIPlace()
    {
        for(int i=1;i<=2;i++)
        {
            if(m_PlayerNumber==i)
            {
                Armorslider.transform.position = point[i - 1].transform.position;
                Armorslider.transform.rotation = point[i - 1].transform.rotation;
            }
        }
        
            
        
    }

    private void FixedUpdate()
    {
        if(Input.GetButton(HealthName))//按下回复键
        {
            TankMovement.IsRecovering = true;
            currentTime += Time.deltaTime;
            if(currentTime>waitTime)//到达时间后开始回甲
            {
                CurrentArmor += ReturnArmor * Time.deltaTime;
                if(CurrentArmor>StartArmor)
                {
                    CurrentArmor = StartArmor;
                }
                
            }
            if(Input.GetButtonUp(HealthName))
            {
                currentTime = 0;
            }
        }
        else if(Input.GetButtonUp(HealthName))//按下时间归零
        {
            currentTime = 0;
            TankMovement.IsRecovering = false;
        }
        if(CurrentArmor<=0)
        {
            CurrentArmor = 0;
        }
    }
    public void DamageCount()
    {
        if (CurrentArmor/ StartArmor > 0.75)
        {
            DamageProportion = 0.7f;
        }
        else if (CurrentArmor/ StartArmor > 0.3 && CurrentArmor/ StartArmor <= 0.75)
        {
            DamageProportion = 1;
        }
        else if (CurrentArmor/ StartArmor <= 0.3)
        {
            DamageProportion = 1.2f;
        }
    } 
    
}
