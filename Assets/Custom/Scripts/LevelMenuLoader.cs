using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuLoader : MonoBehaviour
{

    [SerializeField] private string sceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // Stop Play Mode in the Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Quit the application in a standalone build
        Application.Quit();
#endif
    }
}
