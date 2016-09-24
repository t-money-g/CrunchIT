using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour
{

    public const int rows = 5;
    public const int cols = 5;

    public const float offsetX = 2.0f;
    public const float offsetY = 1.75f;


    [SerializeField] private Tile originalTile;
    [SerializeField] private Sprite[] images;

    private Tile _firstRevealed;
    private Tile _secondRevealed;
    private Tile _thirdRevealed;
    // Use this for initialization
    void Start ()
	{
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

	            int id = Random.Range(0, images.Length);
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
        else if (_firstRevealed != null &&  _secondRevealed == null)
        {
            _secondRevealed = tile;
        }
        else
        {
            _thirdRevealed = tile;
            Debug.Log("firstRevelaed " + _firstRevealed.id);
            Debug.Log("secondrevealed" + _secondRevealed.id);
            Debug.Log("Third revealed" + _thirdRevealed.id);
            Debug.Log("Match ? " + (_firstRevealed.id == _secondRevealed.id  && _secondRevealed.id == _thirdRevealed.id &&
                                    _firstRevealed.id == _thirdRevealed.id));

        }
        
    }


}
