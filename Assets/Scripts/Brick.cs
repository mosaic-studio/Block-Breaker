using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;
    
    private bool isBreakable;
    private int timesHit;
    private LevelManager levelManager;


	// Use this for initialization
	void Start () {
        isBreakable = (this.tag == "Breakable");
        // Keep track of breakable bricks
        if (isBreakable)
        {
            breakableCount++;
        }
        timesHit = 0;
        levelManager = FindObjectOfType<LevelManager>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position, 0.8f);
        if (isBreakable)
        {
            HandleHits();

        }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            // Load the Particles
            GameObject smokePuff = Instantiate(smoke, this.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick Sprite missing");
        }
        
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
