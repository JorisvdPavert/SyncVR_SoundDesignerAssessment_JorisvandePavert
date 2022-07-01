using UnityEngine;
using UnityEngine.UI;

public class UIAudio : MonoBehaviour
{
    [SerializeField] AudioSource uiAudioSource = null;

    [Header("Audio Clips")]
    [SerializeField] AudioClip clickSound = null;

    void Awake()
    {
        this.uiAudioSource = GetComponent<AudioSource>();
        foreach (Button b in FindObjectsOfType<Button>(true))
        {
            b.onClick.AddListener(PlayClickSound);
        }
    }

    public void PlayClickSound()
    {
        uiAudioSource.PlayOneShot(clickSound);
    }
}
