using UnityEngine;
using UnityEditor;

public class SceneSaveManager : MonoBehaviour
{
    public void SaveScene()
    {
        // Save the current scene
        Scene currentScene = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene();
        UnityEditor.SceneManagement.EditorSceneManager.SaveScene(currentScene);
    }
}