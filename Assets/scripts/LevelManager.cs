using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    private enum animState { idle, running, jumping, falling };
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

    public void RestarLevel()
    {
        anim.ResetTrigger("dead");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.SetInteger("state", (int)animState.idle);
    }
}
