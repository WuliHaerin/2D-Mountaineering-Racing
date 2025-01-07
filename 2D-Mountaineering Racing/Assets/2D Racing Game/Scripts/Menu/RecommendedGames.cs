// Terms of the use :
// * You can only use this script to offer platers for other or your games
// * You cannot offer anythings else like sexual contents or other things (just content for children)

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;
public class RecommendedGames : MonoBehaviour {

	WWW www;
	[Space(3)]
	// Button sprites
	public Image[] targetSprite;

	// Games icon urls
	public string[] ImagesURL;
	// Internal
	Texture2D[] textures;

	string[] LinksURL;

	// Game links file with https, splited with lines     
	public string gameLinks;

	// Activated when player is online    (Ad border    )
	public GameObject Loading;

	void Start()
	{
		
		textures = new Texture2D[targetSprite.Length];

		LinksURL = new string[targetSprite.Length];

		for(int a = 0;a<textures.Length;a++)
			textures[a] =  new Texture2D(4, 4, TextureFormat.DXT1, false);

		Reload ();

	}

	public void Reload()
	{
		StopCoroutine (ReadLinks());
		StopCoroutine (ReadImages ());
		Loading.SetActive (true);

		StartCoroutine (ReadLinks ());
	}
	public void LoadAd(int id)
	{
		if(LinksURL [id].Contains("https"))
			Application.OpenURL (LinksURL [id]);
		else
			GameObject.FindObjectOfType<MenuTools>().OpenGooglePlay(LinksURL [id]);
		
	}

	int loaded;
	IEnumerator ReadImages()
	{
		for(int b = 0;b<ImagesURL.Length;b++)
		{
			if (b >= loaded) {
				www = new WWW (ImagesURL [b]);

				yield return www;
				www.LoadImageIntoTexture (textures [b]);
				targetSprite [b].sprite = Sprite.Create (textures [b], new Rect (0, 0, textures [b].width, textures [b].height), new Vector2 (0, 0), 100.0f);
				targetSprite [b].gameObject.SetActive (true);
				www.Dispose ();
				www = null;
				loaded++;
			}

		}
		Loading.SetActive (false);
	}
	IEnumerator ReadLinks()
	{
		// Read Link URLs
		www = new WWW (gameLinks);

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

		for(int c = 0;c<lines.Count;c++)
			LinksURL [c] = lines [c];

		www.Dispose ();
		www = null;

		StartCoroutine(ReadImages ());
	}
}
	   