using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour {


	public Slider engineVolume,musicVolume;

	public Toggle showDistance,coinAudio;

	public TMP_Text currentResolution,currentQuality;

	public bool activateCheats;

	void Start () {
	

		if (PlayerPrefs.GetInt ("ShowDistance") == 3)  // 3=> true - 0 => false
			showDistance.isOn = true;
		else
			showDistance.isOn = false;

		if (PlayerPrefs.GetInt ("CoinAudio") == 3)  // 3=> true - 0 => false
			coinAudio.isOn = true;
		else
			coinAudio.isOn = false;
		
		if (PlayerPrefs.GetInt("Resolution") == 0)
			currentResolution.text = "500P";
		if (PlayerPrefs.GetInt("Resolution") == 1)
			currentResolution.text = "720P";
		if (PlayerPrefs.GetInt("Resolution") == 2)
			currentResolution.text = "1080P";

		if (PlayerPrefs.GetInt("Quality") == 0)
			currentQuality.text = "低";
		if (PlayerPrefs.GetInt("Quality") == 3)
			currentQuality.text = "中";
		if (PlayerPrefs.GetInt("Quality") == 5)
			currentQuality.text = "高";
		
		engineVolume.value = PlayerPrefs.GetFloat ("EngineVolume");
		musicVolume.value = PlayerPrefs.GetFloat ("MusicVolume");


	}


	public void SetEngineVolume()
	{

		PlayerPrefs.SetFloat("EngineVolume",engineVolume.value);
	}

	public void SetMusicVolume()
	{

		PlayerPrefs.SetFloat("MusicVolume",musicVolume.value);
	}

	public void SetShowDistance()
	{

		StartCoroutine (saveDistance ());
	}


	IEnumerator saveDistance()
	{
		
		yield return new WaitForEndOfFrame ();

		if(showDistance.isOn)
			PlayerPrefs.SetInt("ShowDistance",3);// 3=> true - 0 => false
		else
			PlayerPrefs.SetInt("ShowDistance",0);// 3=> true - 0 => false

	}

	public void SetCoinAudio()
	{

		StartCoroutine (saveCoinAudio ());
	}


	IEnumerator saveCoinAudio()
	{

		yield return new WaitForEndOfFrame ();

		if(coinAudio.isOn)
			PlayerPrefs.SetInt("CoinAudio",3);// 3=> true - 0 => false
		else
			PlayerPrefs.SetInt("CoinAudio",0);// 3=> true - 0 => false

	}

	public void SetResolution(int val)
	{

		PlayerPrefs.SetInt ("Resolution", val);

		if (PlayerPrefs.GetInt("Resolution") == 0)
			currentResolution.text = "500P";
		if (PlayerPrefs.GetInt("Resolution") == 1)
			currentResolution.text = "720P";
		if (PlayerPrefs.GetInt("Resolution") == 2)
			currentResolution.text = "1080P";

	}

	
	public void SetQualityLevel(int val)
	{

		PlayerPrefs.SetInt ("Quality", val);

		if (PlayerPrefs.GetInt("Quality") == 0)
			currentQuality.text = "低";
		if (PlayerPrefs.GetInt("Quality") == 3)
			currentQuality.text = "中";
		if (PlayerPrefs.GetInt("Quality") == 5)
			currentQuality.text = "高";

		QualitySettings.SetQualityLevel (val);

	}
	
	
}
