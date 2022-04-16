using UnityEngine;
using TMPro;
public class combocount : MonoBehaviour
{
    private int comboNumber;
    private GameObject combo;
    
    // Update is called once per frame
    void Update()
    {
        comboNumber = Combo.maxCombo;
        GetComponent<TMP_Text>().text = comboNumber + "";
    }
}
