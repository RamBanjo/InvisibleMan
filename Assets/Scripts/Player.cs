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

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ItemChangeDelegate += SetCurrentItem;

    }

    private void OnDestroy() {

        ItemChangeDelegate -= SetCurrentItem;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //movement, get axis
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");

        Vector3 goHere = (new Vector2(horz, vert) * Time.deltaTime * speed);

        //and then move the character
        rb2d.MovePosition(transform.position + goHere);

        //transform.Translate(horz, vert, 0);

        if(Input.GetKeyDown(KeyCode.E)) {
            GetItem();
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            DropItem();
        }

        if (Input.GetMouseButton(0)) {
            UseItem();
        }
    }

    public void SetCurrentItem(GameManager.Items value) {
        currentItem = value;
    }

    private void GetItem() {

        if(CurrentItem == GameManager.Items.NONE && hovering != null) {
            CurrentItem = hovering.itemType;
            Destroy(hovering.gameObject);
            hovering = null;
        }
    }

    private void DropItem() {

        if(CurrentItem != GameManager.Items.NONE) {
            Instantiate(GameManager.s_gamePickups[(int)CurrentItem - 1], transform.position, transform.rotation);
            CurrentItem = GameManager.Items.NONE;
        }

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
