using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    [SerializeField] private float _curentExperience = 0f;
    [SerializeField] private float _nextLevelExperience = 5f;
    private int _level;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Image _experienceScale;
    [SerializeField] private EffectsManager _effectsManager;
    [SerializeField] private AnimationCurve _experienceCurve;

    private void Awake()
    {
        DisplayExperience();
        _nextLevelExperience = _experienceCurve.Evaluate(_level);
;    }

    public void AddExperience(int value)
    {
        _curentExperience += value;
        if (_curentExperience >= _nextLevelExperience)
        {
            UpLevel();
        }
        DisplayExperience();

    }

    private void UpLevel()
    {
        _level++;
        _levelText.text = _level.ToString();
        _curentExperience = 0;
        _effectsManager.ShowCards();
        _nextLevelExperience = _experienceCurve.Evaluate(_level);
    }

    private void DisplayExperience()
    {
        _experienceScale.fillAmount = _curentExperience / _nextLevelExperience;
    }
}
