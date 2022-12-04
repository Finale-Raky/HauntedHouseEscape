using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 0.5f;
    public float displayImageDuration = 0.5f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;
    public CanvasGroup RestartBackgroundImageCanvasGroup;
    public AudioSource reAudio;

    bool m_IsPlayerCaught;
    bool m_IsPlayerAtExit;
    bool m_HasAudioPlayed;
    float m_Timer;
    bool doRestart;

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
        //UsingScoreManager.DecreaseScore();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            m_IsPlayerAtExit = true;

        }
    }

    void doRestartornot()
    {
        if(Input.GetKeyUp(KeyCode.R))
        doRestart = true;
    }

    void Update()
    {
        doRestartornot();
        if(m_IsPlayerAtExit)
        {
            PlayerPrefs.SetInt("dif", 1);
            Endlevel(exitBackgroundImageCanvasGroup, /*false, */exitAudio);
        }
        else if(m_IsPlayerCaught)
        {
            PlayerPrefs.SetInt("dif", -1);
            Endlevel(caughtBackgroundImageCanvasGroup, /*ture, */caughtAudio);
        }
        else if(doRestart)
        {
            Endlevel(RestartBackgroundImageCanvasGroup, reAudio);
        }
    }

    void Endlevel(CanvasGroup imageCanvasGroup, /*bool doRestart, */AudioSource audioSource)
    {
        if(!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;
        
        if(m_Timer > fadeDuration + displayImageDuration)
        {
            /*if(doRestart)
            {*/
            SceneManager.LoadScene(0);
            PlayerPrefs.SetInt("act", 1);
            /*}
            else
            {
                Application.Quit();
            }*/
        }
    }
}
