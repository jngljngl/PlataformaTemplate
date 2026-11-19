using UnityEngine;

public class SistemaDeVida : MonoBehaviour
{

    // VARIÁVEIS
    private int vidaAtual;
    [SerializeField] private int vidaMaxima;
    [SerializeField] private ControlesPlayer controles;
  
    
    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
      if (controles.btnTeste) {
            DiminuirVida(20);
            
      }
    }

    // modificador / retorno / nome (parametro)
    private void AumentarVida(int boost)
    {
        vidaAtual = vidaAtual + boost;
        
    }

    public void DiminuirVida(int dano)
    {
        vidaAtual = vidaAtual - dano;
        Debug.Log("Vida atual: " + vidaAtual);
    }

    private void Morrer()
    {
        // se vida chegar a zero
        if (vidaAtual <= 0)
        {
            Destroy(gameObject);
        }

        // tela de morte

        // desativar controles

        // animacao de morte

    }






}
