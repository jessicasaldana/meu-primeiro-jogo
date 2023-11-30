using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Trophy : MonoBehaviour
{
    public GameObject victory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            victory.SetActive(true);//chama o fim do jogo
            Time.timeScale = 0; //pausa o jogo
        }
    }
}
