using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private Transform _respawnLocation;

    // Quand le joueur entre dans la zone de mort on le téléporte au point de réapparition
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le joueur traverse le collider
        if (collision.CompareTag("Player"))
        {
            // On replace le joueur à la position de l'objet RespawnLocation
            collision.transform.position = _respawnLocation.position;
        }
    }
}
