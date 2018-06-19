using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PPtext : MonoBehaviour {

    public Text scoreName;
    public int score = 000000;
    
    void Update () {
        scoreName = GameObject.Find("Score").GetComponent<Text>();
        scoreName.text = "Score: " + score;
    }
}
