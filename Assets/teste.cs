using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
public class teste : MonoBehaviour //Teste é um placeholder, apenas
{
    private Rigidbody2D rgBd2D;
    public Transform posPes;
    public LayerMask camadaDoChao;

    public float velocidade = 5.0f;

    void Start()
    {
        rgBd2D = GetComponent<Rigidbody2D>();
        rgBd2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        float entradaHorizontal = Input.GetAxis("Horizontal");

        rgBd2D.linearVelocity = new Vector2(entradaHorizontal * velocidade, rgBd2D.linearVelocity.y);

        Collider2D colisaoPes = Physics2D.OverlapCircle(
            posPes.position,
            0.15f,
            camadaDoChao
        );

        bool puloPossivel = colisaoPes != null;
         
        if (Input.GetKeyDown(KeyCode.Space) && puloPossivel)
        {
            rgBd2D.linearVelocityY = 5.0f;
        }

    }

}