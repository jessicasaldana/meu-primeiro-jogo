using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform point; // Transform da a posi��o do point

    void Start()
    {
        // Encontra a localiza��o do Player e recebe a posi��o do point
        FindObjectOfType<Player>().transform.position = point.position;
    }
}
