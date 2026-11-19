using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlesPlayer : MonoBehaviour
{
    // variaveis
    [Header("Variaveis")]
    public float velocidade;
    public float forcaPulo;
    public int pontos;
    [SerializeField] int forcaKnockBack = 10;

    //movimento
    [SerializeField] int maximoPulos = 2;
    [SerializeField] bool noChao = false;

    //componentes
    [SerializeField] Rigidbody2D playerBody;
    [SerializeField] CircleCollider2D checkChao;
    [SerializeField] AnimacaoPlayer animacaoPlayer;
    [SerializeField] SistemaDeVida sistemaDeVida;

    //Audio
    public Array[] audioList;
    [SerializeField] AudioSource aSource;

    //controles
    private MapaDeControles controles; //importante
    public bool btnTeste;
    private Vector2 moveDir;
    private bool btnPular;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        checkChao = GetComponent<CircleCollider2D>();
    }

    private void Awake()
    {
        controles = new MapaDeControles();
    }

    private void OnEnable()
    {
        controles.Enable();
    }

    private void OnDisable()
    {
        controles.Disable();
    }

    private void Update()
    {
        ProcessarInputs();

        Mover();

        Pular();

        
    }

    private void ProcessarInputs()
    {
        btnTeste = controles.Player.Teste.WasPressedThisFrame();
        moveDir = controles.Player.Mover.ReadValue<Vector2>();
        btnPular = controles.Player.Pular.WasPressedThisFrame();

    }
    public void Mover()
    {
        playerBody.linearVelocityX = moveDir.x * velocidade;

        animacaoPlayer.AnimacaoCorrer(moveDir.x);
        

    }

    public void Pular()
    {
        animacaoPlayer.AnimacaoPular(playerBody.linearVelocityY, noChao);
        
        if (btnPular && noChao)
        {
            playerBody.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
        }

    }

    public void Knockback(Vector2 posicaoArmadilha)
    {
        // pega posicao do jogador
        Vector2 posicaoJogador = transform.position;

        // calcula a direcao do knockback
        Vector2 direcao = ((Vector2)posicaoJogador - posicaoArmadilha).normalized;

        //multiplica pela força do knockback
        Vector2 forca = direcao * forcaKnockBack;

        // zera velocidade para todo knockback ter mesma força
        playerBody.linearVelocity = Vector2.zero;

        //playerBody.AddForce(new Vector2(0, 0.2f), ForceMode2D.Impulse);
        playerBody.AddForce(forca, ForceMode2D.Impulse);


        Debug.Log(playerBody.linearVelocityX);

       

    }

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // checa se colisor n está vazio
        if (collision == null) { return; }
        // checa se colisor é o do chão
        noChao = (collision.gameObject.layer == 3);

        // checar se é um ponto
        if (collision.gameObject.CompareTag("ponto"))
        { 
        //adicionar na pontuação
        pontos = pontos + 1;
        Debug.Log(pontos);
        // apagar o objeto
        Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("finalFase"))
        { 
            SceneManager.LoadScene("Fase01");
        }
        
        if (collision.gameObject.CompareTag("armadilha"))
        {
           animacaoPlayer.AnimacaoHit();
           
            Vector2 posicaoArmadilha = collision.gameObject.transform.position;
            
            Knockback( posicaoArmadilha );
            sistemaDeVida.DiminuirVida(20);




            //


        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        noChao = !(collision.gameObject.layer == 3);
    }

    void JumpDoubleJump()
    {
        if (maximoPulos < 2 && (noChao || !noChao))
        {
            playerBody.linearVelocityY = forcaPulo;
            maximoPulos++;
        }
    }

    void PlayClip(AudioClip clip, bool doLoop = false, bool doPlay = false)
    {
        aSource.loop = doLoop;
        aSource.clip = clip;
        if (doPlay)
        {
            aSource.Play();
        }
    }
    void StopClip()
    {
        if (aSource.isPlaying)
        {
            aSource.Stop();
        }
    }
}
