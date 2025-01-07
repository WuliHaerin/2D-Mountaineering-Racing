using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{ 
    public void AddCoins(int value)
    {
        int coin = PlayerPrefs.GetInt("Coins") + value;
        PlayerPrefs.SetInt("Coins", coin);
    }
    public void ClickBtn(int value)
    {
        AdMgr.ShowVideoAd("192if3b93qo6991ed0",
            (bol) => {
                if (bol)
                {
                    AddCoins(value);
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

}
