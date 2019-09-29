using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsController : MonoBehaviour
{
    public RectTransform mainCanvas;
    public GameObject[] cloudsPrefab;
    public int cloudsCount;

    private List<GameObject> cloudsList = new List<GameObject>();
    private float randTimer;
    private float curTimer;

    void Start()
    {
        randTimer = Random.Range(0.5f, 2.5f);
        curTimer = randTimer;
    }

    void Update()
    {
        if (cloudsList.Count < cloudsCount)
        {
            curTimer -= Time.deltaTime;
            if (curTimer < 0)
            {
                GameObject go = Instantiate(cloudsPrefab[Random.Range(0, cloudsPrefab.Length)], transform);
                go.GetComponent<Cloud>().cloudsController = this;
                cloudsList.Add(go);

                randTimer = Random.Range(0.5f, 1.5f);
                curTimer = randTimer;
            }
        }
    }
}
