using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{ 
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void UIEnable()
    {
        GameObject.Find("Canvas/MainMenu/UI").SetActive(true);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { SoundManager.instance.Dong(); }
    }
}
