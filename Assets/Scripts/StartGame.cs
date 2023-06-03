using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
	//public GameObject tankNetworkManager;
	public Button singleBtn;
	public Button doubleBtn;
	public Button exitBtn;
	public Button notShowBtn;
	public Button skipBtn;
	public Image startPanel;

	public string sceneName;

	private void Awake()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	private void Start()
    {
		singleBtn.onClick.AddListener(() => ClickEnter(TankMode.SINGLE));
		doubleBtn.onClick.AddListener(() => ClickEnter(TankMode.DOUBLE));
		exitBtn.onClick.AddListener(() => Global.Quit());
		skipBtn.onClick.AddListener(() => EnterGame());
		notShowBtn.onClick.AddListener(() => {
			SetShowTutorial(false);
			EnterGame();
		});
	}
	private void Update()
	{
		BackOperationUpdate();
	}

	private void ClickEnter(TankMode mode)
	{
		GameData.mode = mode;
		//NetworkServer.dontListen = true;
		GameData.isHost = true;
		//Instantiate(tankNetworkManager);
		//NetworkManager.singleton.StartHost();
		if (GameData.isMobile || !IsShowTutorial())
		{
			EnterGame();
		}
		else
		{
			startPanel.gameObject.SetActive(true);
		}
	}

	private bool IsShowTutorial()
	{
		return PlayerPrefs.GetInt("tutorial", 1) > 0;
	}
	
	private void BackOperationUpdate()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			GetComponent<EscQuit>().ClickQuit();
		}
	}
	private void SetShowTutorial(bool show)
	{
		if (!show)
		{
			PlayerPrefs.SetInt("tutorial", 0);
		}
		else
		{
			PlayerPrefs.DeleteKey("tutorial");
		}
		PlayerPrefs.Save();
	}
	private void EnterGame()
	{
		Global.EnterGame();
	}
	public void changeScene()
	{
		SceneManager.LoadScene(sceneName);
	}
}
