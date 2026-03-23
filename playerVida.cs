using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            Vida vida = FindFirstObjectByType<Vida>();
            if (vida != null)
            {
                vida.PerderVida();
            }
        }
    }
}