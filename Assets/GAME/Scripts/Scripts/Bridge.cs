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
                if (character.CompareTag("Blue") && character.player.collectedBrickListBlue.Count > 0)
                {
                    _isCharacterTouch = true;
                    var go = Instantiate(gameObject, new Vector3(transform.localPosition.x, transform.localPosition.y + 0.30f, transform.localPosition.z + 0.6f), transform.localRotation, parentObject.transform);
                    go.GetComponentInChildren<MeshRenderer>().sharedMaterial = go.GetComponent<Bridge>().materials[1];
                    Destroy(character.player.collectedBrickListBlue[character.player.collectedBrickListBlue.Count - 1].gameObject);
                    character.player.collectedBrickListBlue.RemoveAt(character.player.collectedBrickListBlue.Count - 1);
                    stairCollider.enabled = false;
                }
                //character.player.collectedBrickListBlue.IndexOf()
            }
        }
    }
}