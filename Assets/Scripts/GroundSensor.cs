using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private PlayerController controller;
    public bool isGrounded;

    SFXManager sfxManager;
    SoundManager soundManager;
    GameManager gameManager;
    Animator anim;

    void Awake()
    {
        controller = GetComponentInParent<PlayerController>();
        anim = GetComponentInParent<Animator>();
        
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        gameManager = GameObject.Find("GameManger").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = true;
            anim.SetBool("IsJumping", false);
        }
        else if(other.gameObject.layer == 6)
        {
            Debug.Log("Goomba muerto");

            sfxManager.GoombaDeath();
            
            Enemy goomba = other.gameObject.GetComponent<Enemy>();
            goomba.Die();

        }


        if(other.gameObject.tag == "DeadZone")
        {
            Debug.Log("Estoy muerto");

            soundManager.StopBGM();
            sfxManager.MarioDeath();
            gameManager.GameOver();
            //SceneManager.LoadScene()
        }  
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = false;
        }
    }
}
