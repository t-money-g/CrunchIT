using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    private bool m_Selected = false;
    private SpriteRenderer m_spriteRenderer;

    [SerializeField] private GameObject tileBack;
    [SerializeField] private Sprite image;
    [SerializeField] private SceneController controller;
    private float desiredScaleX = 0.04f; // your scale factor
    private float desiredScaleY = 0.06f;

    private int _id;

    public int id
    {
        get { return _id; }
    }
    // Use this for initialization
	void Start ()
	{
	    
	    m_spriteRenderer = GetComponent<SpriteRenderer>();
	   
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetTile(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
    public void OnMouseDown()
    {
        if (controller.canReveal)
        {
            m_spriteRenderer.color = Color.cyan;
            controller.TileRevealed(this);
            //Color.Lerp(new Color(m_spriteRenderer.color.r, m_spriteRenderer.color.g, m_spriteRenderer.color.b,
            //m_spriteRenderer.color.a), Color.cyan , Time.fixedDeltaTime);
            // new Color(255, 189, 229)   
        }
        Debug.Log("clicked!" + id);
        //Debug.Log();
    }

    public void Unreveal()
    {
        m_spriteRenderer.color = Color.white;
    }

    
}
