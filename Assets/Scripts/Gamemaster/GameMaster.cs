using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public int coins;

    public Text coinText;

    private void Update()
    {
        coinText.text = ("Coins: " + coins);
    }


}
