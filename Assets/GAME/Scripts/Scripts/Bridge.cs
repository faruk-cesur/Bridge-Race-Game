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
                    var go = Instantiate(gameObject, new Vector3(transform.position.x, transform.position.y + 0.30f, transform.position.z + 0.6f), transform.rotation, bridgeParentObject.transform);
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
                            character.player.collectedBrickListBlue[character.player.collectedBrickListBlue.Count - 1].gameObject.transform.position = BrickSpawner.Instance.blueBricksPositionList[i];
                        }
                    }

                    character.player.collectedBrickListBlue.RemoveAt(character.player.collectedBrickListBlue.Count - 1);
                }

                if (character.CompareTag("Green") && character.characterGreen.collectedBrickListGreen.Count > 0)
                {
                    _isCharacterTouch = true;
                    var go = Instantiate(gameObject, new Vector3(transform.position.x, transform.position.y + 0.30f, transform.position.z + 0.6f), transform.rotation, bridgeParentObject.transform);
                    go.GetComponentInChildren<MeshRenderer>().sharedMaterial = go.GetComponent<Bridge>().materials[2];
                    stairCollider.enabled = false;
                    character.characterGreen.collectedBrickListGreen[character.characterGreen.collectedBrickListGreen.Count - 1].gameObject.tag = "Empty";
                    character.characterGreen.collectedBrickListGreen[character.characterGreen.collectedBrickListGreen.Count - 1].gameObject.transform.SetParent(brickParentObject.transform);
                    character.characterGreen.collectedBrickListGreen[character.characterGreen.collectedBrickListGreen.Count - 1].gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    character.characterGreen.collectedBrickListGreen[character.characterGreen.collectedBrickListGreen.Count - 1].gameObject.GetComponent<Collider>().enabled = true;
                    for (int i = 0; i < BrickSpawner.Instance.bricksList.Count; i++)
                    {
                        if (BrickSpawner.Instance.bricksList[i].CompareTag("Empty"))
                        {
                            BrickSpawner.Instance.bricksList[i].tag = "Untagged";
                            character.characterGreen.collectedBrickListGreen[character.characterGreen.collectedBrickListGreen.Count - 1].gameObject.transform.position = BrickSpawner.Instance.greenBricksPositionList[i];
                        }
                    }

                    character.characterGreen.collectedBrickListGreen.RemoveAt(character.characterGreen.collectedBrickListGreen.Count - 1);
                }

                if (character.CompareTag("Pink") && character.characterPink.collectedBrickListPink.Count > 0)
                {
                    _isCharacterTouch = true;
                    var go = Instantiate(gameObject, new Vector3(transform.position.x, transform.position.y + 0.30f, transform.position.z + 0.6f), transform.rotation, bridgeParentObject.transform);
                    go.GetComponentInChildren<MeshRenderer>().sharedMaterial = go.GetComponent<Bridge>().materials[3];
                    stairCollider.enabled = false;
                    character.characterPink.collectedBrickListPink[character.characterPink.collectedBrickListPink.Count - 1].gameObject.tag = "Empty";
                    character.characterPink.collectedBrickListPink[character.characterPink.collectedBrickListPink.Count - 1].gameObject.transform.SetParent(brickParentObject.transform);
                    character.characterPink.collectedBrickListPink[character.characterPink.collectedBrickListPink.Count - 1].gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    character.characterPink.collectedBrickListPink[character.characterPink.collectedBrickListPink.Count - 1].gameObject.GetComponent<Collider>().enabled = true;
                    for (int i = 0; i < BrickSpawner.Instance.bricksList.Count; i++)
                    {
                        if (BrickSpawner.Instance.bricksList[i].CompareTag("Empty"))
                        {
                            BrickSpawner.Instance.bricksList[i].tag = "Untagged";
                            character.characterPink.collectedBrickListPink[character.characterPink.collectedBrickListPink.Count - 1].gameObject.transform.position = BrickSpawner.Instance.pinkBricksPositionList[i];
                        }
                    }

                    character.characterPink.collectedBrickListPink.RemoveAt(character.characterPink.collectedBrickListPink.Count - 1);
                }

                if (character.CompareTag("Orange") && character.characterOrange.collectedBrickListOrange.Count > 0)
                {
                    _isCharacterTouch = true;
                    var go = Instantiate(gameObject, new Vector3(transform.position.x, transform.position.y + 0.30f, transform.position.z + 0.6f), transform.rotation, bridgeParentObject.transform);
                    go.GetComponentInChildren<MeshRenderer>().sharedMaterial = go.GetComponent<Bridge>().materials[4];
                    stairCollider.enabled = false;
                    character.characterOrange.collectedBrickListOrange[character.characterOrange.collectedBrickListOrange.Count - 1].gameObject.tag = "Empty";
                    character.characterOrange.collectedBrickListOrange[character.characterOrange.collectedBrickListOrange.Count - 1].gameObject.transform.SetParent(brickParentObject.transform);
                    character.characterOrange.collectedBrickListOrange[character.characterOrange.collectedBrickListOrange.Count - 1].gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    character.characterOrange.collectedBrickListOrange[character.characterOrange.collectedBrickListOrange.Count - 1].gameObject.GetComponent<Collider>().enabled = true;
                    for (int i = 0; i < BrickSpawner.Instance.bricksList.Count; i++)
                    {
                        if (BrickSpawner.Instance.bricksList[i].CompareTag("Empty"))
                        {
                            BrickSpawner.Instance.bricksList[i].tag = "Untagged";
                            character.characterOrange.collectedBrickListOrange[character.characterOrange.collectedBrickListOrange.Count - 1].gameObject.transform.position = BrickSpawner.Instance.orangeBricksPositionList[i];
                        }
                    }

                    character.characterOrange.collectedBrickListOrange.RemoveAt(character.characterOrange.collectedBrickListOrange.Count - 1);
                }
            }
        }
    }
}