using UnityEngine;
using TMPro;
public class badcount : MonoBehaviour
{
    private int badNumber;
    private GameObject bad;
    
    // Update is called once per frame
    void Update()
    {
        badNumber = Activator.countBad;
        GetComponent<TMP_Text>().text = badNumber + "";
    }
}
