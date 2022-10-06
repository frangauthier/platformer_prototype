using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CoinText;
    static int coinCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text = CoinCounter.coinCount.ToString();
    }

    public static void AddCoin(int amount)
    {
        coinCount += amount;
    }
}
