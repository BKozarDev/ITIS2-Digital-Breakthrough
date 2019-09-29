using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nalog : MonoBehaviour
{
    public NalogType type;
    public Controller controller;
    private WaterController waterController;
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private Animator animator;
    public float speed;
    private bool isClicked = false;

    private void Update()
    {
        if (!isClicked)
            transform.position += -transform.up * speed * Time.deltaTime;
    }

    private void OnMouseDown()
    {
        if (!isClicked)
        {
            controller.TapOnNalog(this);
            animator.enabled = true;
            animator.SetBool("isDead", true);
            Destroy(this.gameObject, 1f);
            isClicked = true;
        }

    }
}
