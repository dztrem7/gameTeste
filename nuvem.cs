using UnityEngine;

public class nuvemScript : MonoBehaviour
{
    public float vel = 0.1f;
    public Renderer quad;

    public Transform cameraTransform; // câmera que o player segue

    void Start()
    {
        // começa do zero
        quad.material.mainTextureOffset = Vector2.zero;
    }

    void Update()
    {
        // FAZ A NUVEM ACOMPANHAR A CAMERA (INFINITO)
        transform.position = new Vector3(
            cameraTransform.position.x,
            transform.position.y,
            transform.position.z
        );

        // SCROLL DA TEXTURA
        Vector2 offset = quad.material.mainTextureOffset;
        offset.x += vel * Time.deltaTime;
        quad.material.mainTextureOffset = offset;
    }
}