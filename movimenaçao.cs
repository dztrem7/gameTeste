using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float raioAtaque = 1f;
    public Animator animator;
    public float moveSpeed = 5f;

    private Vector3 originalScale;
    private bool facingRight = true;
    private float horizontalAnim;
    bool noChao;

    // ATAQUE
    public Transform pontoAtaque;
    public int danoAtaque = 1;

    public LayerMask layerInimigo;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
            horizontalAnim = horizontalInput;
        else
            horizontalAnim = 0;

        animator.SetFloat("horizontalAnim", horizontalAnim);

        transform.Translate(Vector2.right * horizontalInput * moveSpeed * Time.deltaTime);

        Jump();
        Atacar();
        Flip(horizontalInput);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            transform.Translate(Vector2.up * 1.5f);
            noChao = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("chao"))
            noChao = true;
    }

    void Atacar()
    {

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("atacar");

            Collider2D[] inimigos = Physics2D.OverlapCircleAll(
    pontoAtaque.position,
    raioAtaque
);

            Debug.Log("Detectados: " + inimigos.Length);


            foreach (Collider2D inimigo in inimigos)
            {
                if (inimigo.CompareTag("inimigo"))
                {
                    InimigoVida vida = inimigo.GetComponent<InimigoVida>();

                    if (vida != null)
                    {
                        vida.TomarDano(danoAtaque);
                    }
                }
            }
        }

    }

    void Flip(float horizontalInput)
    {
        if (horizontalInput < 0 && facingRight)
        {
            facingRight = false;
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        }
        else if (horizontalInput > 0 && !facingRight)
        {
            facingRight = true;
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (pontoAtaque == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pontoAtaque.position, raioAtaque);
    }
}