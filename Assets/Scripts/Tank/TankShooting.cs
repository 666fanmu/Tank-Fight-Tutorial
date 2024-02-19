using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 坦克攻击类(已给出部分代码,需补充)
/// </summary>
public class TankShooting : MonoBehaviour
{
    public int m_PlayerNumber = 1;              //区分玩家
    public Rigidbody[] m_Shell;                   //子弹的刚体，用来实例化
    public Transform[] m_FireTransform;           //子弹发射位置
    public Slider m_AimSlider;                  //蓄力条
    public AudioSource m_ShootingAudio;         //音效组件
    public AudioClip m_ChargingClip;            //蓄力音效
    public AudioClip m_FireClip;                //发射音效
    public float m_MinLaunchForce = 10f;        //最小发射力
    public float m_MaxLaunchForce = 20f;        //最大发射力
    public float m_MaxChargeTime = 0.75f;       //最大蓄力时间
    public float waitTime=0.5f;                  //装弹时间
    public float currentTime;                  //实际时间
    private string m_FireButton;                //发射按键
    private float m_CurrentLaunchForce;         //当前发射力
    private float m_ChargeSpeed;                //发射力的增加速度
    private bool m_Fired;                       //是否子弹已被发射
    public bool FireMode=false;//两种发射模式
    public bool PSD_Buff = false;
    public bool ARS_buff=false;
    private void OnEnable()
    {
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_AimSlider.value = m_MinLaunchForce;
    }


    private void Start()
    {
        m_FireButton = "Fire"+m_PlayerNumber;
        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }
    

    private void Update()
    {
        //跟踪发射按钮的当前状态，并根据当前发射力量做出决定。
        m_AimSlider.value = m_MinLaunchForce;
        
        if(!m_Fired)
        {
            if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
            {
                m_CurrentLaunchForce = m_MaxLaunchForce;
                Fire();
            }
            else if (Input.GetButtonDown(m_FireButton))
            {

                m_CurrentLaunchForce = m_MinLaunchForce;
                m_ShootingAudio.clip = m_ChargingClip;
                m_ShootingAudio.Play();
            }
            else if (Input.GetButton(m_FireButton) && !m_Fired)
            {
                m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;
                m_AimSlider.value = m_CurrentLaunchForce;
            }
            else if (Input.GetButtonUp(m_FireButton) && !m_Fired)
            {
                Fire();

            }
        }
        if(m_Fired)
        {
            currentTime += Time.deltaTime;
            if (currentTime > waitTime)
            {
                m_Fired = false;
                currentTime = 0;
            }
        }
    }
        
    private void Fire()
    {
        if(!FireMode)
        {
            FireMode1(PSD_Buff);
        }
        else
        {
            FireMode2();
        }
    }

     

    private void FireMode1(bool i)
    {
        //实例化并启动子弹。
        int n=0;
        if (i)
        {
            n = 2;
        }
        else if(ARS_buff)
        {
            n = 1;
        }
        m_Fired = true;
        Rigidbody shellinstance = Instantiate(m_Shell[n], 
                                              m_FireTransform[n].position,
                                             m_FireTransform[n].rotation)as Rigidbody;
        shellinstance.velocity = m_FireTransform[0].forward * m_CurrentLaunchForce;
        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();
        m_CurrentLaunchForce = m_MinLaunchForce;
    }
    private void FireMode2()
    {
        //实例化并启动子弹。
        m_Fired = true;
        Rigidbody shellinstance1 = Instantiate(m_Shell[1], m_FireTransform[1].position, m_FireTransform[1].rotation) as Rigidbody;
        shellinstance1.velocity = m_FireTransform[1].forward * m_CurrentLaunchForce;
        Rigidbody shellinstance2 = Instantiate(m_Shell[1], m_FireTransform[2].position, m_FireTransform[2].rotation) as Rigidbody;
        shellinstance2.velocity = m_FireTransform[2].forward * m_CurrentLaunchForce;
        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();
        m_CurrentLaunchForce = m_MinLaunchForce;
    }
}