using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NalogSpawn : MonoBehaviour
{

    public Controller controller;
    [SerializeField]
    private GameObject nalog;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private float spawnRate;
    public bool stopSpawn = false;
    [SerializeField]
    private float force = 3f;
    [SerializeField]
    private float destroyTime = 5f;
    //[SerializeField]
    //private AnimationCurve posToRotCurce;
    [SerializeField]
    private float spawnPosHeight = 7f;
    [SerializeField]
    private float posBorder = 2.5f;
    [SerializeField]
    private float rotBorder = 45f;

    private Dictionary<NalogType, string> nalogRusName = new Dictionary<NalogType, string>
    {
        { NalogType.ENVD, "ЕНВД"},
        { NalogType.ESHN, "ЕСХН"},
        { NalogType.InsuranceForEmplyees, "Страховка для работников"},
        { NalogType.LandTax, "Земельный налог"},
        { NalogType.MedicalAndPensionInsurance, "Страховка за себя"},
        { NalogType.NDFL, "НДФЛ"},
        { NalogType.NDFLForEmployees, "НДФЛ за сотрудников"},
        { NalogType.NDS, "НДС"},
        { NalogType.OrganizationProfitTax, "Налог на прибыль организации"},
        { NalogType.PropertyTax, "Налог на имущество"},
        { NalogType.ProperyTaxCadastral, "Кадастровый налог на имущество"},
        { NalogType.PSN, "ПСН"},
        { NalogType.SimplifiedSystemTax, "Налог по упрощенной системе"},
        { NalogType.TransportTax, "Транспортный налог"}
    };
    void Start()
    {
        InvokeRepeating("SpawnNalog", spawnTime, spawnRate);
    }

    public void SpawnNalog()
    {
        float spawnPosX = Random.Range(-posBorder, posBorder);
        float spawnRotZ = 0f;
        if (spawnPosX > 0)
        {
            spawnRotZ = Random.Range(-rotBorder, 0);
        }
        else
        {
            spawnRotZ = Random.Range(0, rotBorder);
        }
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosHeight, 0f);
        Quaternion spawnRot = Quaternion.Euler(0f, 0f, spawnRotZ);
        NalogType nalogType = (NalogType)Random.Range(0, System.Enum.GetNames(typeof(NalogType)).Length);
        string nalogText = nalogRusName[nalogType];
        GameObject newNalog = Instantiate(nalog, spawnPos, spawnRot);
        newNalog.GetComponent<Rigidbody2D>().velocity = -newNalog.transform.up * force;
        newNalog.GetComponent<Nalog>().controller = this.controller;
        newNalog.GetComponent<Nalog>().type = nalogType;
        newNalog.GetComponentInChildren<TextMeshPro>().SetText(nalogText);

        //newNalog.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -force), ForceMode2D.Impulse);
        Destroy(newNalog, destroyTime);
        if (stopSpawn)
        {
            CancelInvoke("SpawnNalog");
        }
    }
}
