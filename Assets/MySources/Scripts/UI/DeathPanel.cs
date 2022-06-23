using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class DeathPanel : MonoBehaviour
{
    [SerializeField] private GameObject _deathPanel;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Player _player;
    [SerializeField] private AudioClip _buttonSound;

    private AudioSource _buttonAudioSource;

    private void Start() =>
        _buttonAudioSource = GetComponent<AudioSource>();

    private void OnEnable() =>
        _player.Dying += EnableDeathPanel;

    private void OnDisable() =>
        _player.Dying -= EnableDeathPanel;


    private void EnableDeathPanel()
    {
        _deathPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
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
