using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Transform _respawnLocation;

    Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    // Quand le joueur entre dans la zone de mort on le téléporte au point de réapparition
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le joueur traverse le collider
        if (collision.CompareTag("Player"))
        {
            // On déplace le RespawnPoint à la position du checkpoint
            _respawnLocation.position = _transform.position;
        }
    }
}
