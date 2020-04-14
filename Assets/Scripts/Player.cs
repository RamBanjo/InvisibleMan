using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Person
{

    public Camera main_camera;
    private GameManager.Items currentItem;

    [HideInInspector]
    public Pickup hovering;

    public GameManager.Items CurrentItem { get => currentItem; set => ItemChangeDelegate(value); }

    //listener for change of item
    public delegate void CurrentItemChange(GameManager.Items value);
    public static event CurrentItemChange ItemChangeDelegate;

    public float throwSpeed;

    // Start is called before the first frame update
    void Start()
    {

        ItemChangeDelegate += SetCurrentItem;

    }

    private void OnDestroy() {

        ItemChangeDelegate -= SetCurrentItem;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //movement, get axis
        float vert = Input.GetAxis("Vertical") * speed;
        float horz = Input.GetAxis("Horizontal") * speed;

        vert *= Time.deltaTime;
        horz *= Time.deltaTime;

        //and then move the character
        transform.Translate(horz, vert, 0);

        if(Input.GetKeyDown(KeyCode.E)) {
            GetItem();
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            DropItem();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            UseItem();
        }
    }

    public void SetCurrentItem(GameManager.Items value) {
        currentItem = value;
    }

    private void GetItem() {

        if(CurrentItem == GameManager.Items.NONE) {
            CurrentItem = hovering.itemType;
            Destroy(hovering.gameObject);
        }
    }

    private void DropItem() {
        Instantiate(GameManager.s_gamePickups[(int)CurrentItem - 1], transform.position, transform.rotation);
        CurrentItem = GameManager.Items.NONE;
    }

    private void UseItem() {
        bool useSuccess = false;

        switch (CurrentItem) {
            case GameManager.Items.NONE:
                break;
            case GameManager.Items.FLOUR:
                Instantiate(GameManager.s_flourPatch, transform.position, transform.rotation);
                useSuccess = true;
                break;
            case GameManager.Items.NET:

                Vector2 here = transform.position;
                Vector2 mousePos = Input.mousePosition;
                mousePos = main_camera.ScreenToWorldPoint(mousePos);

                Vector2 rot = mousePos - here;

                float angle = Mathf.Atan2(rot.y, rot.x);

                Vector2 normal = rot.normalized;

                NetProjectile net = Instantiate(GameManager.s_netProjectile, here+(normal), transform.rotation);

                net.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.forward);
                net.rb2d.AddForce(net.transform.right * throwSpeed);

                useSuccess = true;

                break;
            case GameManager.Items.PAINT:
                break;
            default:
                break;
        }

        if (useSuccess) {
            CurrentItem = GameManager.Items.NONE;
        }
    }
}
