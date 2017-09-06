using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Players : MonoBehaviour
{
    public bool m_player2 = false;

    public Camera m_camera;
    public Text m_text;

    public Color m_player1Colour;
    public Color m_player2Colour;

    public GameObject m_stones;

    public Stone[] m_stoneList;

    public Stone[][] m_stoneSortedArray;

    public double[] m_playerScores = new double[2];

    public double m_komi = 6.5;

    public Text[] m_playerScoreObjects;

    void Start()
    {
        m_camera = GetComponent<Camera>();

        if (m_stones)
        {
            m_stoneList = m_stones.GetComponentsInChildren<Stone>();
        }

        if (m_text)
        {
            m_text.text = ("Player " + (m_player2 ? 2 : 1));
            m_text.color = m_player2 ? m_player2Colour : m_player1Colour;
        }

        m_playerScores[0] = 0.0;
        m_playerScores[1] = m_komi;

        UpdatePlayerScores();
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
                m_text.color = m_player2 ? m_player2Colour : m_player1Colour;
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
                    if (mouseDown == 0)
                    {
                        if (data.ClaimStone(m_player2 ? 1 : 0, m_player2 ? m_player2Colour : m_player1Colour))
                        {
                            m_player2 = !m_player2;
                            
                            if (m_text)
                            {
                                m_text.text = ("Player " + (m_player2 ? 2 : 1));
                                m_text.color = m_player2 ? m_player2Colour : m_player1Colour;
                            }
                        }
                    }
                    else if (mouseDown == 1)
                    {
                        if (data.RemoveStone())
                        {
                            // gives the point to the player who just had there turn as they need to remove pieces after they play
                            m_playerScores[m_player2 ? 0 : 1] += 1.0;

                            UpdatePlayerScores();
                        }
                    }
                }

                break;
            }
        }
    }

    private void UpdatePlayerScores()
    {
        if (m_playerScoreObjects[0])
        {
            m_playerScoreObjects[0].color = m_player1Colour;
            m_playerScoreObjects[0].text = "P1: " + m_playerScores[0];
        }

        if (m_playerScoreObjects[1])
        {
            m_playerScoreObjects[1].color = m_player2Colour;
            m_playerScoreObjects[1].text = "P2: " + m_playerScores[1];
        }
    }
}
