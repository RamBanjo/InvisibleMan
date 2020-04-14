using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gmInstance;

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

    public static void Win() {
        s_winUI.SetActive(true);
    }

    private void Awake() {
        gmInstance = this;
        winUI.SetActive(false);
    }

    public enum Items {
        NONE, FLOUR, NET, PAINT
    }

}
