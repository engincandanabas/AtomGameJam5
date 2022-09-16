using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AreaScript : MonoBehaviour
{
    public Sprite[] sprites;
    private GameObject createdArea;
    public GameObject IntantaneArea;
    public int AreaIndex = 0;
    public GameObject[] DoorList;
    bool onArrow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScrollChangeArea();
    }
    public void AreaCreating()
    {
        createdArea = Instantiate(IntantaneArea);
        createdArea.transform.parent = transform;
        createdArea.transform.localPosition = new Vector3(0, 0, 0);
        createdArea.GetComponent<SpriteRenderer>().sprite = sprites[AreaIndex];

        createdArea.transform.localScale = new Vector3(0, 0, 0);
        createdArea.transform.parent = null;
        GetComponent<Image>().enabled = false;
        createdArea.transform.GetChild(0).gameObject.SetActive(false);
        createdArea.transform.DOScale(new Vector2(2, 2), 1).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            createdArea.transform.GetChild(0).gameObject.SetActive(true);

        });

        if (this.CompareTag("Up"))
        {
            DoorList[0].gameObject.transform.DOScale(new Vector2(.2f, .3f), .3f);
        }
        if (this.CompareTag("Left"))
        {
            DoorList[1].gameObject.transform.DOScale(new Vector2(.2f, .3f), .3f);
        }
        if (this.CompareTag("Down"))
        {
            DoorList[2].gameObject.transform.DOScale(new Vector2(.2f, .3f), .3f);
        }
        if (this.CompareTag("Right"))
        {
            DoorList[3].gameObject.transform.DOScale(new Vector2(.2f, .3f), .3f);
        }

        // transform.GetChild(0).transform.DOScale(new Vector2(357.1428f, 357.1428f),1).SetEase(Ease.OutBounce);
        // gm.transform.DOScale(new Vector2(714.2857f, 714.2857f),1);
        // GetComponentInChildren<Transform>().DOScale(new Vector2(714.2857f, 714.2857f), 1);

    }
    public void OpenArrow()
    {

         transform.GetChild(0).GetComponent<Image>().enabled = true;
        onArrow = true;
        GetComponent<Image>().color = new Color(0.4153922f, 0.8396226f, 0.3833748f, .5f);
        //  GetComponent<Image>().sprite = sprites[AreaIndex];
    }
    public void CloseArrow()
    {
        transform.GetChild(0).GetComponent<Image>().enabled = false;
        onArrow = false;
        GetComponent<Image>().color = new Color(1, 1, 1, 0);


    }
    public void ScrollChangeArea()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {


            if (onArrow)
            {
                AreaIndex++;
                GetComponent<Image>().sprite = sprites[AreaIndex];

            }

        }
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {

            if (onArrow)
            {
                AreaIndex--;
                GetComponent<Image>().sprite = sprites[AreaIndex];

            }

        }

    }
}
