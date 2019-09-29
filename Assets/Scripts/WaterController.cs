using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public Controller controller;
    public const float MinHeightIncreaseAmount = 0.01f;

    public float waterLevel;
    public float clearness;

    public float maxWaterLevel;
    public float startWaterLevel;
    public Material renderMaterial;
    public Color clearColor;
    public Color dirtyColor;

    public GameObject waterBall;

    private float dirtyWaterLevel;
    private Color currentColor;

    private void Awake()
    {
        currentColor = clearColor;
        waterLevel = startWaterLevel;
        clearness = 1;
        dirtyWaterLevel = 0;
        renderMaterial.SetColor("_RightColor", clearColor);
        renderMaterial.SetColor("_WrongColor", dirtyColor);
        renderMaterial.SetColor("_Color", currentColor);
    }

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        pos.z = 0;
    //        BubbleBursted(pos, 5, true);
    //    }
    //    else if (Input.GetMouseButtonDown(1))
    //    {
    //        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        pos.z = 0;
    //        BubbleBursted(pos, 5, false);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WaterBall"))
        {
            waterLevel += MinHeightIncreaseAmount;
            StartCoroutine(IncreaseWaterSmooth());
            WaterBall ball = other.GetComponent<WaterBall>();

            if (!ball.isRight)
            {
                dirtyWaterLevel += MinHeightIncreaseAmount;
            }

            float d = dirtyWaterLevel / waterLevel;
            clearness = 1 - d;
            currentColor = Color.Lerp(clearColor, dirtyColor, d);
            renderMaterial.SetColor("_Color", currentColor);

            if (waterLevel >= maxWaterLevel)
            {
                ResetWater();
            }
            Destroy(other.gameObject, 0.05f);
        }
    }

    private void ResetWater()
    {
        controller.WaterReset(clearness);
        dirtyWaterLevel = 0;
        StartCoroutine(ResetWaterSmooth());
        waterLevel = startWaterLevel;
        clearness = 1;
        currentColor = clearColor;
    }

    public void BubbleBursted(Vector3 position, int capacity, bool isRight)
    {
        float sqr = Mathf.Sqrt(capacity) * 0.1f;
        Debug.Log(sqr);
        for (int i = 0; i < capacity; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-sqr, sqr) + position.x, Random.Range(-sqr, sqr) + position.y, 0);
            GameObject ball = Instantiate(waterBall, pos, Quaternion.identity);
            WaterBall wBall = ball.GetComponent<WaterBall>();
            wBall.isRight = isRight;
        }
    }

    private IEnumerator IncreaseWaterSmooth()
    {
        for (int i = 0; i < 4; i++)
        {
            transform.position += Vector3.up * 0.0025f;
            yield return null;
        }
    }

    private IEnumerator ResetWaterSmooth()
    {
        float timer = 1f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + Vector3.down * (waterLevel - 1);
        while (timer >= 0)
        {
            transform.position = Vector3.Lerp(targetPosition, startPosition, timer);
            timer -= Time.deltaTime;
            yield return null;
        }
    }
}
