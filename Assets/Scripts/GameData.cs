using Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TankMode
{
	SINGLE,
	DOUBLE
}
public class GameData
{
	public const string welcomeScene = "StartGame";
	public const string gameScene = "Game";
	public static readonly bool isMobile;
	public static string currentScene;
	public static TankMode mode;

	public static int configTotalEnemyCount = 10;
	public static int configMaxAliveEnemyCount = 6;
	public static float configMinEnemySpawnTime = 0.5f;
	public static float configMaxEnemySpawnTime = 6f;
	public static float configEnemySpawnPointWaitTime = 3f;
	public static int[] configEnemyTypeWeights = { 40, 30, 10, 10, 10 }; // 100
	public static int configEnemyBonusWeight = 15; // 100
	public static float configEnemyMoveSpeed = 2f;
	public static float configMinEnemyFireTime = 0.5f;
	public static float configMaxEnemyFireTime = 6f;
	public static float configMinEnemyMoveTime = 0.5f;
	public static float configMaxEnemyMoveTime = 6f;

	public static int configInitialPlayerTankCount = 3; 
														
	public static float configBonusStopWatchTime = 10f;   
	public static float configBonusShieldTime = 15f;      
	public static float configBonusShovelTime = 40f;      
	public static int configMaxGameLevel = 5;

	public static int playerCount = 0;

	public static int totalEnemyCount;
	public static int maxAliveEnemyCount;
	public static float minEnemySpawnTime;
	public static float maxEnemySpawnTime;
	public static float minEnemyFireTime;
	public static float maxEnemyFireTime;
	public static float minEnemyMoveTime;
	public static float maxEnemyMoveTime;
	public static float enemySpawnPointWaitTime;
	public static int[] enemyTypeWeights = { 40, 30, 10, 10, 10 }; // 100
	public static int enemyBonusWeight; // 100
	public static bool enemyCrizy;

	public static int initialPlayerTankCount; 
											  
	public static float bonusStopWatchTime;   
	public static float bonusShieldTime;      
	public static float bonusShovelTime;      


	public static bool isGamePlaying;
	public static bool isGamePausing;
	public static bool isInGameLevel;             
	public static int spawnedEnemyCount;            
	public static int killedEnemyCount;             
	public static int aliveEnemyCount;              
	public static int alivePlayerCount;             
	public static int playerLifeCount;         
	public static bool isStopWatchRunning;          
	public static int[] playerLevels = new int[] { 0, 0, 0, 0 }; 
																 
	public static int maxGameLevel;                 
	public static int gameLevel;

	public const string PLAYER_NAME_KEY = "PlayerName";
	public const string SKIP_TUTORIAL_KEY = "SkipTutorial";
	public const string MAIN_VOLUME_KEY = "MainVolume";
	public const string BACK_VOLUME_KEY = "BackVolume";
	public const string EFFECT_VOLUME_KEY = "EffectVolume";
	public const string ENGINE_VOLUME_KEY = "EngineVolume";
	public static string playerName;                
	public static bool isSkipTutorial;

	public static bool isHost;
	//public static List<NetworkConnection> networkPlayers = new List<NetworkConnection>();

	public static float EnemySpawnTime
	{
		get
		{
			if (enemyCrizy) { return minEnemySpawnTime; }
			return UnityEngine.Random.Range(minEnemySpawnTime, maxEnemySpawnTime);
		}
	}
	public static bool CanSpawnEnemy { get { return spawnedEnemyCount < totalEnemyCount && aliveEnemyCount < maxAliveEnemyCount; } }
	public static int EnemyType
	{
		get
		{
			int num = UnityEngine.Random.Range(0, 100);
			for (int i = 0; i < enemyTypeWeights.Length; ++i)
			{
				if (num < enemyTypeWeights[i]) { return i; }
				num -= enemyTypeWeights[i];
			}
			return 0;
		}
	}
	public static float EnemySpeed
	{
		get
		{
			if (enemyCrizy) { return configEnemyMoveSpeed * 3f; }
			return configEnemyMoveSpeed;
		}
	}
	public static float EnemyFireTime
	{
		get
		{
			if (enemyCrizy) { return UnityEngine.Random.Range(minEnemyFireTime, minEnemyFireTime + 0.5f); }
			return UnityEngine.Random.Range(minEnemyFireTime, maxEnemyFireTime);
		}
	}
	public static float EnemyMoveTime
	{
		get
		{
			if (enemyCrizy) { return UnityEngine.Random.Range(0.2f, minEnemyMoveTime); }
			return UnityEngine.Random.Range(minEnemyMoveTime, maxEnemyMoveTime);
		}
	}
	public static int LeftEnemyCount { get { return totalEnemyCount - spawnedEnemyCount + aliveEnemyCount; } }
	public static bool EnemyBonus { get { return UnityEngine.Random.Range(0, 100) < enemyBonusWeight; } }
	public static bool CanSpawnPlayer { get { return playerLifeCount > 0; } }
	public static int PlayerTankCount { get { return playerLifeCount; } }
	//public static bool IsLan { get { return mode == TankMode.LAN; } }
	static GameData()
	{
		
#if UNITY_IOS || UNITY_ANDROID
            isMobile = true;
#else
		isMobile = false;
#endif
		
		currentScene = welcomeScene;
		
		Messager.Instance.Listen(MessageID.GAME_START, OnGameStart);
		Messager.Instance.Listen(MessageID.ENEMY_SPAWN, OnEnemySpawn);
		Messager.Instance.Listen(MessageID.ENEMY_DIE, OnMsgEnemyDie);
		Messager.Instance.Listen<int, bool>(MessageID.PLAYER_SPAWN, OnMsgPlayerSpawn);
		Messager.Instance.Listen<int>(MessageID.PLAYER_DIE, OnMsgPlayerDie);
		Messager.Instance.Listen(MessageID.BONUS_TANK_TRIGGER, OnMsgBonusTank);
		Messager.Instance.Listen(MessageID.GAME_WIN, OnMsgGameWin);
		Messager.Instance.Listen(MessageID.GAME_OVER, OnMsgGameOver);
		Messager.Instance.Listen(MessageID.GAME_PAUSE, OnMsgGamePause);
		Messager.Instance.Listen(MessageID.GAME_RESUME, OnMsgGameResume);
		Messager.Instance.Listen(MessageID.START_LEVEL, OnMsgStartLevel);
		Messager.Instance.Listen(MessageID.LEVEL_WIN, OnMsgLevelWin);
		
		ReadCache();
	}
	public static void ReadCache()
	{
		playerName = PlayerPrefs.GetString(PLAYER_NAME_KEY, SystemInfo.deviceName);
		isSkipTutorial = PlayerPrefs.GetInt(SKIP_TUTORIAL_KEY, 0) > 0;
	}
	public static void ClearPrefDatas()
	{
		PlayerPrefs.DeleteAll();
	}
	private static void OnGameStart()
	{
		
		GameStartInitial();
		
		Messager.Instance.Send(MessageID.DATA_GAME_START);
	}
	private static void GameStartInitial()
	{
		
		gameLevel = 0;
		maxGameLevel = configMaxGameLevel;
		
		for (int i = 0; i < enemyTypeWeights.Length; ++i)
		{
			enemyTypeWeights[i] = configEnemyTypeWeights[i];
		}
		enemyBonusWeight = configEnemyBonusWeight; // 100
												   
		//playerCount = networkPlayers.Count;
		initialPlayerTankCount = playerCount * 3; 
		playerLifeCount = initialPlayerTankCount;   
		for (int i = 0; i < playerLevels.Length; ++i) { playerLevels[i] = 0; }
		
		bonusStopWatchTime = configBonusStopWatchTime;   
		bonusShieldTime = configBonusShieldTime;      
		bonusShovelTime = configBonusShovelTime;      
													  
		spawnedEnemyCount = 0;
		aliveEnemyCount = 0;
		alivePlayerCount = 0;
		
		isGamePlaying = true;
		isGamePausing = false;
		isInGameLevel = false;
	}
	private static void OnMsgStartLevel()
	{
		GameLevelDataInitial();
	}
	private static void OnMsgLevelWin()
	{
		//isInGameLevel = false;
		//Tank[] players = GameObject.FindObjectsOfType<Tank>();
		//for (int i = 0; i < playerLevels.Length; ++i) { playerLevels[i] = 0; }
		////foreach (Tank p in players)
		////{
		////	Debug.Log($"GameData level win: id[{p.id}]-level[{p.level}]");
		////	playerLevels[p.id] = p.level;
		////}
		//if (gameLevel < maxGameLevel)
		//{
		//	++gameLevel;
		//	Messager.Instance.Send(MessageID.DATA_LEVEL_WIN);
		//}
		//else
		//{
		//	Messager.Instance.Send(MessageID.GAME_WIN);
		//}
	}

	private static void SetLevelDifficulty()
	{
		
		totalEnemyCount = configTotalEnemyCount + playerCount * 10 * (gameLevel + 1);
		maxAliveEnemyCount = playerCount + 3 + gameLevel;
		minEnemySpawnTime = configMinEnemySpawnTime;
		maxEnemySpawnTime = configMaxEnemySpawnTime - (playerCount + gameLevel + 1) * 0.5f;
		minEnemyFireTime = configMinEnemyFireTime;
		maxEnemyFireTime = configMaxEnemyFireTime - (playerCount + gameLevel + 1) * 0.5f;
		minEnemyMoveTime = configMinEnemyMoveTime;
		maxEnemyMoveTime = configMaxEnemyMoveTime - (playerCount + gameLevel + 1) * 0.5f;
		enemySpawnPointWaitTime = configEnemySpawnPointWaitTime - (playerCount + gameLevel + 1) * 0.25f;
	}
	
	private static void GameLevelDataInitial()
	{
		enemyCrizy = false;
		
		//playerCount = networkPlayers.Count;
		isStopWatchRunning = false;
		
		spawnedEnemyCount = 0;
		aliveEnemyCount = 0;
		alivePlayerCount = 0;
		SetLevelDifficulty();
	}
	private static void OnEnemySpawn()
	{
		++spawnedEnemyCount;
		++aliveEnemyCount;
		if (!enemyCrizy && totalEnemyCount - spawnedEnemyCount <= (gameLevel - 2) * 2)
		{
			enemyCrizy = true;
			Messager.Instance.Send(MessageID.ENEMY_CRIZY);
		}
		Messager.Instance.Send(MessageID.DATA_ENEMY_SPAWN);
	}
	private static void OnMsgEnemyDie()
	{
		--aliveEnemyCount;
		++killedEnemyCount;
		Messager.Instance.Send(MessageID.DATA_ENEMY_DIE);
	}
	private static void OnMsgPlayerSpawn(int id, bool isFree)
	{
		++alivePlayerCount;
		if (isFree)
		{
			return;
		}
		--playerLifeCount;
		Messager.Instance.Send<int>(MessageID.DATA_PLAYER_SPAWN, id);
	}
	private static void OnMsgPlayerDie(int id)
	{
		--alivePlayerCount;
		Messager.Instance.Send<int>(MessageID.DATA_PLAYER_DIE, id);
	}
	private static void OnMsgBonusTank()
	{
		++playerLifeCount;
		Messager.Instance.Send(MessageID.DATA_BONUS_TANK);
	}
	private static void OnMsgGameWin()
	{
		isGamePlaying = false;
	}
	private static void OnMsgGameOver()
	{
		isGamePlaying = false;
	}
	private static void OnMsgGamePause()
	{
		isGamePausing = true;
	}
	private static void OnMsgGameResume()
	{
		isGamePausing = false;
	}
}

