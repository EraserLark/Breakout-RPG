using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        NewGame();
    }

    void NewGame()
    {
        LoadLevel(1);
    }

    void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
