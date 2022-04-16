using UnityEngine;

public class recycleNote : MonoBehaviour
{
    public NoteObj Notes;

    private bool destroyDong = false;
    private bool destroyKa = false;

    void Update()
    {
        if (destroyDong) { Destroy(Notes.Dong); }

        if (destroyKa) { Destroy(Notes.Ka); }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Note")
        {
            destroyDong = true;
            Notes.Dong = col.gameObject;
        }

        if (col.gameObject.tag == "Note2")
        {
            destroyKa = true;
            Notes.Ka = col.gameObject;
        }
    }
}
