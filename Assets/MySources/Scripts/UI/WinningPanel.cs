using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinningPanel : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private AudioClip _buttonSound;

    private AudioSource _buttonAudioSource;

    private void Start()
    {
        _buttonAudioSource = GetComponent<AudioSource>();
        _restartButton.onClick.AddListener(RestartLevel);
        _menuButton.onClick.AddListener(LoadMainMenu);
    }

    private void RestartLevel()
    {
        _buttonAudioSource.PlayOneShot(_buttonSound);
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }

    private void LoadMainMenu()
    {
        _buttonAudioSource.PlayOneShot(_buttonSound);
        SceneManager.LoadScene(0);
    }
}
