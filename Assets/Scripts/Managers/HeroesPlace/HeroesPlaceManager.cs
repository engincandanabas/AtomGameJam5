using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeroesPlaceManager : MonoBehaviour
{
    [Header("UI Attributes")]
    [SerializeField] private HorizontalLayoutGroup _heroesPlaceLayout;
    [SerializeField] private GameObject[] _heroesBoxes;
    [SerializeField] private TextMeshProUGUI[] _heroesTexts;


    [SerializeField] private int[] _heroesCounts; // 0-mouse 1-dog 2-goblin 3-ogre 4-ork 5-gnoll 

    void Awake() {
        InitializeVariables();
    }
    void Start()
    {
        
    }
    void Update()
    {
        if(GameManager.instance.gameState==GameManager.GameState.menu)
        {
            // eger oyun baslamamissa
            
        }
    }
    private void InitializeVariables()
    {
        // test assaign 
        for (int i = 0; i < 6; i++)
        {
            _heroesCounts[i] = Random.Range(0, 4);
        }
        CheckCount();
    }
    private void CheckCount()
    {
        // aktif herolara gore ui guncellemeleri
        int _activeBoxs = 0;
        for (int i = 0; i < 6; i++)
        {
            _heroesTexts[i].text = "x" + _heroesCounts[i].ToString();
            if (_heroesCounts[i] == 0)
                _heroesBoxes[i].SetActive(false);
            else
                _activeBoxs++;

        }
        switch (_activeBoxs)
        {
            case 2:
                _heroesPlaceLayout.spacing = -1450;
                break;
            case 3:
                _heroesPlaceLayout.spacing = -1150;
                break;
            case 4:
                _heroesPlaceLayout.spacing = -850;
                break;
            case 5:
                _heroesPlaceLayout.spacing = -650;
                break;
            case 6:
                _heroesPlaceLayout.spacing = -450;
                break;
        }
    }
    public void SpawnHero(GameObject heroPrefab)
    {
        switch(heroPrefab.GetComponent<HeroManager>().type)
        {
            case HeroManager.HeroTYpe.mouse:
                _heroesCounts[1]--;
                break;
            case HeroManager.HeroTYpe.dog:
                _heroesCounts[1]--;
                break;
            case HeroManager.HeroTYpe.goblin:
                _heroesCounts[2]--;
                break;
            case HeroManager.HeroTYpe.ogre:
                _heroesCounts[3]--;
                break;
            case HeroManager.HeroTYpe.ork:
                _heroesCounts[4]--;
                break;
            case HeroManager.HeroTYpe.gnoll:
                _heroesCounts[5]--;
                break;
        }
        // spawn isleminden sonra gereken guncellemenin yapilmasi
        CheckCount();
    }
}
