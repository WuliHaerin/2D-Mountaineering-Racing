using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Upgrade : MonoBehaviour
{

	public TMP_Text UpgradeCoinsTXT;
	[HideInInspector]public int Engine, Fuel, Suspension, Speed;

	[Header("Upgrades price")]
	public int[] enginePrice;
	public int[] fuelPrice;
	public int[] suspensionPrice;
	public int[] speedPrice;


	int id;

	[Header("Informatin Texts")]
	public TMP_Text CoinsTXT;
	public TMP_Text TorqueTXT, SuspensionTXT, FuelTXT, SpeedTXT;
	public TMP_Text priceTorqueTXT, priceSuspensionTXT, priceFuelTXT, priceSpeedTXT;

	[Header("Show Window")]
	public GameObject Shop;
	public GameObject Loading;

	[Header("Sound Clips")]
	public AudioClip Buy, Caution;
	public  AudioSource audioSource;

	[Header("Control Assistance CheakBox")]
	public Toggle ControllAsist;

    private void OnEnable()
    {
		LoadUpgrade();
		//Debug.Log(PlayerPrefs.GetInt("SelectedCar"));
		//Debug.Log("id:" + id);
	}

    void Start ()
	{
		
		LoadUpgrade ();
		UpgradeCoinsTXT.text = PlayerPrefs.GetInt("Coins").ToString();

	}
	
	public void LoadUpgrade()
	{
		id = PlayerPrefs.GetInt("SelectedCar");
		Engine = PlayerPrefs.GetInt ("Engine" + id.ToString ());
		Fuel = PlayerPrefs.GetInt ("Fuel" + id.ToString ());
		Suspension = PlayerPrefs.GetInt ("Suspension" + id.ToString ());
		Speed = PlayerPrefs.GetInt ("Speed" + id.ToString ());

		TorqueTXT.text = "等级: "+ Engine.ToString ()+" / "+enginePrice.Length.ToString();
		SuspensionTXT.text = "等级: " + Suspension.ToString ()+" / "+suspensionPrice.Length.ToString();
		FuelTXT.text = "等级: " + Fuel.ToString ()+" / "+fuelPrice.Length.ToString();
		SpeedTXT.text = "等级: " + Speed.ToString ()+" / "+speedPrice.Length.ToString();
		  


		CoinsTXT.text = PlayerPrefs.GetInt ("Coins").ToString ();


		if (PlayerPrefs.GetInt ("Engine" + id.ToString ()) < enginePrice.Length)
			priceTorqueTXT.text = enginePrice [PlayerPrefs.GetInt ("Engine" + id.ToString ())].ToString () + " $";
		else
			priceTorqueTXT.text = "Completed";
		
		if (PlayerPrefs.GetInt ("Speed" + id.ToString ()) < speedPrice.Length)
			priceSpeedTXT.text = speedPrice[PlayerPrefs.GetInt ("Speed" + id.ToString ())].ToString()+ " $";
		else
			priceSpeedTXT.text = "Completed";
		
		if (PlayerPrefs.GetInt ("Fuel" + id.ToString ()) < fuelPrice.Length)
			priceFuelTXT.text = fuelPrice[PlayerPrefs.GetInt ("Fuel" + id.ToString ())].ToString()+ " $";
		else
			priceFuelTXT.text = "Completed";
		
		if (PlayerPrefs.GetInt ("Suspension" + id.ToString ()) < suspensionPrice.Length)	
			priceSuspensionTXT.text = suspensionPrice[PlayerPrefs.GetInt ("Suspension" + id.ToString ())].ToString()+ " $";
		else
			priceSuspensionTXT.text = "Completed";
		
		
	}
	void Update ()
	{
		//Debug.Log(PlayerPrefs.GetInt("Engine" + id.ToString()).ToString() + " / " + enginePrice.Length.ToString());
		//Debug.Log(PlayerPrefs.GetInt("Suspension" + id.ToString()).ToString() + " / " + suspensionPrice.Length.ToString());
		//Debug.Log(PlayerPrefs.GetInt("Fuel" + id.ToString()).ToString() + " / " + fuelPrice.Length.ToString());
		//Debug.Log(PlayerPrefs.GetInt("Speed" + id.ToString()).ToString() + " / " + speedPrice.Length.ToString());



		//#if UNITY_EDITOR
		//if (Input.GetKeyDown (KeyCode.H))
		//	PlayerPrefs.DeleteAll ();
		//#endif
	}

	public void EngineUpgrade ()
	{
		if (PlayerPrefs.GetInt ("Engine" + id.ToString ()) < enginePrice.Length) {

			if (PlayerPrefs.GetInt ("Coins") >= enginePrice[PlayerPrefs.GetInt ("Engine" + id.ToString ())]) {
				audioSource.clip = Buy;
				audioSource.Play ();
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - enginePrice[PlayerPrefs.GetInt ("Engine" + id.ToString ())]);
				PlayerPrefs.SetInt ("Engine" + id.ToString (), PlayerPrefs.GetInt ("Engine" + id.ToString ()) + 1);
				CoinsTXT.text = PlayerPrefs.GetInt ("Coins").ToString ();
				TorqueTXT.text = "等级 : " + PlayerPrefs.GetInt ("Engine" + id.ToString ()).ToString ()+" / "+enginePrice.Length.ToString();
				if (PlayerPrefs.GetInt ("Engine" + id.ToString ()) < enginePrice.Length)
					priceTorqueTXT.text = enginePrice [PlayerPrefs.GetInt ("Engine" + id.ToString ())].ToString () + " $";
				else
					priceTorqueTXT.text = "Completed";
			} else {
				Shop.SetActive (true);

				audioSource.clip = Caution;
				audioSource.Play ();
			}

		}
		UpgradeCoinsTXT.text = PlayerPrefs.GetInt("Coins").ToString();
		PlayerPrefs.Save();
	}

	public void SuspensionUpgrade ()
	{
		if (PlayerPrefs.GetInt ("Suspension" + id.ToString ()) < suspensionPrice.Length) {

			if (PlayerPrefs.GetInt ("Coins") >= suspensionPrice[PlayerPrefs.GetInt ("Suspension" + id.ToString ())]) {
				audioSource.clip = Buy;
				audioSource.Play ();
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - suspensionPrice[PlayerPrefs.GetInt ("Suspension" + id.ToString ())]);
				PlayerPrefs.SetInt ("Suspension" + id.ToString (), PlayerPrefs.GetInt ("Suspension" + id.ToString ()) + 1);
				CoinsTXT.text = PlayerPrefs.GetInt ("Coins").ToString ();
				SuspensionTXT.text = "等级 : " + PlayerPrefs.GetInt ("Suspension" + id.ToString ()).ToString ()+" / "+suspensionPrice.Length.ToString();
				if (PlayerPrefs.GetInt ("Suspension" + id.ToString ()) < speedPrice.Length)
					priceSuspensionTXT.text = suspensionPrice[PlayerPrefs.GetInt ("Suspension" + id.ToString ())].ToString()+ " $";
				else
					priceSuspensionTXT.text = "Completed";
			} else {
				Shop.SetActive (true);
				audioSource.clip = Caution;
				audioSource.Play ();
			}
		}
		UpgradeCoinsTXT.text = PlayerPrefs.GetInt("Coins").ToString();
		PlayerPrefs.Save();
	}

	public void FuelUpgrade ()
	{
		if (PlayerPrefs.GetInt ("Fuel" + id.ToString ()) < fuelPrice.Length) {

			if (PlayerPrefs.GetInt ("Coins") >= fuelPrice[PlayerPrefs.GetInt ("Fuel" + id.ToString ())]) {
				audioSource.clip = Buy;
				audioSource.Play ();
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - fuelPrice[PlayerPrefs.GetInt ("Fuel" + id.ToString ())]);
				PlayerPrefs.SetInt ("Fuel" + id.ToString (), PlayerPrefs.GetInt ("Fuel" + id.ToString ()) + 1);
				CoinsTXT.text = PlayerPrefs.GetInt ("Coins").ToString ();
				FuelTXT.text = "等级 : " + PlayerPrefs.GetInt ("Fuel" + id.ToString ()).ToString ()+" / "+fuelPrice.Length.ToString();
				if (PlayerPrefs.GetInt ("Fuel" + id.ToString ()) < fuelPrice.Length)
					priceFuelTXT.text = fuelPrice[PlayerPrefs.GetInt ("Fuel" + id.ToString ())].ToString()+ " $";
				else
					priceFuelTXT.text = "Completed";
			} else {
				Shop.SetActive (true);
				audioSource.clip = Caution;
				audioSource.Play ();
			}
		}
		UpgradeCoinsTXT.text = PlayerPrefs.GetInt("Coins").ToString();
		PlayerPrefs.Save();
	}




	public void SpeedUpgrade ()
	{
		if (PlayerPrefs.GetInt ("Speed" + id.ToString ()) < speedPrice.Length) {

			if (PlayerPrefs.GetInt ("Coins") >= speedPrice[PlayerPrefs.GetInt ("Speed" + id.ToString ())]) {
				audioSource.clip = Buy;
				audioSource.Play ();
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - speedPrice[PlayerPrefs.GetInt ("Speed" + id.ToString ())]);
				PlayerPrefs.SetInt ("Speed" + id.ToString (), PlayerPrefs.GetInt ("Speed" + id.ToString ()) + 1);
				CoinsTXT.text = PlayerPrefs.GetInt ("Coins").ToString ();
				SpeedTXT.text = "等级 : " + PlayerPrefs.GetInt ("Speed" + id.ToString ()).ToString ()+" / "+speedPrice.Length.ToString();
				if (PlayerPrefs.GetInt ("Speed" + id.ToString ()) < speedPrice.Length)
					priceSpeedTXT.text = speedPrice[PlayerPrefs.GetInt ("Speed" + id.ToString ())].ToString()+ " $";
				else
					priceSpeedTXT.text = "Completed";
			} else {
				Shop.SetActive (true);
				audioSource.clip = Caution;
				audioSource.Play ();
			}
		}
		UpgradeCoinsTXT.text = PlayerPrefs.GetInt("Coins").ToString();
		PlayerPrefs.Save();
	}


	public void StartGame ()
	{
		
		Loading.SetActive (true);
		PlayerPrefs.SetInt ("AllScoreTemp", PlayerPrefs.GetInt ("Coins"));
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync ("Level"+PlayerPrefs.GetInt ("SelectedLevel").ToString());

		//sceneLoading.ActivateNextScene();

		gameObject.SetActive (false);

	}


	public void SetControll ()
	{
		StartCoroutine (ControllAsistanceSave ());
	}

	IEnumerator ControllAsistanceSave ()
	{
		yield return new WaitForEndOfFrame ();

		if (ControllAsist.isOn)
			PlayerPrefs.SetInt ("Assistance", 3);   // 3=>true - 0=>false    
		else
			PlayerPrefs.SetInt ("Assistance", 0);   // 3=>true - 0=>false    
	}




}
