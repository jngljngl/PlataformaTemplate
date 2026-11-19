using UnityEngine;

public class AnimacaoPlayer : MonoBehaviour
{
    //variaveis   
    [SerializeField] private Animator animacao;
    [SerializeField] private SpriteRenderer sprite;



    public void AnimacaoHit() {

        animacao.SetTrigger("Hit");
    }

    public void AnimacaoPular(float velocidadeY, bool noChao) {

        animacao.SetFloat("Y", velocidadeY);
        animacao.SetBool("NoChao", noChao);

    }

    public void AnimacaoParado(float direcao)
    {
        animacao.SetBool("NoChao", true);
    }
    
    public void AnimacaoCorrer(float direcao) {

        // inverte se estiver pra esquerda
        if (direcao < 0) {
            sprite.flipX = true;
        }
        // desinverte para direita
        if (direcao > 0) {
            sprite.flipX = false;
        }
        
        // retira o sinal da direção
        float direcaoAbs = Mathf.Abs(direcao);
        
        // passa a direção para o animator
        animacao.SetFloat("X", direcaoAbs);
    }

}
