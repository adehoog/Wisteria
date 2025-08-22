using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour {

	void Update () {
		if (gameObject.transform.position.y < -100) {
            Destroy (gameObject);
        }
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            Destroy(gameObject);
        }
    }
}
