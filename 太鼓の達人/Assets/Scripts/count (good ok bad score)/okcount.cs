using UnityEngine;
using TMPro;
public class okcount : MonoBehaviour
{
    private int okNumber;
    private GameObject ok;
    
    // Update is called once per frame
    void Update()
    {
        okNumber = Activator.countOk;
        GetComponent<TMP_Text>().text = okNumber + "";
    }
}
