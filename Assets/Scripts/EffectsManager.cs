using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    [SerializeField] private List<ContinousEffect> _continousEffects = new List<ContinousEffect>();
    [SerializeField] private List<OneTimeEffect> _oneTimeEffects = new List<OneTimeEffect>();

    [SerializeField] private List<ContinousEffect> _continousEffectsApplied = new List<ContinousEffect>();
    [SerializeField] private List<OneTimeEffect> _oneTimeEffectsApplied = new List<OneTimeEffect>();
    [SerializeField] private CardsManager _cardsManager;

    private void Awake()
    {
        for (int i = 0; i < _continousEffects.Count; i++)
        {
            _continousEffects[i] = Instantiate(_continousEffects[i]);
        }
        for (int i = 0; i < _oneTimeEffects.Count; i++)
        {
            _oneTimeEffects[i] = Instantiate(_oneTimeEffects[i]);
        }
    }

    [ContextMenu("ShowCards")]
    public void ShowCards()
    {
        List<Effect> effectsToShow = new List<Effect>();
        foreach (var appliedContEffect in _continousEffectsApplied)
        {
            if (appliedContEffect.Level < 10)
            {
                effectsToShow.Add(appliedContEffect);
            }
        }
        foreach (var effect in _oneTimeEffectsApplied)
        {
            if (effect.Level < 10)
            {
                effectsToShow.Add(effect);
            }
        }

        if (_continousEffectsApplied.Count < 4)
        {
            effectsToShow.AddRange(_continousEffects);
        }

        if (_oneTimeEffectsApplied.Count < 4)
        {
            effectsToShow.AddRange(_oneTimeEffects);
        }

        int numberOfCardsToShow = Mathf.Min(effectsToShow.Count, 3);

        int[] randomIndexes = RandomSort(effectsToShow.Count, numberOfCardsToShow);
        List<Effect> effectsForCards = new List<Effect>();

        for (int i = 0; i < randomIndexes.Length; i++)
        {
            int index = randomIndexes[i];
            effectsForCards.Add(effectsToShow[index]);
        }
        _cardsManager.ShowCards(effectsForCards);
    }

    private int[] RandomSort(int length, int numberOfCardsToShow)
    {
        int[] array = new int[length];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }

        for (int i = 0; i < array.Length; i++)
        {
            int oldValue = array[i];
            int newIndex = UnityEngine.Random.Range(0, array.Length);
            array[i] = array[newIndex];
            array[newIndex] = oldValue;
        }

        int[] result = new int[numberOfCardsToShow];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = array[i];
        }
        return result;

    }

    public void AddEffect(Effect effect)
    {
        if (effect is ContinousEffect c_effect)
        {
            if (!_continousEffectsApplied.Contains(c_effect))
            {
                _continousEffectsApplied.Add(c_effect);
                _continousEffects.Remove(c_effect);
            }
        }
        else if (effect is OneTimeEffect o_Effect)
        {
            if (!_oneTimeEffectsApplied.Contains(o_Effect))
            {
                _oneTimeEffectsApplied.Add(o_Effect);
                _oneTimeEffects.Remove(o_Effect);
            }
        }
        effect.Activate();
    }
}
