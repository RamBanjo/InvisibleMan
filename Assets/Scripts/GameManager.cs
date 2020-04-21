using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gmInstance;
    public static List<InvisibleMan> activeInvisibleMen;
    public static List<Waypoint> allWayPoints;

    [Tooltip("Should be in this order: Flour, Net, Paint")]
    public List<Pickup> gamePickups;
    public FlourPatch flourPatch;
    public NetProjectile netProjectile;
    public GameObject winUI;
    

    public static List<Pickup> s_gamePickups {
        get {
            return gmInstance.gamePickups;
        }
    }
    public static FlourPatch s_flourPatch { get => gmInstance.flourPatch;}
    public static NetProjectile s_netProjectile { get => gmInstance.netProjectile; }

    public static GameObject s_winUI { get => gmInstance.winUI; }

    public static void CheckWin() {
        bool playerWon = true;

        foreach(InvisibleMan im in activeInvisibleMen) {
            playerWon = playerWon && im.caught;
        }

        if (playerWon) {
            Win();
        }
    }

    public static void Win() {
        s_winUI.SetActive(true);
    }

    private void Awake() {
        gmInstance = this;
        winUI.SetActive(false);
    }

    private void Start() {

        activeInvisibleMen = new List<InvisibleMan>();

        GameObject[] invises = GameObject.FindGameObjectsWithTag("Invisible Man");
        foreach(GameObject go in invises) {
            activeInvisibleMen.Add(go.GetComponent<InvisibleMan>());
        }

        allWayPoints = new List<Waypoint>();

        GameObject[] waypointses = GameObject.FindGameObjectsWithTag("Waypoint");
        foreach (GameObject go in waypointses) {
            allWayPoints.Add(go.GetComponent<Waypoint>());
        }
    }

    public enum Items {
        NONE, FLOUR, NET, PAINT
    }

}
