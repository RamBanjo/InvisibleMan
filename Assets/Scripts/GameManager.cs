using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static bool panic;
    public static bool gameOver;
    public static Player player;
    public static GameManager gmInstance;
    public static List<InvisibleMan> activeInvisibleMen;
    public static List<Waypoint> allWayPoints;

    [Tooltip("Should be in this order: Flour, Net, Paint, Alarm")]
    public List<Pickup> gamePickups;
    public FlourPatch flourPatch;
    public NetProjectile netProjectile;
    public PaintPuddle paintPuddle;
    public AlarmPoint alarmPoint;
    public GameObject winUI;
    public GameObject loseUI;
    

    public static List<Pickup> s_gamePickups {
        get {
            return gmInstance.gamePickups;
        }
    }

    public static FlourPatch s_flourPatch { get => gmInstance.flourPatch;}

    public static NetProjectile s_netProjectile { get => gmInstance.netProjectile; }

    public static PaintPuddle s_paintPuddle { get => gmInstance.paintPuddle; }

    public static AlarmPoint s_alarmPoint { get => gmInstance.alarmPoint; }

    public static GameObject s_winUI { get => gmInstance.winUI; }

    public static GameObject s_loseUI { get => gmInstance.loseUI; }

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
        gameOver = true;
    }

    public static void Lose() {
        s_loseUI.SetActive(true);
        gameOver = true;
    }

    private void Awake() {

        if(gmInstance == null) {
            gmInstance = this;
        } else {
            Destroy(this);
        }
        winUI.SetActive(false);
        loseUI.SetActive(false);
        panic = false;
        gameOver = false;

        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        activeInvisibleMen = new List<InvisibleMan>();

        GameObject[] invises = GameObject.FindGameObjectsWithTag("Invisible Man");
        foreach (GameObject go in invises) {
            activeInvisibleMen.Add(go.GetComponent<InvisibleMan>());
        }

        allWayPoints = new List<Waypoint>();

        GameObject[] waypointses = GameObject.FindGameObjectsWithTag("Waypoint");
        foreach (GameObject go in waypointses) {
            allWayPoints.Add(go.GetComponent<Waypoint>());
        }
        
    }

    private void Start() {
        NetProjectile.EnemyCapturedDelegate += CheckWin;
    }

    private void OnDestroy() {
        NetProjectile.EnemyCapturedDelegate -= CheckWin;
    }

    private void Update() {
        if (gameOver) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (Input.GetKeyDown(KeyCode.M)) {
                SceneManager.LoadScene("TitleScreen");
            }

            if (Input.GetKeyDown(KeyCode.Q)) {
                Application.Quit();
            }
        }
    }

    public enum Items {
        NONE, FLOUR, NET, PAINT, ALARM
    }

}
