using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField] private Material[] materials;

    private Renderer objectRenderer;
    private int currentMaterialIndex = 0;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        if (materials.Length > 0)
        {
            objectRenderer.material = materials[currentMaterialIndex];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate1"))
        {
            ChangeMaterial(1);
        }
        else if (other.CompareTag("Gate2"))
        {
            ChangeMaterial(2);
        }
        else if (other.CompareTag("Gate3"))
        {
            ChangeMaterial(3);
        }
        else if (other.CompareTag("Gate4"))
        {
            ChangeMaterial(4);
        }
    }

    private void ChangeMaterial(int materialIndex)
    {
        if (materialIndex >= 0 && materialIndex < materials.Length)
        {
            objectRenderer.material = materials[materialIndex];
            currentMaterialIndex = materialIndex;
        }
    }
}
