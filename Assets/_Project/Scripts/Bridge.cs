using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;


public class Bridge : MonoBehaviour
{
    [ReorderableList] [SerializeField] private List<Material> _materials;

    [SerializeField] private GameObject _bridgeParentObject;
    [SerializeField] private GameObject _stairCollider;

    private GameObject _lastCollectedBrickBlue;
    private GameObject _lastCollectedBrickGreen;
    private GameObject _lastCollectedBrickPink;
    private GameObject _lastCollectedBrickOrange;

    private Vector3 _nextBridgePosition;

    private bool _isCharacterTouch;

    private void Awake()
    {
        _nextBridgePosition = new Vector3(transform.position.x, transform.position.y + 0.30f, transform.position.z + 0.6f);
    }

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
                    _lastCollectedBrickBlue = character.player.collectedBrickListBlue[character.player.collectedBrickListBlue.Count - 1].gameObject;
                    var blueBridge = Instantiate(gameObject, _nextBridgePosition, transform.rotation, _bridgeParentObject.transform);
                    blueBridge.GetComponentInChildren<MeshRenderer>().sharedMaterial = blueBridge.GetComponent<Bridge>()._materials[1];
                    _stairCollider.layer = 6;

                    if (_lastCollectedBrickBlue.CompareTag("BrickTaken"))
                    {
                        _lastCollectedBrickBlue.tag = "Empty";
                    }

                    Destroy(character.player.collectedBrickListBlue[character.player.collectedBrickListBlue.Count - 1].gameObject, 0.01f);
                    character.player.collectedBrickListBlue.RemoveAt(character.player.collectedBrickListBlue.Count - 1);
                }

                if (character.CompareTag("Green") && character.characterGreen.collectedBrickListGreen.Count > 0)
                {
                    _isCharacterTouch = true;
                    _lastCollectedBrickGreen = character.characterGreen.collectedBrickListGreen[character.characterGreen.collectedBrickListGreen.Count - 1].gameObject;
                    var greenBridge = Instantiate(gameObject, _nextBridgePosition, transform.rotation, _bridgeParentObject.transform);
                    greenBridge.GetComponentInChildren<MeshRenderer>().sharedMaterial = greenBridge.GetComponent<Bridge>()._materials[2];
                    _stairCollider.layer = 7;

                    if (_lastCollectedBrickGreen.CompareTag("BrickTaken"))
                    {
                        _lastCollectedBrickGreen.tag = "Empty";
                    }

                    Destroy(character.characterGreen.collectedBrickListGreen[character.characterGreen.collectedBrickListGreen.Count - 1].gameObject, 0.01f);
                    character.characterGreen.collectedBrickListGreen.RemoveAt(character.characterGreen.collectedBrickListGreen.Count - 1);
                }

                if (character.CompareTag("Pink") && character.characterPink.collectedBrickListPink.Count > 0)
                {
                    _isCharacterTouch = true;
                    _lastCollectedBrickPink = character.characterPink.collectedBrickListPink[character.characterPink.collectedBrickListPink.Count - 1].gameObject;
                    var pinkBridge = Instantiate(gameObject, _nextBridgePosition, transform.rotation, _bridgeParentObject.transform);
                    pinkBridge.GetComponentInChildren<MeshRenderer>().sharedMaterial = pinkBridge.GetComponent<Bridge>()._materials[3];
                    _stairCollider.layer = 8;

                    if (_lastCollectedBrickPink.CompareTag("BrickTaken"))
                    {
                        _lastCollectedBrickPink.tag = "Empty";
                    }

                    Destroy(character.characterPink.collectedBrickListPink[character.characterPink.collectedBrickListPink.Count - 1].gameObject, 0.01f);
                    character.characterPink.collectedBrickListPink.RemoveAt(character.characterPink.collectedBrickListPink.Count - 1);
                }

                if (character.CompareTag("Orange") && character.characterOrange.collectedBrickListOrange.Count > 0)
                {
                    _isCharacterTouch = true;
                    _lastCollectedBrickOrange = character.characterOrange.collectedBrickListOrange[character.characterOrange.collectedBrickListOrange.Count - 1].gameObject;
                    var orangeBridge = Instantiate(gameObject, _nextBridgePosition, transform.rotation, _bridgeParentObject.transform);
                    orangeBridge.GetComponentInChildren<MeshRenderer>().sharedMaterial = orangeBridge.GetComponent<Bridge>()._materials[4];
                    _stairCollider.layer = 9;

                    if (_lastCollectedBrickOrange.CompareTag("BrickTaken"))
                    {
                        _lastCollectedBrickOrange.tag = "Empty";
                    }

                    Destroy(character.characterOrange.collectedBrickListOrange[character.characterOrange.collectedBrickListOrange.Count - 1].gameObject, 0.01f);
                    character.characterOrange.collectedBrickListOrange.RemoveAt(character.characterOrange.collectedBrickListOrange.Count - 1);
                }
            }
        }
    }
}