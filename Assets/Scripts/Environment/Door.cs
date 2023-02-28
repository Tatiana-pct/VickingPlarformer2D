using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject _victoryScreen;

    private Animator _animator;

    private void Awake()
    {
        // On r�cup�re la r�f�rence au composant Animator
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le joueur touche la porte
        if (collision.CompareTag("Player"))
        {
            // On lance l'animation d'ouverture de porte
            _animator.SetTrigger("Open");
        }
    }

    // Cette m�thode est appel�e par l'AnimationEvent de l'animation d'ouverture de porte
    private void ShowVictoryScreen()
    {
        // On met le jeu en pause
        Time.timeScale = 0f;
        // On active l'�cran de victoire dans le Canvas
        _victoryScreen.SetActive(true);
    }
}
