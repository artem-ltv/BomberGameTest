using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Menu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private AudioClip _buttonSound;

    private AudioSource _buttonAudioSource;

    private void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        _buttonAudioSource = GetComponent<AudioSource>();
        _playButton.onClick.AddListener(Play);
        _quitButton.onClick.AddListener(Quit);
    }

    private void Play()
    {
        _buttonAudioSource.PlayOneShot(_buttonSound);
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }

    private void Quit()
    {
        _buttonAudioSource.PlayOneShot(_buttonSound);
        Application.Quit();
    }

}
