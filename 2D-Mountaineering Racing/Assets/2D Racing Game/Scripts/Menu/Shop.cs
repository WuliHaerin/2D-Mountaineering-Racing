using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{ 
    public void AddCoins(int value)
    {
        int coin = PlayerPrefs.GetInt("Coins") + value;
        PlayerPrefs.SetInt("Coins", coin);
        PlayerPrefs.Save();
    }
    public void ClickBtn(int value)
    {
        AdMgr.ShowVideoAd("lnbppmnih472qsl0qg",
            (bol) => {
                if (bol)
                {
                    AddCoins(value);
                    MenuTools.instance.SetFalse(gameObject);

                    AdMgr.clickid = "";
                    AdMgr.getClickid();
                    AdMgr.apiSend("game_addiction", AdMgr.clickid);
                    AdMgr.apiSend("lt_roi", AdMgr.clickid);

                }
                else
                {
                    StarkSDKSpace.AndroidUIManager.ShowToast("�ۿ�������Ƶ���ܻ�ȡ����Ŷ��");
                }
            },
            (it, str) => {
                Debug.LogError("Error->" + str);
                //AndroidUIManager.ShowToast("�������쳣�������¿���棡");
            });

    }

}
