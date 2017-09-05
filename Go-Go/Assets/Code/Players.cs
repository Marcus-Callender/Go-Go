using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public bool m_player2 = false;

    public Camera m_camera;

    void Start()
    {
        m_camera = GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 _mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawRay(_mousePos, Vector3.forward * 15.0f, Color.green);
        
        //int mouseDown = Input.GetMouseButtonDown(0) ? (Input.GetMouseButtonDown(1) ? -1 : 1) : 0;
        int mouseDown = Input.GetMouseButtonDown(0) ? 0 : (Input.GetMouseButtonDown(1) ? 1 : -1);

        Debug.Log("Mouse: " + mouseDown);

        if (mouseDown > -1)
        {
            Vector3 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit[] hit = Physics.RaycastAll(mousePos, Vector3.forward * 15.0f);

            foreach (RaycastHit oneHit in hit)
            {
                Stone data = oneHit.transform.gameObject.GetComponent<Stone>();

                if (data)
                {
                    if (data.ClickStone(mouseDown, m_player2 ? 1 : 0))
                    {
                        Debug.Log("Cicked");
                        m_player2 = !m_player2;
                    }
                    else
                    {
                        Debug.Log("Click Failed");
                    }
                }

                break;
            }
        }
    }
}
