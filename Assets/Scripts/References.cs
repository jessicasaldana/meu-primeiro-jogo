using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class References : MonoBehaviour
{
    public Player player;
    [Header("UI")]
    public TextMeshProUGUI appleText; //referencia ao texto da qtd de maças
    public TextMeshProUGUI lifeText; //texto qtd de vidas
    public GameObject restart; //objeto do game over

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        player.appleText = appleText;
        player.lifeText = lifeText;
        player.restart = restart;
    }

    void Start()
    {
        appleText.text = player.apple.ToString();
        lifeText.text = player.life.ToString();
    }

    public void Restart()
    {
        player.RestartGame();
    }
}
