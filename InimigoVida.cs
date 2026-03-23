using UnityEngine;

public class InimigoVida : MonoBehaviour
{
    public int vida = 2;

    public void TomarDano(int dano)
    {
        vida -= dano;

        Debug.Log("INIMIGO TOMOU DANO");

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}