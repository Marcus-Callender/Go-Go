using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    Material m_mat;

    void Start()
    {
        m_mat = GetComponent<Material>();

        m_mat.SetColor("clear", Color.clear);
    }
    
    void Update()
    {

    }
}
