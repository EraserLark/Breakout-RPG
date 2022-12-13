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

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void LoadLevel(string levelName)
    {
        switch(levelName)
        {
            case "Overworld":
                SceneManager.LoadScene(1);
                break;
            default:
                Debug.Log("Level name does not exist");
                break;
        }
    }
}
