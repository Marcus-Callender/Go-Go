using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    Renderer m_mat;

    void Start()
    {
        m_mat = GetComponent<Renderer>();
        
    }
    
    void Update()
    {
        
    }

    public bool ClickStone(int mouseButton, int player)
    {
        Debug.Log("Ply: " + player);

        if (mouseButton == 0)
        {
            if (player == 0)
            {
                m_mat.material.color = new Color(1.0f, 0.92f, 0.016f, 1.0f);

                Debug.Log("Yellow");

                return true;
            }
            else if (player == 1)
            {
                m_mat.material.color = new Color(1.0f, 0.0f, 1.0f, 1.0f);

                Debug.Log("Purple");

                return true;
            }
        }
        else if (mouseButton == 1)
        {
            m_mat.material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

            return true;
        }

        return false;
    }
}
