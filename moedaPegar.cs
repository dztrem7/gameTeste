using UnityEngine;

public class CoinAudio : MonoBehaviour
{
    public AudioClip coinSound;          // áudio da moeda
    public float volume = 1f;            // volume do som
    private CoinText coinText;           // referência ao script que atualiza o texto

    private void Start()
    {
        // pega a primeira instância do CoinText na cena
        coinText = FindFirstObjectByType<CoinText>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            // toca o som na posição da moeda
            if (coinSound != null)
            {
                AudioSource.PlayClipAtPoint(coinSound, transform.position, volume);
            }

            // adiciona 1 ao contador de moedas
            if (coinText != null)
            {
                coinText.AddMoeda();
            }

            // destrói a moeda
            Destroy(gameObject);
        }
    }
}