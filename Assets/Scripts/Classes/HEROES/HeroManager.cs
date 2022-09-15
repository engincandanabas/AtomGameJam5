using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    public enum HeroTYpe { mouse,dog,goblin,ogre,ork,gnoll}
    public HeroTYpe type;

    public Type _heroScriptable;
    public int yakin_etki;
    public int uzak_etki;
    public int iyilestirme;
    public int ganimet;
    public int defans;
    public int kacinma;
    public int can;

    // target bulundugu odadan random cekilcek
    [SerializeField] private EnemyManager _target;
    public void Awake()
    {
        InitializeVariables();
    }
    void InitializeVariables()
    {
        // baslangic degerlerinin scriptable objelerden cekilmesi
        yakin_etki = _heroScriptable.yakin_etki;
        uzak_etki = _heroScriptable.uzak_etki;
        iyilestirme = _heroScriptable.iyilestirme;
        ganimet = _heroScriptable.ganimet;
        kacinma = _heroScriptable.kacinma;
        defans = _heroScriptable.defans;
        can = _heroScriptable.can;
    }
    public IEnumerator Attack()
    {

        
        // atak bitti 
        yield return new WaitForSeconds(1);
        StartCoroutine(_target.Attack());

    }
}
