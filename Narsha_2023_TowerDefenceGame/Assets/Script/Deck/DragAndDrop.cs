using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DragAndDrop : MonoBehaviour//, IPointerDownHandler,IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //[SerializeField] private Canvas canvas;
    [SerializeField] private GameObject draggedObject;
/*    [SerializeField] private TextMeshProUGUI draggedTmp1;
    [SerializeField] private TextMeshProUGUI draggedTmp2;*/
    [SerializeField] private Image draggedImg;
    
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public List<GameObject> thisGameObject;
    public bool isGround;


    private Vector3 startPosition;
    private Vector3 endPosition;

    private Vector3 mPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        isGround = false;
        startPosition = this.gameObject.transform.position;
    }

    private void Update()
    {
        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    canvasGroup.alpha = 10.0f;
    //    canvasGroup.blocksRaycasts = false;
    //}
    //public void OnDrag(PointerEventData eventData)
    //{
    //    rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    //}
    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    canvasGroup.alpha = 10.0f;
    //    draggedObject.transform.localScale = new Vector2(1.0f, 1.0f);
    //    draggedImg.transform.localScale = new Vector2(1f, 1f);
    //    canvasGroup.blocksRaycasts=true;
    //}
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log("Point has been down");
    //    /*draggedTmp1.transform.localScale = 3*/
    //    draggedObject.transform.localScale = new Vector2(1.2f,1.2f);
    //    draggedImg.transform.localScale = new Vector2(1.2f, 1.2f);
    //}

    private void OnMouseDrag()
    {
        gameObject.transform.position = new Vector2(mPosition.x, mPosition.y);
    }

    private void OnMouseUp()
    {
        this.gameObject.transform.position = endPosition;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DropArea") || collision.CompareTag("Slot"))
        {
            isGround = true;
            endPosition = collision.transform.position;
            if(isGround && collision.CompareTag("DropArea"))
            {
                thisGameObject[0].SetActive(false);
                thisGameObject[1].SetActive(true);
            }
        } else
        {
            isGround=false;
            endPosition = startPosition;
        }
    }







    //public void OnMouseDrag()
    //{

    //    Draw = true;

    //    boxCollider2D.offset = new Vector2(2.5f, 0f);

    //    boxCollider2D.size = new Vector2(5f, 5f);

    //    gameObject.transform.position = new Vector2(mPosition.x, mPosition.y);
    //}

    //public void OnMouseUp()
    //{

    //    //Draw = false;

    //    boxCollider2D.offset = new Vector2(2.5f, 0f);

    //    boxCollider2D.size = new Vector2(5f, 8f);

    //    transform.position = targetPostion;

    //    if (attacktrue)
    //    {
    //        FireRange = Range;
    //    }
    //}

    //public void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("DropArea"))
    //    {
    //        attacktrue = true;
    //        targetPostion = other.transform.position;
    //    }
    //    else
    //    {
    //        attacktrue = false;
    //        targetPostion = StartPostion;
    //    }
    //}

}
