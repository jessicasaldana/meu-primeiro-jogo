using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform point; // Transform da a posição do point

    void Start()
    {
        // Encontra a localização do Player e recebe a posição do point
        FindObjectOfType<Player>().transform.position = point.position;
    }
}
