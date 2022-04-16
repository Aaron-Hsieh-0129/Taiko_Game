using UnityEngine;
using TMPro;

public class scorecount : MonoBehaviour
{
    private int scoreNumber;
    private GameObject score;
    
    // Update is called once per frame
    void Update()
    {
        scoreNumber = Score.score;
        GetComponent<TMP_Text>().text = scoreNumber + "";
    }
}
