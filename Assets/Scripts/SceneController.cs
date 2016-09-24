using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    public const int rows = 6;
    public const int cols = 6;

    public const float offsetX = 2.0f;
    public const float offsetY = 1.75f;


    [SerializeField] private Tile originalTile;
    [SerializeField] private Sprite[] images;

     private Text score;
    private Tile _firstRevealed;
    private Tile _secondRevealed;
    private Tile _thirdRevealed;

    private int _score = 0;
    // Use this for initialization
    void Start ()
    {
        score = GameObject.Find("Canvas/Score").GetComponent<Text>();
        score.text = _score.ToString();

	    Vector3 startPos = originalTile.transform.position;
	    for (int i = 0; i < cols; i++)
	    {
            
	        for (int j = 0; j < rows; j++)
	        {
	            Tile tile;
	            if (i == 0 && j == 0)
	            {
	                tile = originalTile;
	            }
	            else
	            {
	                tile = Instantiate(originalTile) as Tile;
                    
	            }

                //int id = Random.Range(0, images.Length % 3);
	            //if (images.Length%3 == 0)
	            //{
	                int id = j;
	            //}
	            tile.SetTile(id, images[id]);

	            float posX = (offsetX*i) + startPos.x;
	            float posY = (offsetY*j) + startPos.y;

                tile.transform.position = new Vector3(posX, posY, startPos.z);
	        }
	    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool canReveal
    {
        get { return _thirdRevealed == null; }
    }

    public void TileRevealed(Tile tile)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = tile;
        }
        else if (_firstRevealed != null && _secondRevealed == null)
        {
            _secondRevealed = tile;
        }
        else
        {
            _thirdRevealed = tile;
            /*
            Debug.Log("firstRevelaed " + _firstRevealed.id);
            Debug.Log("secondrevealed" + _secondRevealed.id);
            Debug.Log("Third revealed" + _thirdRevealed.id);
            Debug.Log("Match ? " + (_firstRevealed.id == _secondRevealed.id  && _secondRevealed.id == _thirdRevealed.id &&
                                    _firstRevealed.id == _thirdRevealed.id));
             */

            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id && _secondRevealed.id == _thirdRevealed.id &&
                                    _firstRevealed.id == _thirdRevealed.id)
        {
            _score++;
            score.text = _score.ToString();
            Debug.Log("Score" + _score);
            Destroy(_firstRevealed.gameObject);
            Destroy(_secondRevealed.gameObject);
            Destroy(_thirdRevealed.gameObject);

        }
        else
        {
            yield return new WaitForSeconds(.5f);
            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
            _thirdRevealed.Unreveal();
        }

        

        _firstRevealed = null;
        _secondRevealed = null;
        _thirdRevealed = null;
    }
        
    


}
