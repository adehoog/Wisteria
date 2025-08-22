using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Magic : MonoBehaviour {

    public GameObject mana4;
    public GameObject mana3;
    public GameObject mana2;
    public GameObject mana1;

    [SerializeField] private GameObject projectile;
    private bool facingRight = true;
    [SerializeField] private int MaxActiveShots;
    private Rigidbody2D rbdPlayer;
    
    // Use this for initialization
    void Start()
    {
        rbdPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        mana4.SetActive(false);
        mana3.SetActive(false);
        mana2.SetActive(false);
        mana1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (facingRight)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.RotateAround(rbdPlayer.transform.position, Vector3.up, 180f);
                facingRight = false;
            }
        }else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.RotateAround(rbdPlayer.transform.position, Vector3.up, 180f);
            facingRight = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (mana1.activeInHierarchy)
            {
                UseSpell();
                if (GameObject.FindGameObjectsWithTag("Attack").Length < MaxActiveShots)
                {
                    GameObject shot = Instantiate(projectile);
                    shot.transform.position = this.transform.position;
                    shot.SetActive(true);
                    float playerSpeed = rbdPlayer.velocity.x;
                    shot.GetComponent<Projectile>().Launch(playerSpeed, facingRight);
                }
            }
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mana"))
        {
            AddMana();
            Destroy(collision.gameObject);
        }
    }

    private void AddMana()
    {
        if (!mana1.activeInHierarchy)
        {
            mana1.SetActive(true);
        }
        else if (!mana2.activeInHierarchy)
        {
            mana2.SetActive(true);
        }
        else if (!mana3.activeInHierarchy)
        {
            mana3.SetActive(true);
        }
        else if (!mana4.activeInHierarchy)
        {
            mana4.SetActive(true);
        }
    }

    private void UseSpell()
    {
        if (mana4.activeInHierarchy)
        {
            mana4.SetActive(false);
        }
        else if (mana3.activeInHierarchy)
        {
            mana3.SetActive(false);
        }
        else if (mana2.activeInHierarchy)
        {
            mana2.SetActive(false);
        }
        else
        {
            mana1.SetActive(false);
        }
    }
}
