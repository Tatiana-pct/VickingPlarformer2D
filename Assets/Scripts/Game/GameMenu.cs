using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    // R�f�rence au ScriptableObject de score
    [SerializeField] private IntVariable _score;
    // R�f�rence � l'�l�ment Text du canvas
    [SerializeField] private TMP_Text _scoreLabel;

    private void Awake()
    {
        //On r�initialise le score au d�but du niveau
        _score.Value = 0;
    }

    private void Update()
    {
        // On affiche le score actuel
        _scoreLabel.text = "Score : " + _score.Value;
    }

    // Cette m�thode est apell�e depuis l'UnityEvent du bouton du canvas
    public void LoadNextLevel()
    {
        // On d�sactive la pause du jeu
        Time.timeScale = 1f;
        // Et on charge le niveau suivant
        SceneManager.LoadScene("Level2");
    }
}
