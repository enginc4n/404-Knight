using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Düşman : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    public AudioSource sesler;
    public AudioClip oldu;

    
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;


        if (currentHealth <=0)
        {
            Die();

        }
    }
    void Die()
    {
        sesler.PlayOneShot(oldu);
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled=false ;
       
        this.enabled = false;
    }
  
}
