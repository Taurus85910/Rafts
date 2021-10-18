using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDallDestroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out CharacterJoint characterJoint))
      {
          Destroy(characterJoint.GetComponentInParent<RagDall>().gameObject);
      }
    }
}
