using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region Public Members

    public Sprite[] m_sprites;

    public string[] m_challenges = { "Lorem Ipsum", "Foo bar", "123456" };

    public Image m_challengeCharacter;
    public Text m_challengeText;

    // TODO: Use a singleton
    public IndicatorManager m_indicatorManager;

    public Image[] m_indicators;

    #endregion

    #region Public void

    // TODO: Make different "scritps" to edit percents / text / image (for later testing purposes)

    public void PickAnswer(bool _answer)
    {
        System.Random r = new System.Random();

        Image selectedIndicator = m_indicators[r.Next(m_indicators.Length)];

        selectedIndicator.fillAmount = selectedIndicator.fillAmount + 0.2f * (r.Next(2) == 1 ? 1 : -1);

        Debug.Log("Picked " + _answer + " => " + selectedIndicator + " " + selectedIndicator.fillAmount);

        LoadNext();
    }

    #endregion

    #region System

    private void Awake ()
    {
        m_indicators = m_indicatorManager.m_indicators;

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
            newSprite = m_sprites[r.Next(m_sprites.Length)];
        }
        while (m_challengeCharacter.sprite == newSprite);

        m_challengeCharacter.sprite = newSprite;

        m_challengeText.text = m_challenges[r.Next(m_challenges.Length)];
    }

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    #endregion
}
