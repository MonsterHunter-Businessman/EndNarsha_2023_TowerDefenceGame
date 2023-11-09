using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class DeckManager : MonoBehaviour
{
    public static DeckManager Instance = null;
    public Deck[] deckList;
    public Card card;
    public Cards cards;
    public Cards[] cardList;
    public Player[] userCardList;

    //ethan
    public GameObject cardObj;

    [SerializeField] private CardData[] cardData;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("DontDestroyOnLoad");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Destroy");
        }
    }

    private void Start()
    {
        deckList = new Deck[5];
        cardList = new Cards[5];
        userCardList = new Player[5];

        Deck[] decks = new Deck[5];
        for (int i = 0; i < 5; i++)
        {
            decks[i] = new Deck();
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "OneStage" || SceneManager.GetActiveScene().name == "TwoStage" || SceneManager.GetActiveScene().name == "ThreeStage" || SceneManager.GetActiveScene().name == "FourStage" || SceneManager.GetActiveScene().name == "FiveStage")
        {
            LoadCardInfo();
        }
    }

    public void LoadCardInfo()
    {
      
        cardObj = GameObject.FindWithTag("cardObj");
        card = FindAnyObjectByType<Card>();
        cards = FindAnyObjectByType<Cards>();
        for (int i = 0; i < deckList.Length; i++)
        {
            if (deckList[i] == null)
            {
                userCardList[i] = null;
                userCardList[i] = cardObj.transform.GetChild(i).GetComponent<Knight>();
                cardList[i] = null;
                cardList[i] = cardObj.transform.GetChild(i).GetComponent<Cards>();
                deckList[i] = null;
                deckList[i] = cardObj.transform.GetChild(i).GetComponent<Deck>();
            }
            deckList[i].cardName = cardData[i].cardName;
            deckList[i].cardDamage = cardData[i].cardDamage;
            deckList[i].cardDescription = cardData[i].cardDescription;
            deckList[i].cardSprite = cardData[i].cardSprite;
            deckList[i].cardIndex = cardData[i].cardIndex;
            deckList[i].cardHp = cardData[i].maxHp;
            deckList[i].fireRange = cardData[i].fireRanage;
            deckList[i].fireTime = cardData[i].fireTime;

            cardList[i].cardNametxt = deckList[i].cardName;
            cardList[i].maxHp = deckList[i].cardHp;
            cardList[i].cardDmg = deckList[i].cardDamage;
            cardList[i].cardInfo = deckList[i].cardDescription;
            cardList[i].cardSprite = deckList[i].cardSprite;

/*            userCardList[i].Deamge = deckList[i].cardDamage;
            userCardList[i].FireTime = deckList[i].fireTime;
            userCardList[i].MaxHp = deckList[i].cardHp;
            userCardList[i].FireRange = deckList[i].fireRange;*/
        }
    }

    public void SaveCardData(Deck deck,int index)
    {
        cardData[index].cardName = deck.cardName;
        cardData[index].cardDamage = deck.cardDamage;
        cardData[index].cardDescription = deck.cardDescription;
        cardData[index].cardSprite = deck.cardSprite;
        cardData[index].cardIndex = deck.cardIndex;
        cardData[index].maxHp = deck.cardHp;
        cardData[index].fireRanage = deck.fireRange;
        cardData[index].fireTime = deck.fireTime;
    }

}
[System.Serializable]
public class CardData
{
    public string cardName;
    public string cardDescription;
    public string cardSprite;
    public float cardDamage;
    public int cardIndex;
    public float maxHp;
    public Vector3 fireRanage;
    public float fireTime;
}
