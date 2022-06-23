using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;

    private void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        _playButton.onClick.AddListener(Play);
        _quitButton.onClick.AddListener(Quit);
    }

    private void Play()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }

    private void Quit() =>
        Application.Quit();

}
