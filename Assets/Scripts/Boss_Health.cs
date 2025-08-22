using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss_Health : MonoBehaviour {

    public int bossHealth = 0;
    public SpriteRenderer sprite;
    public float timer = 100;
    public AudioClip Chirp;
    private int wait = 1000;
    private bool destroyObj = false;
    private Text defeatMsg;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        defeatMsg = GameObject.Find("defeatMsg").GetComponent<Text>();
        defeatMsg.text = "";
    }

    void Update () {
        if (gameObject.transform.position.y < -100) {
            Destroy (gameObject);
        }

        //damage coloration
        if (timer > 0)
        {
            timer = timer - 1;
        }
        else
        {
            sprite.color = new Color(1, 1, 1, 1);
            timer = 100;
        }

        //after boss is defeated
        if(destroyObj)
        {
            //Destroy(gameObject);
            sprite.color = new Color(0, 0, 0, 0);

            if (wait > 0)
            {
                wait = wait - 1;
            }
            else
            {
                SceneManager.LoadScene(4);
            }
        }
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            if (bossHealth > 1)
            {
                bossHealth = bossHealth - 1;
            }
            else
            {
                destroyObj = true;
                defeatMsg.text = "THE ONI QUEEN HAS BEEN DEFEATED!";
                AudioSource.PlayClipAtPoint(Chirp, transform.position);
            }
        }
        sprite.color = new Color(1, 0, 0, 1);
    }

}
