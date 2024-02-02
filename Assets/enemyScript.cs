using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemyScript : MonoBehaviour
{
    public GameObject player;
    Animator anim;
    NavMeshAgent nav;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDead)
        {
            nav.enabled = false;
        }
        nav.SetDestination(player.transform.position);
    }
}
