using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscQuit : MonoBehaviour
{
	public float quitWaitTime = 2f; 
	public string quitTip = "Tap again to exit";
	public float quitTimer;
	public void ClickQuit()
	{
		if (quitTimer <= 0f)
		{
			quitTimer = quitWaitTime;
			Global.Toast(quitTip);
		}
		else
		{
			Global.Quit();
		}
	}
	void Update()
	{
		if (quitTimer > 0f)
		{
			quitTimer -= Time.deltaTime;
		}
	}
}
