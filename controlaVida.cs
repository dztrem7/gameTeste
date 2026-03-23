using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // ⭐ IMPORTANTE

public class Vida : MonoBehaviour
{

    // teste
    // opa!
    public GameObject gameOverPanel;
    public Image[] coracoes;
    public AudioClip somDano;
    public AudioClip somMorte;
    public AudioSource audioSource;

    private float vidaAtual;
    private Animator anim;

    public bool isAlive = true;

    void Start()
    {
        vidaAtual = coracoes.Length * 2;
        anim = GetComponent<Animator>();
        AtualizarUI();
    }

    public void PerderVida()
    {
        if (!isAlive) return;

        if (vidaAtual > 0)
        {
            vidaAtual -= 1;
            AtualizarUI();

            if (audioSource != null && somDano != null)
                audioSource.PlayOneShot(somDano);
        }

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void AtualizarUI()
    {
        for (int i = 0; i < coracoes.Length; i++)
        {
            if (vidaAtual >= (i + 1) * 2)
                coracoes[i].fillAmount = 1f;
            else if (vidaAtual == (i * 2) + 1)
                coracoes[i].fillAmount = 0.5f;
            else
                coracoes[i].fillAmount = 0f;
        }
    }

    void Morrer()
    {
        if (!isAlive) return;

        isAlive = false;

        anim.SetTrigger("morte");

        if (audioSource != null && somMorte != null)
            audioSource.PlayOneShot(somMorte);

        GetComponent<PlayerMovement>().enabled = false;

        Invoke("MostrarGameOver", 1.5f); // ⭐ espera animação
    }

    void MostrarGameOver()
{
    gameOverPanel.SetActive(true);
}

public void ReiniciarJogo()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

public void IrParaMenu()
{
    Debug.Log("Menu ainda não existe");
}
}