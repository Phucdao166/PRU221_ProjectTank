using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSaver : MonoBehaviour
{
	public Button saveButton;
	public Scene previousScene;
	public GameObject[] sceneObjects;
	public GameObject[] cloneObjects;

	public void Start()
	{
		saveButton = GetComponent<Button>();
		saveButton.onClick.AddListener(SaveAndReturnToPreviousScene);
	}

	public void SaveAndReturnToPreviousScene()
	{
		// Lưu scene hiện tại thành một bản sao
		previousScene = SceneManager.GetActiveScene();
		sceneObjects = previousScene.GetRootGameObjects();
		cloneObjects = new GameObject[sceneObjects.Length];
		for (int i = 0; i < sceneObjects.Length; i++)
		{
			cloneObjects[i] = Instantiate(sceneObjects[i]);
			DontDestroyOnLoad(cloneObjects[i]);
		}

		// Quay lại scene trước đó
		SceneManager.LoadScene(previousScene.name);
	}

	public void OnDestroy()
	{
		// Hủy bỏ các đối tượng clone khi chuyển scene
		if (cloneObjects != null)
		{
			for (int i = 0; i < cloneObjects.Length; i++)
			{
				//Destroy(cloneObjects[i]);
			}
		}
	}
}
