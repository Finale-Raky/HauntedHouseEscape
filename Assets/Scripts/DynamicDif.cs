using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicDif : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    public GameObject Camera;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    //public int score;

    private int dif = 0;

    public void UpdateScoreDisplay()
    {
        //GetComponent<TMPro.TextMeshProUGUI>().text = "Dynamic Difficulty Adjustment: " + UsingScoreManager.score;
        dif = PlayerPrefs.GetInt("dif");
        if(dif == 1)
            GetComponent<TMPro.TextMeshProUGUI>().text = "Dynamic Difficulty Adjustment: Harder" ;
        else if(dif == -1)
            GetComponent<TMPro.TextMeshProUGUI>().text = "Dynamic Difficulty Adjustment: Easier" ;          
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "Dynamic Difficulty Adjustment: N/A" ;
        if(dif == 1){
            enemy1.GetComponent<UnityEngine.AI.NavMeshAgent>().speed += 3;
            enemy2.GetComponent<UnityEngine.AI.NavMeshAgent>().speed += 3;
            enemy3.GetComponent<UnityEngine.AI.NavMeshAgent>().speed += 3;
        }
        else if(dif == -1)
            enemy1.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 1.5f;
            enemy2.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreDisplay();
    }
}
