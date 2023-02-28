using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    // Référence au ScriptableObject de score
    [SerializeField] private IntVariable _score;
    // Référence à l'élément Text du canvas
    [SerializeField] private TMP_Text _scoreLabel;

    private void Awake()
    {
        //On réinitialise le score au début du niveau
        _score.Value = 0;
    }

    private void Update()
    {
        // On affiche le score actuel
        _scoreLabel.text = "Score : " + _score.Value;
    }

    // Cette méthode est apellée depuis l'UnityEvent du bouton du canvas
    public void LoadNextLevel()
    {
        // On désactive la pause du jeu
        Time.timeScale = 1f;
        // Et on charge le niveau suivant
        SceneManager.LoadScene("Level2");
    }
}
