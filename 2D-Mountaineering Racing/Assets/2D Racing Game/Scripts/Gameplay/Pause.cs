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
        AdMgr.ShowVideoAd("3j55ce6l837ihnng4l",
            (bol) => {
                if (bol)
                {

                    Time.timeScale = 1f;
                    PauseMen.SetActive(false);

                    AdMgr.clickid = "";
                    AdMgr.getClickid();
                    AdMgr.apiSend("game_addiction", AdMgr.clickid);
                    AdMgr.apiSend("lt_roi", AdMgr.clickid);

                }
                else
                {
                    StarkSDKSpace.AndroidUIManager.ShowToast("观看完整视频才能获取奖励哦！");
                }
            },
            (it, str) => {
                Debug.LogError("Error->" + str);
                //AndroidUIManager.ShowToast("广告加载异常，请重新看广告！");
            });

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
