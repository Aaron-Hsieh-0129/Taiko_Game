using UnityEngine;
using TMPro;

public class goodcount : MonoBehaviour
{
    private int goodNumber;
    private GameObject good;
    
    // Update is called once per frame
    void Update()
    {
        goodNumber = Activator.countGood;
        GetComponent<TMP_Text>().text = goodNumber + "";
    }
}
