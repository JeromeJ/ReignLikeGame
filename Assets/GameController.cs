using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region Public Members

    public Sprite[] m_sprites;

    public Image m_challengeCharacter;

    #endregion

    #region Public void

    public void PickAnswer(bool _answer)
    {
        // Do stuff.

        Debug.Log("Picked " + _answer);

        LoadNext();
    }

    #endregion

    #region System

    private void Awake ()
    {
        LoadNext();
    }

    #endregion

    #region Class Methods

    private void LoadNext()
    {
        System.Random r = new System.Random();


        Sprite newSprite;

        do
        {
            // Ensure you don't roll the same Sprite twice in a row.
            newSprite = m_sprites[r.Next(0, m_sprites.Length)];
        }
        while (m_challengeCharacter.sprite == newSprite);

        m_challengeCharacter.sprite = newSprite;
    }

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    #endregion
}
