using UnityEngine;
using TMPro;
public class Combo : MonoBehaviour
{
    public int combo;
    public static int maxCombo;

    void Update()
    {
        if (maxCombo <= combo) { maxCombo = combo; } // 計算最大Combo
        GetComponent<TMP_Text>().text = combo + "";
    }
    
    public void AddCombo(int delta)
    {
        combo += delta;
    }

    public void Reset()
    {
        combo = 0;
    }
}
