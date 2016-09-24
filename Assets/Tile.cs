using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    private bool m_Selected = false;
    private SpriteRenderer m_spriteRenderer;
    
	// Use this for initialization
	void Start ()
	{
	    m_spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMouseDown()
    {
        m_Selected = true;
        m_spriteRenderer.color = Color.Lerp(new Color(m_spriteRenderer.color.r, m_spriteRenderer.color.g, m_spriteRenderer.color.b,
                m_spriteRenderer.color.a), new Color(255, 229, 229), Time.fixedDeltaTime);
        Debug.Log("Testing 1, 2 ,3");
        
        
    }

    
}
