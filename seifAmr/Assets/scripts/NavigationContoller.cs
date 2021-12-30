using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationContoller : MonoBehaviour
{
	public void GoToIntroScene()
	{
		Application.LoadLevel(0);
	}
	public void GoToGameOverScene()
	{
		Application.LoadLevel(2);
	}
	public void GoToVictoryScene()
	{
		Application.LoadLevel(3);
	}
	public void Scene_1()
	{
		SceneManager.LoadScene(1);

	}
	public void Scene_2()
	{
		SceneManager.LoadScene(4);

	}
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
