using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//���������� ���� �ʿ�
public enum TowerCards
{
    none,
    nun,
    assassin,
    spear,
    berserker,
    darkmagician,
    knight,
    holyKnight,
    wizzard,
    archer
}

public class Cards : MonoBehaviour
{
    public int cardIndex;
    public TextMeshProUGUI cardname;
    public TextMeshProUGUI cardDescriptionTxt;
    public TowerCards TowerCard;
    public float cardDmg;
    public string cardNametxt;
    public string cardInfo;
    public GameObject cardImage;
    public string cardSprite;
    public float maxHp;
    public float fireTime;
    public Vector3 fireRange;
    public Animator cardAnim;
    public string animPath;
    public string chName;

    // GoldKnight
    // Player
    
    void Update()
    {    
        mercenaryType();
        cardname.text = cardNametxt;
        if (SceneManager.GetActiveScene().name == "OneStage" || SceneManager.GetActiveScene().name == "TwoStage" || SceneManager.GetActiveScene().name == "ThreeStage" || SceneManager.GetActiveScene().name == "FourStage" || SceneManager.GetActiveScene().name == "FiveStage")
        {
            cardname.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, -0.28f, 0f));
        }
        else
        {
            cardname.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(-0, -0.38f, 0f));
        }
        cardDescriptionTxt.text = cardInfo;
        if (SceneManager.GetActiveScene().name == "OneStage" || SceneManager.GetActiveScene().name == "TwoStage" || SceneManager.GetActiveScene().name == "ThreeStage" || SceneManager.GetActiveScene().name == "FourStage" || SceneManager.GetActiveScene().name == "FiveStage")
        {
            cardDescriptionTxt.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0.6f, -0.5f, 0f));
        }
        else
        {
            cardDescriptionTxt.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0.3f, -0.9f, 0f));
        }
        cardImage.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(cardSprite);
       
        /*cardNametxt = DeckManager.Instance.deckList[1].cardName;
        cardDmg = DeckManager.Instance.deckList[1].cardDamage;
        cardInfo = DeckManager.Instance.deckList[1].cardDescription;
        cardSprite = DeckManager.Instance.deckList[1].cardSprite;*/
    }


    public void mercenaryType()
    {
        switch (cardIndex)
        {
            case 0:
                TowerCard = TowerCards.none;
                break;
            case 1:
                TowerCard = TowerCards.nun;
                break;
            case 2:
                TowerCard = TowerCards.assassin;
                break;
            case 3:
                TowerCard = TowerCards.spear;
                break;
            case 4:
                TowerCard = TowerCards.berserker;
                break;
            case 5:
                TowerCard = TowerCards.darkmagician;
                break;
            case 6:
                TowerCard = TowerCards.knight;
                break;
            case 7:
                TowerCard = TowerCards.wizzard;
                break;
            case 8:
                TowerCard = TowerCards.archer;
                break;
            case 9:
                TowerCard = TowerCards.holyKnight;
                break;
            default:
                TowerCard = TowerCards.none;
                break;
        }
        switch (TowerCard)
        {
            case TowerCards.nun:
                cardNametxt = "����";
                cardInfo = " 10�ʸ��� �Ʊ��� ü���� 5ȸ�� �մϴ�.���� ���� �����մϴ�.";
                cardSprite = "Img/Ch/Player/nun";
                cardDmg = 7;
                break;
            case TowerCards.assassin:
                cardNametxt = "�ϻ���";
                cardInfo = " ��뿡�� ������ ���� �ʽ��ϴ�.���� ���� �����մϴ�";
                cardSprite = "Img/Ch/Player/assassin";
                cardDmg = 15;
                break;
            case TowerCards.spear:
                cardNametxt = "â��";
                cardInfo = "����� ��׷θ� �켱���� �Խ��ϴ�.���� ���� �����մϴ�.";
                cardSprite = "Img/Ch/Player/spear";
                cardDmg = 10;
                break;
            case TowerCards.berserker:
                cardNametxt = "������";
                cardInfo = "����� ��׷θ� �켱���� �Խ��ϴ�.���� ���� �����մϴ�.";
                cardSprite = "Img/Ch/Player/berserker";
                cardDmg = 20;
                break;
            case TowerCards.darkmagician:
                cardNametxt = "�渶����";
                cardInfo = "������ ĭ 4ĭ���� �ִ� ������ ���� ���ظ� �����ϴ�.";
                cardSprite = "Img/Ch/Player/darkmagician";
                cardDmg = 20;
                break;
            case TowerCards.knight:
                cardNametxt = "���";
                chName = "Player";
                cardInfo = "���� ����� ����Դϴ�. ���� ���� �����մϴ�.";
                cardSprite = "Img/Ch/Player/Knight";
                animPath = "Animations/Control/MainCharacter";
                maxHp = 100;
                fireRange = new Vector3(2,2,2);
                fireTime = 2;
                cardDmg = 10;
                break;
            case TowerCards.holyKnight:
                cardNametxt = "�����";
                chName = "GoldKnight";
                cardInfo = "��纸�� ���� ����Դϴ�. ���� ���� �����մϴ�.";
                cardSprite = "Img/Ch/Player/holyknight";
                animPath = "Animations/Control/MainCharacter";
                maxHp = 100;
                fireRange = new Vector3(2, 2, 2);
                fireTime = 2;
                cardDmg = 50;
                break;
            case TowerCards.wizzard:
                cardNametxt = "������";
                cardInfo = "�������̺��.";
                cardSprite = "";
                animPath = "";
                break;
        }
  
    }

}

