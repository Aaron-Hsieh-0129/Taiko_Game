using UnityEngine;
using UnityEngine.SceneManagement;
public class Song_Dive : MonoBehaviour
{
    public void Song()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.instance.Dong();
        }
    }
}

