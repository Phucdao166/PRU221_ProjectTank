using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.WSA;

public class Global 
{
	public static void Quit()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
	}
	public static void Toast(string text, float lifeTime = 1.5f)
	{
		GameObject canvas = GameObject.Find("/Canvas");
		if (canvas != null)
		{
			GameObject obj = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Toast"));
			(obj.transform as RectTransform).SetParent(canvas.transform);
			obj.GetComponent<Toast>().Set(text, lifeTime);
		}
	}
	public static void EnterGame()
	{
		//NetworkManager.singleton.ServerChangeScene(GameData.gameScene);
		GameData.currentScene = GameData.gameScene; // manager.networkSceneName
	}
	public static void EnterWelcome()
	{
		//ClearConnection();
		SceneManager.LoadScene(GameData.welcomeScene);
		GameData.currentScene = GameData.welcomeScene;
	}

	//public static void ClearConnection()
	//{
	//	if (NetworkManager.singleton != null)
	//	{
	//		if (NetworkClient.isConnected)
	//		{
	//			NetworkManager.singleton.StopClient();
	//		}
	//		if (NetworkServer.active)
	//		{
	//			NetworkManager.singleton.StopServer();
	//		}
	//		UnityEngine.Object.Destroy(NetworkManager.singleton.gameObject);
	//		GameData.networkPlayers.Clear();
	//	}
	//}
}
