using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour {

    public int maxHits;

    private int timesHit;
    private LevelManager levelManager;


	// Use this for initialization
	void Start () {
        timesHit = 0;
        levelManager = FindObjectOfType<LevelManager>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
        if(timesHit >= maxHits) { 
            Destroy(gameObject);
        }
        // SimulateWin();
    }

    // TODO: Remove this method once we can actually win!
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
