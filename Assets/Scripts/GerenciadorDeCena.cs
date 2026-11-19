using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorDeCena : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CarregarCena()
    {
        SceneManager.LoadScene("Fase01");
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}

  
