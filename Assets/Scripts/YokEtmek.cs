using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokEtmek : MonoBehaviour
{
    public LayerMask enemeyLayers;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5F;
    public int attackDamage = 100;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public AudioSource sesler;
    public AudioClip savur;
    

    // Update is called once per frame
    void Update()
 {
        if (Time.time>= nextAttackTime)
    {

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                sesler.PlayOneShot(savur);
        }
    }
}
    void Attack()
    {
        //Saldırı Animasyonu
        animator.SetTrigger("Attack");
        //Düşmanı Belirleme
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemeyLayers);
        //Hasar Vermek
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Düşman>().takeDamage(attackDamage);
            
        }
    }
    //ATTACK RANGE GÖRME
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
