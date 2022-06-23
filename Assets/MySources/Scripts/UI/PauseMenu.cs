using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _menuButton;

    private bool isPause;

    private void Start()
    {
        isPause = false;
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
        isPause = false;
        ShowPausePannel(isPause, 1f, CursorLockMode.Locked);
    }

    private void LoadMainMenu() =>
        SceneManager.LoadScene(0);
    
}
