using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSaver : MonoBehaviour
{
	public Button saveButton;
	public Scene previousScene;

	private void Start()
	{
		saveButton = GetComponent<Button>();
		saveButton.onClick.AddListener(SaveScene);
	}

	public void SaveScene()
	{
		previousScene = SceneManager.GetActiveScene();

		GameObject[] sceneObjects = previousScene.GetRootGameObjects();
		GameObject[] cloneObjects = new GameObject[sceneObjects.Length];
		for (int i = 0; i < sceneObjects.Length; i++)
		{
			cloneObjects[i] = Instantiate(sceneObjects[i]);
			DontDestroyOnLoad(cloneObjects[i]);
		}

		SceneManager.LoadScene("NewScene");

		for (int i = 0; i < cloneObjects.Length; i++)
		{
			Destroy(cloneObjects[i]);
		}
	}
}
