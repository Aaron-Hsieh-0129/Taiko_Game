using UnityEngine;

public class comboBoundary : MonoBehaviour
{
    private bool dongBoundary = false;
    private bool kaBoundary = false;
    
    public NoteObj Notes;
    public Combo combo;

    // Update is called once per frame
    void Update()
    {
        if (dongBoundary || kaBoundary)  combo.Reset();
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Note")
        {
            dongBoundary = true;
            Notes.Dong = col.gameObject;
        }

        if (col.gameObject.tag == "Note2")
        {
            kaBoundary = true;
            Notes.Ka = col.gameObject;
        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Note")
        {
            dongBoundary = false;
            Notes.Dong = col.gameObject;
        }

        if (col.gameObject.tag == "Note2")
        {
            kaBoundary = false;
            Notes.Ka = col.gameObject;
        }
    }
}
