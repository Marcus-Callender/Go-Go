using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Players : MonoBehaviour
{
    public bool m_player2 = false;

    public Camera m_camera;

    public Text m_text;

    public GameObject m_stones;

    public Stone[] m_stoneList;

    public Stone[][] m_stoneSortedArray;

    void Start()
    {
        m_camera = GetComponent<Camera>();

        if (m_stones)
        {
            m_stoneList = m_stones.GetComponentsInChildren<Stone>();
        }

        
    }

    void Update()
    {
        Vector3 _mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawRay(_mousePos, Vector3.forward * 15.0f, Color.green);
        
        int mouseDown = Input.GetMouseButtonDown(0) ? 0 : (Input.GetMouseButtonDown(1) ? 1 : -1);

        Debug.Log("Mouse: " + mouseDown);

        if (Input.GetButtonDown("Debug Switch Players"))
        {
            m_player2 = !m_player2;

            if (m_text)
            {
                m_text.text = ("Player " + (m_player2 ? 2 : 1));
            }
        }

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

                        if (m_text)
                        {
                            m_text.text = ("Player " + (m_player2 ? 2 : 1));
                        }
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
