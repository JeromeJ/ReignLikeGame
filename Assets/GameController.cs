using System;
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

    public System.Random m_r;

    #endregion

    #region Public void

    // TODO: Make different "scritps" to edit percents / text / image (for later testing purposes)

    public void PickAnswer(bool _answer)
    {
        Image selectedIndicator = m_indicators[m_r.Next(m_indicators.Length)];

        selectedIndicator.fillAmount = selectedIndicator.fillAmount + 0.2f * (m_r.Next(2) == 1 ? 1 : -1);

        Debug.Log("Picked " + _answer + " => " + selectedIndicator + " " + selectedIndicator.fillAmount);

        LoadNext();
    }

    #endregion

    #region System

    private void Awake ()
    {
        m_r = new System.Random();

        m_indicators = m_indicatorManager.m_indicators;

        LoadNext();
    }

    #endregion

    #region Class Methods

    private void LoadNext()
    {
        Sprite newSprite;

        // Ensure you don't roll the same Sprite twice in a row.
        do newSprite = GetRandom(m_sprites);
        while (m_challengeCharacter.sprite == newSprite);

        SetSprite(newSprite);

        SetChallengeText(GetRandom(m_challenges));
    }

    private void SetChallengeText(string _challenge)
    {
        m_challengeText.text = _challenge;
    }

    private void SetSprite(Sprite _sprite)
    {
        m_challengeCharacter.sprite = _sprite;
    }

    #endregion

    #region Tools Debug and Utility

    private T GetRandom<T>(T[] _source, System.Random _r = null)
    {
        if (_r == null)
            _r = m_r;

        return _source[_r.Next(_source.Length)];
    }

    #endregion

    #region Private and Protected Members

    #endregion
}
