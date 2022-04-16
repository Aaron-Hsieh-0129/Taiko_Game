using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score;
    void Update()
    {
        GetComponent<TMP_Text>().text = score + "";
    }
    
    public void AddScore(int delta)
    {
        score += delta;
    }
}
