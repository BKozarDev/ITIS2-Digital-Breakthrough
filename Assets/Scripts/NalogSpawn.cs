using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosHeight, 0);
        Quaternion spawnRot = Quaternion.Euler(0f, 0f, spawnRotZ);
        GameObject newNalog = Instantiate(nalog, spawnPos, spawnRot);
        newNalog.GetComponent<Rigidbody2D>().velocity = -newNalog.transform.up * force;
        newNalog.GetComponent<Nalog>().controller = this.controller;

        //newNalog.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -force), ForceMode2D.Impulse);
        Destroy(newNalog, destroyTime);
        if (stopSpawn)
        {
            CancelInvoke("SpawnNalog");
        }
    }
}
