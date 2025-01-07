using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Pause : MonoBehaviour
{
	// Use this for initialization
	public GameObject PauseMen;


	public string menuLevelName = "MainMenu";

	public TMP_Text loadingText;
	// Update is called once per frame
	public void Pausing()
	{
		Time.timeScale = 0f;
		PauseMen.SetActive (true);
	}

	public void Resume ()
	{
		Time.timeScale = 1f;
		PauseMen.SetActive (false);
	}

	public void Retry ()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void Exit ()
	{
		loadingText.text = "请稍等 ...";
		Time.timeScale = 1f;
		SceneManager.LoadScene(menuLevelName);
	}

	public void Reborn()
    {
		GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
		gameManager.Reborn();
    }



}
