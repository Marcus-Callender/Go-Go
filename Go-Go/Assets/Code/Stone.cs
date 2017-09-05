using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    Renderer m_mat;

    void Start()
    {
        m_mat = GetComponent<Renderer>();
        
        m_mat.material.color = Color.yellow;
        m_mat.material.color = new Color(1.0f, 0.92f, 0.016f, 1.0f);
    }
    
    void Update()
    {

    }
}
