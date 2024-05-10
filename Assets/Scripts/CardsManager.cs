using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    [SerializeField] private GameObject _cardsPparent;
    [SerializeField] private Card[] _effectCards;
    [SerializeField] private EffectsManager _effectsManager;

    private void Awake()
    {
        foreach (var card in _effectCards)
        {
            card.Init(_effectsManager, this);
        }
    }

    public void ShowCards(List<Effect> effects)
    {
        _cardsPparent.SetActive(true);
        for (int i = 0; i < effects.Count; i++)
        {
            _effectCards[i].Show(effects[i]);
        }
    }

    public void Hide()
    {
        _cardsPparent.SetActive(false);
    }
}
