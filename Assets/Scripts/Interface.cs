using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    //Referencias

    [SerializeField] private SistemaDeVida sistemaDeVida;
    [SerializeField] private ControlesPlayer controlesPlayer;

    [SerializeField] private Slider vidaSlider;
    [SerializeField] private TextMeshProUGUI pontosTxt;
    [SerializeField] private TextMeshProUGUI timerTxt;

    //Variaveis
    private float timer;

    //Metodos

    private void Update()
    {
        ExibirPontos();

        timer = timer + Time.deltaTime;
        ExibirTimer();
    }


    private void ExibirVida()
    {

    }

    private void ExibirPontos()
    {
        pontosTxt.text = ("Pontos: " + controlesPlayer.pontos.ToString());
    }

    private void ExibirTimer()
    {
        float tempoArredondado = Mathf.Round(timer * 100f) / 100f;
        timerTxt.text = (tempoArredondado.ToString());
    }
}
