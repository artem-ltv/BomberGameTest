using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinningPanel : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;

    private void Start()
    {
        _restartButton.onClick.AddListener(RestartLevel);
        _menuButton.onClick.AddListener(LoadMainMenu);
    }

    private void RestartLevel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }

    private void LoadMainMenu() =>
        SceneManager.LoadScene(0);
}
