using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class BScoore : MonoBehaviour
{
    public Text TextTime;
    static int bs=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextTime.text = "Best Score: " + bs.ToString();
    }


    public static void bestscore(int a)
    {
        if (a > bs)
        {
            bs = a;

            Social.ReportScore(bs, "CgkIqbXcv-AEEAIQAA", (bool success) => {
                // Удачно или нет?
            });
        }
        return;



    }






}
