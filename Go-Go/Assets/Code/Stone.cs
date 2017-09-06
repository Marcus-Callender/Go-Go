using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    Renderer m_mat;

    public bool m_claimed = false;
    public int m_player = -1;

    void Start()
    {
        m_mat = GetComponent<Renderer>();
    }
    
    void Update()
    {
        
    }

    public bool ClickStone(int mouseButton, int player)
    {
        Debug.Log("Play: " + player);

        if (mouseButton == 0 && !m_claimed)
        {
            if (player == 0)
            {
                m_mat.material.color = new Color(1.0f, 0.92f, 0.016f, 1.0f);

                m_claimed = true;
                m_player = player;

                Debug.Log("Yellow");

                return true;
            }
            else if (player == 1)
            {
                m_mat.material.color = new Color(1.0f, 0.0f, 1.0f, 1.0f);

                m_claimed = true;
                m_player = player;

                Debug.Log("Purple");

                return true;
            }
        }
        else if (mouseButton == 1 && m_claimed)
        {
            m_mat.material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

            m_claimed = false;
            m_player = -1;
        }

        return false;
    }
    
    public bool ClaimStone(int player, Color newColour)
    {
        if (!m_claimed)
        {
            m_mat.material.color = newColour;

            m_claimed = true;
            m_player = player;

            return true;
        }

        return false;
    }

    public bool RemoveStone()
    {
        if (m_claimed)
        {
            m_mat.material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

            m_claimed = false;
            m_player = -1;

            return true;
        }

        return false;
    }
}
