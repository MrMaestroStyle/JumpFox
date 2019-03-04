using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    public static int Score=0;
    public AudioSource audioscore;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("sssink", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            anim.SetInteger("sssink", 1);
            audioscore.Play();
            


        }
    }

    void destroyy()
    {
        Score = Score + 100;
        Destroy(this.gameObject);

    }

}
