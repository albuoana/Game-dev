using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float fireSpeed;
    private Rigidbody2D theRB;
    public GameObject FireEffect;

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2( fireSpeed * transform.localScale.x * (-1), 0);
    }

    //de verificat de ce se creaza mai multe obiecte si de ce se face destroy mai devreme la fire objects?
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            FindObjectOfType<GameMan>().HurtPlayer1();
        }
        else if (other.tag == "Player2")
        {
            FindObjectOfType<GameMan>().HurtPlayer2();
        }
 

        Instantiate(FireEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
