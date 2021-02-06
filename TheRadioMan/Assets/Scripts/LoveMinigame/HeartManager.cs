using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{

    public GameObject heart;
    public GameObject heartOrigin;
    public HeartDestroyer destroyer;
    public GameObject pointer;
    private List<GameObject> hearts = new List<GameObject>();
    public Vector3 movementSpeed = new Vector3(-2, 0, 0);
    public float waitTime = 0.2f;
    public float pressMargin = 2.0f;

    private void Start() {
        StartMinigame();
    }

    public void StartMinigame() {
        StartCoroutine(SpawnHeart());
        StartCoroutine(MoveHearts());
    }

    private IEnumerator SpawnHeart() {
        yield return new WaitForSeconds(5 * waitTime);
        GameObject newHeart = Instantiate(heart, transform.position, Quaternion.identity, transform.parent);
        heartOrigin.GetComponent<Animator>().SetTrigger("Beat");
        hearts.Add(newHeart);
        destroyer.SetHeartList(hearts);
        StartCoroutine(SpawnHeart());
    }

    private IEnumerator MoveHearts() {
        yield return new WaitForSeconds(waitTime);
        foreach(GameObject h in hearts){
            SlideHeart(h);
        }
        StartCoroutine(MoveHearts());
    }

    
    void SlideHeart(GameObject _heart) {
        Vector3 currentPos = _heart.transform.position;
        Vector3 newPos = currentPos + movementSpeed;
        _heart.transform.position = newPos;
    }

    public void ButtonPressed() {
        foreach(GameObject h in hearts){
            if(h.transform.position.x + pressMargin >= pointer.transform.position.x && 
               h.transform.position.x - pressMargin <= pointer.transform.position.x ) {
                   RequestDestroy(h);
                   break;
               }
        }
    }

    public void SetHeartList(List<GameObject> heartList) {
        hearts = heartList;
    }

    public void RequestDestroy(GameObject _heart) {
        DestroyHeart(_heart);
        destroyer.SetHeartList(hearts);
    }
    private void DestroyHeart(GameObject _heart) {
        hearts.Remove(_heart);
        Destroy(_heart);
    }

    public void StopMinigame() {
        StopAllCoroutines();
        foreach(GameObject go in hearts) {
            DestroyHeart(go);
        }
        destroyer.SetHeartList(hearts);
    }
}
