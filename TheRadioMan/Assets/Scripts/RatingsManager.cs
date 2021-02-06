using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingsManager : MonoBehaviour
{
    public List<rating> ratings = new List<rating>();
    public GameObject happy;
    public GameObject indifferent;
    public GameObject sad;

    public static RatingsManager Instance { get; private set; }

    void Awake() {
        Instance = this;
    }

    void Update() {
        if ( Input.GetKeyDown( "space" ) ) {
            AddToRatings( 5 );
        }
    }

    void Start()
    {
        for ( int i = 0; i < ratings.Count; i++ ) {
            rating rating = ratings[i];
            rating.startPos = transform.position;
            Debug.Log( "does it work" );
        }
        UpdateRatings();
    }

    void AddToRatings(int amount) {
        int transferRating = 0;
        for ( int i = 0; i < ratings.Count; i++ ) {
            rating rating = ratings[i];
            int outdatedRating = rating.myRating;
            if (i == 0 ) {
                rating.myRating = rating.myRating + amount;
            }
            else {
                rating.myRating = transferRating;
            }
            transferRating = outdatedRating;
        }
        UpdateRatings();
    }

    void UpdateRatings() {
        int currentRating = 0;
        for ( int i = 0; i < ratings.Count; i++ ) {
            rating rating = ratings[i];
            if (i == 0 ) {
                currentRating = rating.myRating;
            }
            int steps = rating.myRating / 5;
            float offset = steps * 0.01f;
            Debug.Log( offset );
            rating.mask.transform.localPosition = rating.startPos + new Vector3( 0, offset, 0 );
        }

        //Haat me niet Rick

        if (currentRating > 80 ) {
            happy.gameObject.SetActive( true );
            indifferent.gameObject.SetActive( false );
            sad.gameObject.SetActive( false );
        }
        else if ( currentRating < 50 ) {
            happy.gameObject.SetActive( false );
            indifferent.gameObject.SetActive( false );
            sad.gameObject.SetActive( true );
        }
        else {
            happy.gameObject.SetActive( false );
            indifferent.gameObject.SetActive( true );
            sad.gameObject.SetActive( false );
        }

    }
}

[System.Serializable]
public struct rating
{
    public int myRating;
    public Transform mask;
    public Vector3 startPos;
}
