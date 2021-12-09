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
    [SerializeField] private GameObject _brickParentObject;
    [SerializeField] private GameObject _stairCollider;

    private GameObject _lastCollectedBrickBlue;
    private GameObject _lastCollectedBrickGreen;
    private GameObject _lastCollectedBrickPink;
    private GameObject _lastCollectedBrickOrange;
    private BrickSpawner _brickSpawner1;
    private BrickSpawner _brickSpawner2;
    private BrickSpawner _brickSpawner3;

    private Vector3 _nextBridgePosition;

    private bool _isCharacterTouch;

    private void Awake()
    {
        _nextBridgePosition = new Vector3(transform.position.x, transform.position.y + 0.30f, transform.position.z + 0.6f);
        _brickSpawner1 = GameObject.FindGameObjectWithTag("BrickSpawner1").GetComponentInParent<BrickSpawner>();
        _brickSpawner2 = GameObject.FindGameObjectWithTag("BrickSpawner2").GetComponentInParent<BrickSpawner>();
        _brickSpawner3 = GameObject.FindGameObjectWithTag("BrickSpawner3").GetComponentInParent<BrickSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterController character = other.GetComponentInParent<CharacterController>();
        //BrickSpawner brickSpawner1Script = _brickSpawner1.GetComponentInParent<BrickSpawner>();
        BrickSpawner brickSpawner2Script = _brickSpawner2.GetComponentInParent<BrickSpawner>();
        BrickSpawner brickSpawner3Script = _brickSpawner3.GetComponentInParent<BrickSpawner>();

        if (character)
        {
            if (!_isCharacterTouch)
            {
                if (character.CompareTag("Blue") && character.player.collectedBrickListBlue.Count > 0)
                {
                    print(_brickSpawner1.blueBricksPositionList.Count);


                    _isCharacterTouch = true;
                    _lastCollectedBrickBlue = character.player.collectedBrickListBlue[character.player.collectedBrickListBlue.Count - 1].gameObject;
                    var blueBridge = Instantiate(gameObject, _nextBridgePosition, transform.rotation, _bridgeParentObject.transform);
                    blueBridge.GetComponentInChildren<MeshRenderer>().sharedMaterial = blueBridge.GetComponent<Bridge>()._materials[1];
                    _stairCollider.layer = 6;
                    _lastCollectedBrickBlue.transform.SetParent(_brickParentObject.transform);
                    _lastCollectedBrickBlue.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    _lastCollectedBrickBlue.GetComponent<Collider>().enabled = true;
                    _lastCollectedBrickBlue.transform.position = _brickSpawner1.blueBricksPositionList[0];
                    
                    character.player.collectedBrickListBlue.RemoveAt(character.player.collectedBrickListBlue.Count - 1);
                }

                if (character.CompareTag("Green") && character.characterGreen.collectedBrickListGreen.Count > 0)
                {
                    _isCharacterTouch = true;
                    _lastCollectedBrickGreen = character.characterGreen.collectedBrickListGreen[character.characterGreen.collectedBrickListGreen.Count - 1].gameObject;
                    var greenBridge = Instantiate(gameObject, _nextBridgePosition, transform.rotation, _bridgeParentObject.transform);
                    greenBridge.GetComponentInChildren<MeshRenderer>().sharedMaterial = greenBridge.GetComponent<Bridge>()._materials[2];
                    _stairCollider.layer = 7;
                    _lastCollectedBrickGreen.tag = "Empty";
                    _lastCollectedBrickGreen.transform.SetParent(_brickParentObject.transform);
                    _lastCollectedBrickGreen.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    _lastCollectedBrickGreen.GetComponent<Collider>().enabled = true;
                    // for (int i = 0; i < BrickSpawner.Instance.bricksList.Count; i++)
                    // {
                    //     if (BrickSpawner.Instance.bricksList[i].CompareTag("Empty"))
                    //     {
                    //         BrickSpawner.Instance.bricksList[i].tag = "Untagged";
                    //         _lastCollectedBrickGreen.transform.position = BrickSpawner.Instance.greenBricksPositionList[i];
                    //     }
                    // }

                    character.characterGreen.collectedBrickListGreen.RemoveAt(character.characterGreen.collectedBrickListGreen.Count - 1);
                }

                if (character.CompareTag("Pink") && character.characterPink.collectedBrickListPink.Count > 0)
                {
                    _isCharacterTouch = true;
                    _lastCollectedBrickPink = character.characterPink.collectedBrickListPink[character.characterPink.collectedBrickListPink.Count - 1].gameObject;
                    var pinkBridge = Instantiate(gameObject, _nextBridgePosition, transform.rotation, _bridgeParentObject.transform);
                    pinkBridge.GetComponentInChildren<MeshRenderer>().sharedMaterial = pinkBridge.GetComponent<Bridge>()._materials[3];
                    _stairCollider.layer = 8;
                    _lastCollectedBrickPink.tag = "Empty";
                    _lastCollectedBrickPink.transform.SetParent(_brickParentObject.transform);
                    _lastCollectedBrickPink.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    _lastCollectedBrickPink.GetComponent<Collider>().enabled = true;
                    // for (int i = 0; i < BrickSpawner.Instance.bricksList.Count; i++)
                    // {
                    //     if (BrickSpawner.Instance.bricksList[i].CompareTag("Empty"))
                    //     {
                    //         BrickSpawner.Instance.bricksList[i].tag = "Untagged";
                    //         _lastCollectedBrickPink.transform.position = BrickSpawner.Instance.pinkBricksPositionList[i];
                    //     }
                    // }

                    character.characterPink.collectedBrickListPink.RemoveAt(character.characterPink.collectedBrickListPink.Count - 1);
                }

                if (character.CompareTag("Orange") && character.characterOrange.collectedBrickListOrange.Count > 0)
                {
                    _isCharacterTouch = true;
                    _lastCollectedBrickOrange = character.characterOrange.collectedBrickListOrange[character.characterOrange.collectedBrickListOrange.Count - 1].gameObject;
                    var orangeBridge = Instantiate(gameObject, _nextBridgePosition, transform.rotation, _bridgeParentObject.transform);
                    orangeBridge.GetComponentInChildren<MeshRenderer>().sharedMaterial = orangeBridge.GetComponent<Bridge>()._materials[4];
                    _stairCollider.layer = 9;
                    _lastCollectedBrickOrange.tag = "Empty";
                    _lastCollectedBrickOrange.transform.SetParent(_brickParentObject.transform);
                    _lastCollectedBrickOrange.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    _lastCollectedBrickOrange.GetComponent<Collider>().enabled = true;
                    // for (int i = 0; i < BrickSpawner.Instance.bricksList.Count; i++)
                    // {
                    //     if (BrickSpawner.Instance.bricksList[i].CompareTag("Empty"))
                    //     {
                    //         BrickSpawner.Instance.bricksList[i].tag = "Untagged";
                    //         _lastCollectedBrickOrange.transform.position = BrickSpawner.Instance.orangeBricksPositionList[i];
                    //     }
                    // }

                    character.characterOrange.collectedBrickListOrange.RemoveAt(character.characterOrange.collectedBrickListOrange.Count - 1);
                }
            }
        }
    }
}