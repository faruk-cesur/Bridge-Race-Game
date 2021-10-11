using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;


public class Bridge : MonoBehaviour
{
    [ReorderableList] [SerializeField] private List<Material> materials;

    [SerializeField] private GameObject parentObject;
    [SerializeField] private Collider stairCollider;

    private bool _isCharacterTouch;

    private void OnTriggerEnter(Collider other)
    {
        CharacterController character = other.GetComponentInParent<CharacterController>();
        if (character)
        {
            if (!_isCharacterTouch)
            {
                _isCharacterTouch = true;

                if (character.CompareTag("Blue") && GameManager.Instance.collectedBrickBlueList.Count > 0)
                {
                    var go = Instantiate(gameObject, new Vector3(transform.localPosition.x, transform.localPosition.y + 0.30f, transform.localPosition.z + 0.6f), transform.localRotation, parentObject.transform);
                    go.GetComponentInChildren<MeshRenderer>().sharedMaterial = go.GetComponent<Bridge>().materials[1];
                    Destroy(GameManager.Instance.collectedBrickBlueList[GameManager.Instance.collectedBrickBlueList.Count - 1]);
                    GameManager.Instance.collectedBrickBlueList.RemoveAt(GameManager.Instance.collectedBrickBlueList.Count - 1);
                    stairCollider.enabled = false;
                }
            }
        }
    }
}