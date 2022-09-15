using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Enemy
{
    public Type[] _irklar;
    public Type[] _siniflar;
    public Type[] _cinsiyetler;
    public Type[] _silahlar;

    void Awake()
    {
        SetupEnemy();
    }
    void Start()
    {

    }
    void Update()
    {

    }

    void SetupEnemy()
    {
        var _irk=_irklar[Random.Range(0,_irklar.Length)];
        var _sinif=_siniflar[Random.Range(0,_siniflar.Length)];
        var _cinsiyet=_cinsiyetler[Random.Range(0,_cinsiyetler.Length)];
        var _silah=_silahlar[Random.Range(0,_silahlar.Length)];

        this.yakin_etki+=_irk.yakin_etki+_sinif.yakin_etki+_cinsiyet.yakin_etki+_silah.yakin_etki;
        this.uzak_etki+=_irk.uzak_etki+_sinif.uzak_etki+_cinsiyet.uzak_etki+_silah.uzak_etki;
        this.iyilestirme+=_irk.iyilestirme+_sinif.iyilestirme+_cinsiyet.iyilestirme+_silah.iyilestirme;
        this.ganimet+=_irk.ganimet+_sinif.ganimet+_cinsiyet.ganimet+_silah.ganimet;
        this.defans+=_irk.defans+_sinif.defans+_cinsiyet.defans+_silah.defans;
        this.kacinma+=_irk.kacinma+_sinif.kacinma+_cinsiyet.kacinma+_silah.kacinma;
        this.can+=_irk.can+_sinif.can+_cinsiyet.can+_silah.can;
        
        Debug.Log("Enemy INFO \n Irk:"+_irk.name+"\nSınıf:"+_sinif.name+"\nCinsiyet:"+_cinsiyet.name+"\nSilah:"+_silah.name+"");
    }
}
