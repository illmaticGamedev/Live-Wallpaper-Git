using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CryptoToUSD : APIFeature
{
    public enum cryptoCurrency { Btc, Eth, Ada, Doge, Xrp}
    public cryptoCurrency myCryptoCurrency;
    
    
    [SerializeField] private TMP_Text cryptoUIText;
    public override void PerformMechanic()
    {
        if (Response == null) return;
        
        cryptoToUSDHelper cryptoToUSD = JsonUtility.FromJson<cryptoToUSDHelper>(Response);
        cryptoUIText.text = myCryptoCurrency + "  -  $" + cryptoToUSD.lprice;
    }
    private void OnValidate()
    {
        RefreshAPIURL();
    }
    void RefreshAPIURL()
    {
        switch (myCryptoCurrency)
        {
            case cryptoCurrency.Btc:
                apiURL = GlobalConstants.BTC_TO_USD_URL;
                break;
            case cryptoCurrency.Eth:
                apiURL = GlobalConstants.ETH_TO_USD_URL;
                break;
            case cryptoCurrency.Ada:
                apiURL = GlobalConstants.ADA_TO_USD_URL;
                break;
            case cryptoCurrency.Doge:
                apiURL = GlobalConstants.DOGE_TO_USD_URL;
                break;
            case cryptoCurrency.Xrp:
                apiURL = GlobalConstants.XRP_TO_USD_URL;
                break;
        }
    }

    public struct cryptoToUSDHelper
    {
        public string lprice;
    }
}
