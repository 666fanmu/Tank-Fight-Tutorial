using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;                            //用于过滤爆炸的影响，这应该设置为“Player”。详细请查看遮罩(Mask)在Unity中的运用
    public ParticleSystem m_ExplosionParticles;             //引用将在爆炸中发挥作用的粒子。
    public AudioSource m_ExplosionAudio;                    //引用将在爆炸时播放的音频。
    public float m_MaxDamage = 50f;                        //如果爆炸集中在坦克上，所造成的破坏量。
    public float m_ExplosionForce = 20f;                  //在爆炸中心加到坦克上的力。
    public float m_MaxLifeTime = 2f;                        //删除子弹之前的时间(以秒为单位)。
    public float m_ExplosionRadius = 5f;                    //子弹爆炸半径。
    private TankArmor m_tankArmor;
    private TankShooting m_shooting;
    private TankMovement m_movement;
    private Buffs m_buff;
    private void Start()
    {
        m_buff = GetComponent<Buffs>();
        Destroy(gameObject, m_MaxLifeTime); // 子弹达到最大时长销毁自身
        m_shooting=GetComponent<TankShooting>();
        m_movement = GetComponent<TankMovement>();
    }


    private void OnTriggerEnter(Collider other)
    {
        //找到炮弹周围区域的所有坦克并将其摧毁
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);
        for(int i=0;i<colliders.Length;i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            if(!targetRigidbody)
                continue;
            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);
            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();
            TankArmor TargetArmor = targetRigidbody.GetComponent<TankArmor>();
            if(!targetHealth)
                continue;
            float damage = CalculateDamage(targetRigidbody.position);
            if (countDistance(targetRigidbody.position) > 0.8)
            {
                TargetArmor.TakeBigDamage();
                if(m_buff.IsZS)
                {
                    m_movement.ZhouSiHeart = true;
                    Invoke("CleanZS", 0.3f);
                }
            }
            else
            {
                TargetArmor.TakeSmallDamage();
            }
            
            targetHealth.TakeDamage(damage);
            
        }
        
        m_ExplosionParticles.transform.parent = null;
        m_ExplosionParticles.Play();
        m_ExplosionAudio.Play();

        Destroy(m_ExplosionParticles.gameObject,m_ExplosionParticles.main.duration);
        Destroy(gameObject);
        
    }
    private void CleanZS()
    {
        m_movement.ZhouSiHeart = false;
    }
    private float countDistance(Vector3 targetPosition)
    {
        Vector3 explorationToTarget = targetPosition - transform.position;
        float explorationDistance = explorationToTarget.magnitude;
        float relativeDistance = (m_ExplosionRadius - explorationDistance) / m_ExplosionRadius;
        return relativeDistance;
    }
    
    private float CalculateDamage(Vector3 targetPosition)
    {
        //根据目标的位置计算目标返回应该受到的伤害

        Vector3 explorationToTarget = targetPosition - transform.position;
        float explorationDistance = explorationToTarget.magnitude;
        float relativeDistance = (m_ExplosionRadius - explorationDistance) / m_ExplosionRadius;
        float damage = relativeDistance * m_MaxDamage;
        damage = Mathf.Max(0f, damage);
        return damage;
        
    }
}