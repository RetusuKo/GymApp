using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    public void LoadScene(int loadSceneNumber)
    {
        SceneManager.LoadScene(loadSceneNumber);
    }
    public void LoadTrainingScene()
    {
        SceneManager.LoadScene("Training");
    }
}