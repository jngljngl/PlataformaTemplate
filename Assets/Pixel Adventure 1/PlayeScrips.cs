using UnityEngine;

public class PlayeScrips : MonoBehaviour
{
    [SerializeField] GameObject objKey;
    private object parent;

    void Start()
    {
        UnityEngine.Debug.Log(parent);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UnityEngine.Debug.Log("Estou vendo a Chave.");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        UnityEngine.Debug.Log("Não estou vendo a Chave.");
    }
}
