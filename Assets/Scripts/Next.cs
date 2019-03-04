using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class Next : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate((bool success) => {
            // Удачно или нет?
        });

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayPressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void achievements()
    {
        Social.ShowAchievementsUI();
    }

    public void login()
    {

    }

    public void lider()
    {
        Social.ShowLeaderboardUI();
    }
}
