using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    public Text user;
    public Text ai;
    float timeLeft = 120;

    public Text text;

    void Update()
    {
        int user_score = int.Parse(user.text);
        int ai_score = int.Parse(ai.text);
        //timeLeft--;
        //timeLeft -= Time.deltaTime;
        timeLeft = timeLeft-Time.deltaTime;
        text.text = "" + Mathf.Round(timeLeft);
        if ((timeLeft < 0 )&&(user_score>ai_score))
        {
            Application.LoadLevel("UserWon");
        }
        else if((timeLeft < 0) && (user_score < ai_score))
        {
            Application.LoadLevel("AIWon");
        }
        else if((timeLeft < 0) && (user_score == ai_score))
        {
            Application.LoadLevel("draw");
        }
    }
}
