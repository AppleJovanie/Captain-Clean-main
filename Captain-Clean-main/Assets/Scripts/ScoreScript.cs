using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static int scoreValue;
    Text score;

     void Start()
    {
        score = GetComponent<Text>();
    }
     void Update()
    {
        score.text = "Enemy Killed :" + scoreValue;
    }
}
