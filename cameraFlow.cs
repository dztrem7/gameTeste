using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;        // arraste o player aqui
    public Vector3 offset;          // distância da câmera em relação ao player
    public float smoothSpeed = 0.125f; // suavização do movimento


// testandooo
    void LateUpdate()
    {
        if (player == null) return;

        // posição desejada
        Vector3 desiredPosition = player.position + offset;

        // suaviza o movimento
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // aplica a posição
        transform.position = smoothedPosition;
    }
}