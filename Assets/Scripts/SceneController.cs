using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour
{

    public const int rows = 5;
    public const int cols = 5;

    public const float offsetX = 1.15f;
    public const float offsetY = 1.11f;


    [SerializeField] private Tile originalTile;
    [SerializeField] private Sprite[] images;

    // Use this for initialization
	void Start ()
	{
	    Vector3 startPos = originalTile.transform.position;
        Debug.Log(startPos);
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
}
