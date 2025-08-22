using System.Diagnostics;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    private Text message;
    private bool notHit;
    void Start()
    {
        //Create Text component of a canvas object through unity named "Message"
        message = GameObject.Find("Message").GetComponent<Text>();
        //message.color = Color.white;
        message.text = "";
        notHit=true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && notHit)
        {
            StartCoroutine(displayText(other));

        }
        //Message to display if main dialogue is done

    }
    IEnumerator displayText(Collider2D other)
    {
        message.text = "BEYOND THE WISTERIA TREES OF PROTECTION \n LIVES THE EVIL ONI QUEEN \n [HIT SPACE TO CONTINUE]";
        other.gameObject.GetComponent<Player_Move_Update>().playerSpeed = 0;
        //will continue after mouse button is clicked
        //copy this block for every new line of dialouge
        while (!Input.GetKey(KeyCode.Space)) {
        yield return null;
        }
        message.text = "DEFEAT HER AND SAVE THIS FOREST";
        //



        //let player move again
        other.gameObject.GetComponent<Player_Move_Update>().playerSpeed = 4;
        notHit=false;
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            message.text = "";
        }
    }
}
