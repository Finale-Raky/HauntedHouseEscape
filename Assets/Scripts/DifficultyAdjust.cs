using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyAdjust : MonoBehaviour
{
    public float arriveATime = 8f;
    public GameObject player;

    public CanvasGroup hardersubtitle;
    public CanvasGroup easiersubtitle;

    bool m_IsPlayerArrivedA = false;
    bool active = false;
    float curtime;

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerArrivedA = true;
        }
    }

    void Start(){
        
    }

    void Update ()
    {   
        curtime += Time.deltaTime;
        if(m_IsPlayerArrivedA && !active)
        {
            judgement();
            active = true;
        }
    }

    void judgement(){
        if(curtime < arriveATime)
        {
            Harder ();
        }
        else
        {
            Easier ();
        }
    }

    void Harder(){
        hardersubtitle.alpha = 1;
        PlayerPrefs.SetInt("act", 1);
        PlayerPrefs.SetInt("dif", 1);//ScoreManager.Instance.IncreaseScore();
    }

    void Easier(){
        easiersubtitle.alpha = 1;
        PlayerPrefs.SetInt("act", 1);
        PlayerPrefs.SetInt("dif", -1);
        //ScoreManager.Instance.DecreaseScore();
    }
}
