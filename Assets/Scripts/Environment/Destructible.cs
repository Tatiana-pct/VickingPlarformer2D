using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

    [SerializeField] private Sprite[] _sprites;             // Tableau contenant les differents sprites du pilier

    private SpriteRenderer _renderer;

    private int _currentSpriteIndex = 0;                    // Index actuel du tableau

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // On affiche le sprite actuel
        DisplayCurrentSprite();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si le joueur collisionne l'objet
        if (collision.collider.CompareTag("Player"))
        {
            Hit();
        }
    }

    private void Hit()
    {
        // On incrémente l'index du sprite actuel
        _currentSpriteIndex++;

        // Si cet index dépasse le nombre de sprite dans le tableau
        if (_currentSpriteIndex == _sprites.Length)
        {
            // On détruit l'objet
            Destroy(gameObject);
        }
        // Sinon
        else
        {
            // On affiche le sprite actuel
            DisplayCurrentSprite();
        }
    }

    private void DisplayCurrentSprite()
    {
        // On affiche le sprite actuel
        _renderer.sprite = _sprites[_currentSpriteIndex];
    }
}
