// Terms of the use :
// * You can only use this script to offer platers for other or your games
// * You cannot offer anythings else like sexual contents or other things (just content for children)



using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;

public class GameNews : MonoBehaviour {



	[Space(3)] // Enter your news txt file url as newsURL and yout news links txt file as linksURL
	public string newsURL,linksURL;



	// News border thas's will be activated when news has been loaded
	public GameObject target;

	// Display news on this text
	public Text ShowTXT;

	// Internal usage
	string[] LinkURLs,LinkURLsView;
	// Next news update based on animator current clip's length
	float NextTime;

	int temp;
	int temp2;

	WWW www,wwwURLs;

	void Start()
	{
		// Strt loading news from net
		StartCoroutine (ReadLinks ());
		StartCoroutine (ReadLinksUrls ());

	}

	// Use this public function on unity UI.Button onClick() event to open news link on web browser
	public void viewAd()
	{
		if(LinkURLsView [temp2].Contains("https"))
			Application.OpenURL (LinkURLsView [temp2]);
		else
			GameObject.FindObjectOfType<MenuTools>().OpenGooglePlay(LinkURLsView [temp2]);
	}


	// Update to next news over time
	IEnumerator Show()
	{
		NextTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;

		while (true) {

			temp2 = temp;

			ShowTXT.text =   LinkURLs[temp];

			temp++;
			if (temp > LinkURLs.Length-1)
				temp = 0;

			yield return new WaitForSeconds (NextTime);
		}
	}

	// Read news
	IEnumerator ReadLinks()
	{
		// Read Link URLs
		www = new WWW (newsURL);

		yield return www;

		string	longStringFromFile = www.text;
		List<string> lines = new List<string>(
			longStringFromFile
			.Split(new string[] { "\r","\n" },
				StringSplitOptions.RemoveEmptyEntries) );

		// remove comment lines...
		lines = lines
			.Where(line => !(line.StartsWith("//")
				|| line.StartsWith("#")))
			.ToList();

		LinkURLs = new string[lines.Count];

		for(int c = 0;c<lines.Count;c++)
			LinkURLs [c] = lines [c];

		www.Dispose ();
		www = null;

		target.SetActive(true);
		StartCoroutine (Show ());

	}

	//  Read news links
	IEnumerator ReadLinksUrls()
	{
		// Read Link URLs
		wwwURLs = new WWW (linksURL);

		yield return wwwURLs;

		string	longStringFromFile = wwwURLs.text;
		List<string> lines = new List<string>(
			longStringFromFile
			.Split(new string[] { "\r","\n" },
				StringSplitOptions.RemoveEmptyEntries) );

		// remove comment lines...
		lines = lines
			.Where(line => !(line.StartsWith("//")
				|| line.StartsWith("#")))
			.ToList();

		LinkURLsView = new string[lines.Count];

		for(int c = 0;c<lines.Count;c++)
			LinkURLsView [c] = lines [c];

		wwwURLs.Dispose ();
		wwwURLs = null;

	}


}
