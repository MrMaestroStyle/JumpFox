using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float arriveTime = 3f;
    private bool isFacingRight = true;
    float moves;
    float mem;
    Vector3 old;



    // Start is called before the first frame update
    void Start()
    {
        old = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        mem = transform.position.x;
        transform.position = Vector3.Lerp(start.position, end.position, Mathf.PingPong(Time.time / arriveTime, 1f));
        state();
    }

    private void Flip()
    {
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }

    private void state()
    {


        if (transform.position.x > mem)
        {
            Vector3 theScale = transform.localScale;
            //зеркально отражаем персонажа по оси Х
            theScale.x = old.x;
            //задаем новый размер персонажа, равный старому, но зеркально отраженный
            transform.localScale = theScale;
        }
        if (transform.position.x < mem)
        {
            Vector3 theScale = transform.localScale;
            //зеркально отражаем персонажа по оси Х
            theScale.x = -old.x;
            //задаем новый размер персонажа, равный старому, но зеркально отраженный
            transform.localScale = theScale;
        }


    }



}
