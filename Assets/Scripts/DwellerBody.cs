using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwellerBody : MonoBehaviour
{
    public void AlignBody()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0,transform.rotation.eulerAngles.y,0));
    }
}
