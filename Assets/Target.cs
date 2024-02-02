using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    public float health = 30;
    public Animator zombieAnimator;
    public GameObject zombie;

    public void TakeDamage (float amount)
    {
        health = health - amount;
        if (health<=0)
        {
            Die();
        }
    }

    void Die()
    {
        zombieAnimator.SetTrigger("Death");    
        zombie.GetComponent<enemyScript>().isDead = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
