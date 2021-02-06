using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{

    public GameObject heart;
    private List<GameObject> hearts = new List<GameObject>();

    private void Start() {
        StartMinigame();
    }

    public void StartMinigame() {
        StartCoroutine(SpawnHeart());
    }

    private IEnumerator SpawnHeart() {
        yield return new WaitForSeconds(1.5f);
        Instantiate(heart, transform.position, Quaternion.identity);
        StartCoroutine(SpawnHeart());
    }

    public void StopMinigame() {
        StopAllCoroutines();
        foreach(GameObject go in hearts) {
            DestroyHeart(go);
        }
    }

    private void DestroyHeart(GameObject _heart) {
        _heart.GetComponent<MoveHeartbeat>().RequestDestroy();
    }
}
