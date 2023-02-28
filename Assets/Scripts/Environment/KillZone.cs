using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private Transform _respawnLocation;

    // Quand le joueur entre dans la zone de mort on le t�l�porte au point de r�apparition
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le joueur traverse le collider
        if (collision.CompareTag("Player"))
        {
            // On replace le joueur � la position de l'objet RespawnLocation
            collision.transform.position = _respawnLocation.position;
        }
    }
}
