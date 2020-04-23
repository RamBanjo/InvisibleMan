using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetCounterUI : MonoBehaviour
{

    public Text invisCounter;
    public Text stopCounter;
    public Text runnerCounter;
    public Text chaserCounter;

    // Start is called before the first frame update
    void Start()
    {
        NetProjectile.EnemyCapturedDelegate += UpdateBoard;
        UpdateBoard();

    }

    private void OnDestroy() {
        NetProjectile.EnemyCapturedDelegate -= UpdateBoard;
    }


    void UpdateBoard() {

        int invisNo = 0;
        int stopNo = 0;
        int runNo = 0;
        int chaseNo = 0;

        foreach(InvisibleMan im in GameManager.activeInvisibleMen) {
            if (!im.caught) {
                StopMan sm = im.GetComponent<StopMan>();
                EscapeMan em = im.GetComponent<EscapeMan>();
                ChasingMan cm = im.GetComponent<ChasingMan>();

                if(sm != null) {
                    stopNo++;
                }else if(em != null) {
                    runNo++;
                }else if(cm != null) {
                    chaseNo++;
                } else {
                    invisNo++;
                }
            }
        }

        invisCounter.text = invisNo + "";
        stopCounter.text = stopNo + "";
        runnerCounter.text = runNo + "";
        chaserCounter.text = chaseNo + "";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
