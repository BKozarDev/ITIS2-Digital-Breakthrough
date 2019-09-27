using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnNalogTap : MonoBehaviour
{
    void FixedUpdate()
    {
        OnTap();
        //OnClick();

    }
    // For Phone
    private void OnTap()
    {
        //if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        //{
        //    Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //    RaycastHit raycastHit;
        //    if (Physics.Raycast(raycast, out raycastHit))
        //    {
        //        Debug.Log("Tap clicked");
        //        if (raycastHit.collider.CompareTag("Nalog"))
        //        {
        //            Debug.Log("Nalog clicked");
        //        }
        //    }
        //}

        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            //Debug.Log("Tap");
            RaycastHit2D raycastHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            if (raycastHit.collider!=null)
            {
                Debug.Log("Tap clicked");
                if (raycastHit.collider.CompareTag("Nalog"))
                {
                    Debug.Log("Nalog clicked");
                }
            }
        }
    }
    // For PC
    private void OnClick()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit raycastHit;
        //    if (Physics.Raycast(raycast, out raycastHit))
        //    {
        //        Debug.Log("Mouse clicked");
        //        if (raycastHit.collider.CompareTag("Nalog"))
        //        {
        //            Debug.Log("Nalog clicked");
        //        }
        //    }
        //}

        if (Input.GetMouseButtonDown(0))
        {
            //Ray2D raycast = Camera.main.ScreenPointToRay();
            RaycastHit2D raycastHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (raycastHit)
            {
                Debug.Log("Tap clicked");
                if (raycastHit.collider.CompareTag("Nalog"))
                {
                    Debug.Log("Nalog clicked");
                }
            }
        }
    }
}
