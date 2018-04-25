using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
//using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Tilemaps;

public class ExplodeTile : MonoBehaviour
{

    // This is the player the object is going to move towards
    public Enums.Players targetPlayer = Enums.Players.Player;

    public const string k_Key = "exploded";

    public TileBase m_Border;
    public TileBase m_ExplodedFloor;
    public GameObject m_Explosion;
    public GameObject m_Cannonballs;
    public Transform playerTransform;
    public Transform CannonballsTransform;
    public Vector3 CannonballsPosition;
    public Vector3Int gridPos2;

    private Grid m_Grid;
    private Tilemap m_ForeGround;
    private Tilemap m_Kivet;
    private Tilemap m_SoilGround;
    private GridInformation m_Info;

   
   public bool digKivet = false;
   public bool buttonPressed = false;
    public bool exptrigger = false;

   public Vector3Int gridPos;
    Animator animator;

   

    // Use this for initialization
    void Start()
    {
        animator = GetComponentInChildren<Animator>(); // ei ehkä tarvita
        m_Grid = GameObject.Find("Grid1").GetComponent<Grid>();
        m_Info = m_Grid.GetComponent<GridInformation>();
        m_Kivet = GameObject.Find("Kivet").GetComponent<Tilemap>();
        //m_Cannonballs = GameObject.Find("Cannonballs");
        //CannonballsTransform = m_Cannonballs.transform;
        CannonballsTransform = this.transform;
        //playerTransform = GameObject.FindGameObjectWithTag(targetPlayer.ToString()).transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {



        // Vector3 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CannonballsPosition = this.transform.position;
        Vector3 world = Camera.main.ScreenToWorldPoint(this.CannonballsPosition);
        gridPos = m_Grid.WorldToCell(world);

            
          
                
                //m_Cannonballs.SendMessage("Stop");
                //digKivet = false;
               
           
            {
                digKivet = true; buttonPressed = true; 
               // m_Cannonballs.SendMessage("Stop");
               
            }
            //else
            //m_Cannonballs.SendMessage("Nostop");
            
           
       // else
        

        {
            
            //Vector3 world2 = Camera.main.ScreenToWorldPoint(m_Cannonballs.GetComponent<Rigidbody2D>().position);              //.GetComponent(position)); //
            CannonballsPosition = this.transform.position;
            //Vector3 world2 = Camera.main.ScreenToWorldPoint(playerTransform.position);
            //Vector3 world2 = Camera.main.ScreenToWorldPoint(CannonballsPosition);
            Vector3 world2 = CannonballsPosition;
            
            gridPos2 = m_Grid.WorldToCell(world2);
            //System.Diagnostics.Debug.WriteLine("Bridge "); EI TOIMI EIKÄ SEURAAVA
            //Assert.AreEqual("Whatever " + Input.mousePosition.x.ToString(), Input.mousePosition.x.ToString(), " OMG! Whatever is not equal to numHerb!");
            //ExplodeCell(gridPos);

            //UnityEngine.Debug.Log("Cannonballs.x " + CannonballsPosition.x.ToString()); //TÄMÄ TOIMII
            //UnityEngine.Debug.Log("world2.x " + world2.x.ToString()); //TÄMÄ TOIMII
            //UnityEngine.Debug.Log("gridPos2.x " + gridPos2.x.ToString());

           // if (true) {
               // exptrigger = false;
               // ExplodeCell(gridPos2);
            }
        }

       // System.Diagnostics.Debug.WriteLine("Bridge ");
        
    
public void Explodeit()
{
    ExplodeCell(gridPos2);

}

    public void ExplodeCell(Vector3Int position)
    {
        m_Info.ErasePositionProperty(position, k_Key);
        m_Info.SetPositionProperty(position, k_Key, 1);
        //if (m_ForeGround.GetTile(position) == null && m_Kivet.GetTile(position) != null  && digKivet)
        {
            
            ExplodeKivet(position);
            Explode(position);
            return;
        }
}

   

    public void ExplodeKivet(Vector3Int position)
{
    m_Kivet.SetTile(position, null);
}

    


    public void Explode(Vector3Int position)
    { 
        //GameObject.Instantiate(m_Explosion, m_Grid.CellToLocalInterpolated(position + new Vector3(0.5f, 0.5f)), Quaternion.identity);
        //explosion here!
        return;
	}
}
