using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    public AudioSource audioSource;
    [SerializeField] private AudioClip dong, ka;
    private void Awake()
    {
        instance = this;
    }
    
    public void Dong()
    {
        audioSource.clip = dong;
        audioSource.Play();
    }

    public void Ka()
    {
        audioSource.clip = ka;
        audioSource.Play();
    }
}