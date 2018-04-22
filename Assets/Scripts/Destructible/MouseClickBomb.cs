using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
//using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Tilemaps;

public class MouseClickBomb : MonoBehaviour
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

    private Grid m_Grid;
    private Tilemap m_ForeGround;
    private Tilemap m_Kivet;
    private Tilemap m_SoilGround;
    private GridInformation m_Info;

    //public GameObject m_Button1;

   public bool digForeground = false;
   public bool digKivet = false;
   public bool digSoilground = false;
   public bool buttonPressed = false;

   public Vector3Int gridPos;

    // Use this for initialization
    void Start()
    {
        m_Grid = GetComponent<Grid>();
        m_Info = GetComponent<GridInformation>();
        m_ForeGround = GameObject.Find("Foreground").GetComponent<Tilemap>();
        m_Kivet = GameObject.Find("Kivet").GetComponent<Tilemap>();
        m_SoilGround = GameObject.Find("Soilground").GetComponent<Tilemap>();
        m_Cannonballs = GameObject.Find("Cannonballs");
        CannonballsTransform = m_Cannonballs.transform;
        playerTransform = GameObject.FindGameObjectWithTag(targetPlayer.ToString()).transform;
        //m_Button1 = GameObject.Find("Button1");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //if (m_Grid && Input.GetMouseButtonDown(0))
        {
            //if (m_Button1.
            //buttonPressed = false;
            //digForeground = false;
            //digKivet = false;
            //digSoilground = false;

            Vector3 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gridPos = m_Grid.WorldToCell(world);

            //UnityEngine.Debug.Log("gridPos.x " + gridPos.x.ToString());
            //UnityEngine.Debug.Log("gridPos.y " + gridPos.y.ToString());

            if (gridPos.x == 7 && gridPos.y == 2)
            {
                digForeground = true; buttonPressed = true; //m_Cannonballs.transform.position = new Vector3Int(0, 0, 0);
                m_Cannonballs.SendMessage("Stop");
                //digForeground = false;
                //digKivet = false;
                digSoilground = false;
            }
            //else
            //  m_Cannonballs.SendMessage("Nostop");
           // if (gridPos.x == 7 && gridPos.y == 1)
            {
                digKivet = true; buttonPressed = true; //m_Cannonballs.transform.position = new Vector3Int(0, 0, 0);
                m_Cannonballs.SendMessage("Stop");
                digForeground = false;
                //digKivet = false;
                digSoilground = false;
            }
            //else
            //m_Cannonballs.SendMessage("Nostop");
            if (gridPos.x == 7 && gridPos.y == 0)
            {
                digSoilground = true; buttonPressed = true; //m_Cannonballs.transform.position = new Vector3Int(0, 0, 0);
                m_Cannonballs.SendMessage("Stop");
                digForeground = false;
                //digKivet = false;
                //digSoilground = false;
            }
            //else
            // m_Cannonballs.SendMessage("Nostop");

            if (gridPos.x == 7 && gridPos.y == -1)
            {
                buttonPressed = true;
                digForeground = false;
                //digKivet = false;
                digSoilground = false;
                m_Cannonballs.transform.position = new Vector3Int(0, 0, 0);
                m_Cannonballs.SendMessage("Stop");
            }
            // else
            //    m_Cannonballs.SendMessage("Nostop");

        }
       // else
        {
            buttonPressed = false;
            //if (gridPos == m_Cannonballs.transform.position)
            //{
             m_Cannonballs.SendMessage("Nostop");
            //}
        }

        if (gridPos == m_Cannonballs.transform.position)
        {
            m_Cannonballs.SendMessage("Nostop");
            buttonPressed = false;
        }

        {
            
            //Vector3 world2 = Camera.main.ScreenToWorldPoint(m_Cannonballs.GetComponent<Rigidbody2D>().position);              //.GetComponent(position)); //
            CannonballsPosition = m_Cannonballs.transform.position;
            //Vector3 world2 = Camera.main.ScreenToWorldPoint(playerTransform.position);
            //Vector3 world2 = Camera.main.ScreenToWorldPoint(CannonballsPosition);
            Vector3 world2 = CannonballsPosition;
            
            Vector3Int gridPos2 = m_Grid.WorldToCell(world2);
            //System.Diagnostics.Debug.WriteLine("Bridge "); EI TOIMI EIKÄ SEURAAVA
            //Assert.AreEqual("Whatever " + Input.mousePosition.x.ToString(), Input.mousePosition.x.ToString(), " OMG! Whatever is not equal to numHerb!");
            //ExplodeCell(gridPos);

            //UnityEngine.Debug.Log("Cannonballs.x " + CannonballsPosition.x.ToString()); //TÄMÄ TOIMII
            //UnityEngine.Debug.Log("world2.x " + world2.x.ToString()); //TÄMÄ TOIMII
            //UnityEngine.Debug.Log("gridPos2.x " + gridPos2.x.ToString());

            if (!buttonPressed) {
                ExplodeCell(gridPos2);
            }
        }

       // System.Diagnostics.Debug.WriteLine("Bridge ");
        
    }

    public void ExplodeCell(Vector3Int position)
    {
        /*
        if (m_ForeGround.GetTile(position) == m_Border)
            return;
            */

        m_Info.ErasePositionProperty(position, k_Key);
        m_Info.SetPositionProperty(position, k_Key, 1);
        if (m_ForeGround.GetTile(position) != null && digForeground)
        {
            ExplodeForeground(position); 
            Explode(position);
            return;
        }

        m_Info.ErasePositionProperty(position, k_Key);
        m_Info.SetPositionProperty(position, k_Key, 1);
        if (m_ForeGround.GetTile(position) == null && m_Kivet.GetTile(position) != null  && digKivet)
        {
            
            ExplodeKivet(position);
            Explode(position);
            return;
        }

        m_Info.ErasePositionProperty(position, k_Key);
        m_Info.SetPositionProperty(position, k_Key, 1);
        if (m_ForeGround.GetTile(position) == null && m_Kivet.GetTile(position) == null  && m_SoilGround.GetTile(position) != null && digSoilground)
        {
            ExplodeSoilground(position);
            Explode(position);
            return;
        } 
}

    public void ExplodeForeground(Vector3Int position)
{
    m_ForeGround.SetTile(position, null);
}

    public void ExplodeKivet(Vector3Int position)
{
    m_Kivet.SetTile(position, null);
}

    public void ExplodeSoilground(Vector3Int position)
    {
       m_SoilGround.SetTile(position, null);
    }


    public void Explode(Vector3Int position)
    { 
        GameObject.Instantiate(m_Explosion, m_Grid.CellToLocalInterpolated(position + new Vector3(0.5f, 0.5f)), Quaternion.identity);
        return;
	}
}
