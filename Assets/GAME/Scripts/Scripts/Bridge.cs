using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;


public class Bridge : MonoBehaviour
{
    [ReorderableList] [SerializeField] private List<Material> materials;
    [SerializeField] private GameObject bridgeParentObject;
    [SerializeField] private GameObject brickParentObject;
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
                    var go = Instantiate(gameObject, new Vector3(transform.localPosition.x, transform.localPosition.y + 0.30f, transform.localPosition.z + 0.6f), transform.localRotation, bridgeParentObject.transform);
                    go.GetComponentInChildren<MeshRenderer>().sharedMaterial = go.GetComponent<Bridge>().materials[1];
                    stairCollider.enabled = false;
                    character.player.collectedBrickListBlue[character.player.collectedBrickListBlue.Count - 1].gameObject.tag = "Empty";
                    character.player.collectedBrickListBlue[character.player.collectedBrickListBlue.Count - 1].gameObject.transform.SetParent(brickParentObject.transform);
                    character.player.collectedBrickListBlue[character.player.collectedBrickListBlue.Count - 1].gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    character.player.collectedBrickListBlue[character.player.collectedBrickListBlue.Count - 1].gameObject.GetComponent<Collider>().enabled = true;
                    for (int i = 0; i < BrickSpawner.Instance.bricksList.Count; i++)
                    {
                        if (BrickSpawner.Instance.bricksList[i].CompareTag("Empty"))
                        {
                            BrickSpawner.Instance.bricksList[i].tag = "Untagged";
                            character.player.collectedBrickListBlue[character.player.collectedBrickListBlue.Count - 1].gameObject.transform.position = BrickSpawner.Instance.bricksPositionList[i];
                        }
                    }
                    character.player.collectedBrickListBlue.RemoveAt(character.player.collectedBrickListBlue.Count - 1);
                }
                
                if (character.CompareTag("Green") && character.player.collectedBrickListBlue.Count > 0)
                {
                    _isCharacterTouch = true;
                    var go = Instantiate(gameObject, new Vector3(transform.localPosition.x, transform.localPosition.y + 0.30f, transform.localPosition.z + 0.6f), transform.localRotation, bridgeParentObject.transform);
                    go.GetComponentInChildren<MeshRenderer>().sharedMaterial = go.GetComponent<Bridge>().materials[1];
                    stairCollider.enabled = false;
                    character.player.collectedBrickListBlue[character.player.collectedBrickListBlue.Count - 1].gameObject.tag = "Empty";
                    character.player.collectedBrickListBlue[character.player.collectedBrickListBlue.Count - 1].gameObject.transform.SetParent(brickParentObject.transform);
                    character.player.collectedBrickListBlue[character.player.collectedBrickListBlue.Count - 1].gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    character.player.collectedBrickListBlue[character.player.collectedBrickListBlue.Count - 1].gameObject.GetComponent<Collider>().enabled = true;
                    for (int i = 0; i < BrickSpawner.Instance.bricksList.Count; i++)
                    {
                        if (BrickSpawner.Instance.bricksList[i].CompareTag("Empty"))
                        {
                            BrickSpawner.Instance.bricksList[i].tag = "Untagged";
                            character.player.collectedBrickListBlue[character.player.collectedBrickListBlue.Count - 1].gameObject.transform.position = BrickSpawner.Instance.bricksPositionList[i];
                        }
                    }
                    character.player.collectedBrickListBlue.RemoveAt(character.player.collectedBrickListBlue.Count - 1);
                }
            }
        }
    }
}