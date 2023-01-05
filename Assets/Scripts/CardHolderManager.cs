using UnityEngine;
using TMPro;

public class CardHolderManager : MonoBehaviour
{
    [Header("Card Holder Parameters")]
    [SerializeField] private Transform cardHolderPosition;
    [SerializeField] private GameObject card;
    [SerializeField] private Card[] cardSo;
    private int _cardsAmmount;

    [Header("Card Parameters")]
    [SerializeField] private GameObject[] plantedCards;
    private int _cost;
    private Sprite _icon;

    void Start()
    {
        _cardsAmmount = cardSo.Length;
        plantedCards = new GameObject[_cardsAmmount];

        for (int i = 0; i < _cardsAmmount; i++)
            CreateCard(i);
    }

    private void CreateCard(int i)
    {
        var card = Instantiate(this.card, cardHolderPosition);
        CardManager cardManager = card.GetComponent<CardManager>();

        cardManager.CardSO = cardSo[i];

        plantedCards[i] = card;

        _icon = cardSo[i].icon;
        _cost = cardSo[i].cost;

        card.GetComponentInChildren<SpriteRenderer>().sprite = _icon;
        card.GetComponentInChildren<TMP_Text>().text = _cost.ToString();
    }
}

