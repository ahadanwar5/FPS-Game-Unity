using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class playerScript : MonoBehaviour
{
    public Animator anim;
    public float health = 100f;
    public Slider healthBar;
    public Text ammoText;
    public AudioClip ammoReload;
    public AudioClip playerPain;
    // Start is called before the first frame update
    void Start()
    {
        ammoText.text = "Ammo: " + gunScript.ammo.ToString() + "/20";
        GetComponent<AudioSource>().clip = ammoReload;
        GetComponent<AudioSource>().clip = playerPain;
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Ammo: " + gunScript.ammo.ToString() + "/20";
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            anim.SetBool ("Attack", true);
            if (!col.GetComponent<enemyScript>().isDead)
            {
                GetComponent<AudioSource>().PlayOneShot(playerPain);
            } 
        }

        if (col.tag == "Ammo")
        {
            if (gunScript.ammo != 20f)
            {
                gunScript.ammo = 20f;
                Destroy(col.gameObject);
                GetComponent<AudioSource>().PlayOneShot(ammoReload);
            } 
        }


    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Enemy" && !col.GetComponent<enemyScript>().isDead)
        {
            health = health - 0.5f;
            healthBar.value = health;
        }

        if (health <= 0.0f)
        {
            SceneManager.LoadScene("gameOverScene");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
            anim.SetBool("Attack", false);
        }
    }
}
