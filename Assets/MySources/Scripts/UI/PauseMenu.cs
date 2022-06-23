using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private AudioClip _buttonSound;

    private AudioSource _buttonAudioSource;

    private bool isPause;

    private void Start()
    {
        isPause = false;
        _buttonAudioSource = GetComponent<AudioSource>();
        _resumeButton.onClick.AddListener(Resume);
        _menuButton.onClick.AddListener(LoadMainMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isPause = !isPause;

        if (isPause)
            ShowPausePannel(isPause, 0f, CursorLockMode.None);
    }

    private void ShowPausePannel(bool showPause, float timeScale, CursorLockMode cursorLockMode)
    {
        _pausePanel.SetActive(showPause);
        Time.timeScale = timeScale;
        Cursor.lockState = cursorLockMode;
    }

    private void Resume()
    {
        _buttonAudioSource.PlayOneShot(_buttonSound);
        isPause = false;
        ShowPausePannel(isPause, 1f, CursorLockMode.Locked);
    }

    private void LoadMainMenu()
    {
        _buttonAudioSource.PlayOneShot(_buttonSound);
        SceneManager.LoadScene(0);
    }
    
}
