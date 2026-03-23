using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{
    public TextMeshProUGUI texto;
    int moedas = 0;

    public void AddMoeda()
    {
        moedas++;
        texto.text = "" + moedas;
    }
}