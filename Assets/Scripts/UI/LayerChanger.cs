using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChanger : MonoBehaviour
{
    public void SetUpperLayer(Transform element)
    {
        element.SetSiblingIndex(transform.GetSiblingIndex() + 1);
    }
    
    public void SetLowerLayer(Transform element)
    {
        element.SetSiblingIndex(transform.GetSiblingIndex() - 1);
    }
}
