using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Colision : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("SpikeTrap"))
        {
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("dead");
        }
    }
}
