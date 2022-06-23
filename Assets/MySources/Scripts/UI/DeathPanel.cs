using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathPanel : MonoBehaviour
{
    [SerializeField] private GameObject _deathPanel;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Player _player;

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
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }

    private void LoadMainMenu() =>
        SceneManager.LoadScene(0);
}
