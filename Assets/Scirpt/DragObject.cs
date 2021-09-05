using UnityEngine;

public class DragObject : MonoBehaviour
{
    [SerializeField] private string dragTag;

    public bool touched { get; private set; }
    public bool dragging { get; private set; }

    private float posX, posY;
    private Transform toDrag;
    private Rigidbody toDragRB;
    private Vector3 prevPos, thisPos;
    private Camera cam;

    BTN_Controller btnControl;
    StoryControllerStage1 story1;
    StoryControllerStage3 story3;


    private void Awake()
    {
        touched = false;
        dragging = false;

        if (cam == null)
            cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();


    }

    private void Start()
    {
        GameObject _gamemanager = GameObject.Find("GameManager");

        btnControl = _gamemanager.GetComponent<BTN_Controller>();

        if(Save.GetCurrentLevel("Level") == 1)
            story1 = _gamemanager.GetComponent<StoryControllerStage1>();
        else if (Save.GetCurrentLevel("Level") == 3)
            story3 = _gamemanager.GetComponent<StoryControllerStage3>();

    }

    private void FixedUpdate()
    {
        //If Touch = null
        if (Input.touchCount != 1)
        {
            touched = false;
            dragging = false;

            if (toDragRB)
                SetNotDragingPorperties(toDragRB);

            return;
        }

        Touch touch = Input.touches[0];

        if (btnControl.taskPanelIsActive == false && btnControl.settingPanelIsActive == false)
        {
            //touched        
            if (touch.phase == TouchPhase.Began)
                Touching(touch);

            //Dragging
            if (touched = true && touch.phase == TouchPhase.Moved)
                Dragging();

            //touched Canceled
            if (dragging = true && touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
                StopDragging();
        }

    }

    #region Actions

    private void Touching(Touch touch)
    {
        Vector3 touchPos = touch.position;
        Ray raycastTouch = cam.ScreenPointToRay(touchPos);
        RaycastHit hit;

        if (Physics.Raycast(raycastTouch, out hit) && hit.collider.tag == dragTag)
        {
            toDrag = hit.transform;
            prevPos = toDrag.position;

            toDragRB = toDrag.GetComponent<Rigidbody>();
            thisPos = cam.WorldToScreenPoint(prevPos);
            posX = Input.GetTouch(0).position.x - thisPos.x;
            posY = Input.GetTouch(0).position.y - thisPos.y;

            SetDraggingPorperties(toDragRB);
            touched = true;

            if (Physics.Raycast(raycastTouch, out hit) && hit.collider.gameObject.name == "SampleA")
                story3.IfSampleA();
            else if (Physics.Raycast(raycastTouch, out hit) && hit.collider.gameObject.name == "SampleB")
                story3.IfSampleB();

            Debug.Log("Touched " + touched + " Dragging " + dragging);

        }

        if (btnControl.isPanelON == false)
        {
            if (Physics.Raycast(raycastTouch, out hit) && hit.collider.tag == "BahanStage1Bener")
            {

                //Aquades
                if (Physics.Raycast(raycastTouch, out hit) && hit.collider.gameObject == story1.objBenar[0])
                    story1.Benar(0);

                //Medium
                if (Physics.Raycast(raycastTouch, out hit) && hit.collider.gameObject == story1.objBenar[1])
                    story1.Benar(1);

                //Arloji Glass
                if (Physics.Raycast(raycastTouch, out hit) && hit.collider.gameObject == story1.objBenar[2])
                    story1.Benar(2);

                //Erlenmayer
                if (Physics.Raycast(raycastTouch, out hit) && hit.collider.gameObject == story1.objBenar[3])
                    story1.Benar(3);

                //Spatula
                if (Physics.Raycast(raycastTouch, out hit) && hit.collider.gameObject == story1.objBenar[4])
                    story1.Benar(4);

                //PipetUkur
                if (Physics.Raycast(raycastTouch, out hit) && hit.collider.gameObject == story1.objBenar[5])
                    story1.Benar(5);

                //TabungUkur
                if (Physics.Raycast(raycastTouch, out hit) && hit.collider.gameObject == story1.objBenar[6])
                    story1.Benar(6);

                //TabungReaksi dan Tabung Durham
                if (Physics.Raycast(raycastTouch, out hit) && hit.collider.gameObject == story1.objBenar[7])
                    story1.Benar(7);
            }

            if (Physics.Raycast(raycastTouch, out hit) && hit.collider.tag == "BahanStage1Salah")
            {
                //1
                if (Physics.Raycast(raycastTouch, out hit) && hit.collider.gameObject == story1.objSalah[0])
                    story1.Salah();

                //2
                if (Physics.Raycast(raycastTouch, out hit) && hit.collider.gameObject == story1.objSalah[1])
                    story1.Salah();

                //3
                if (Physics.Raycast(raycastTouch, out hit) && hit.collider.gameObject == story1.objSalah[2])
                    story1.Salah();

                //4
                if (Physics.Raycast(raycastTouch, out hit) && hit.collider.gameObject == story1.objSalah[3])
                    story1.Salah();

                //5
                if (Physics.Raycast(raycastTouch, out hit) && hit.collider.gameObject == story1.objSalah[4])
                    story1.Salah();
            }

        }

    }

    private void Dragging() 
    {
        dragging = true;
        float newPosX = Input.GetTouch(0).position.x - posX;
        float newPosY = Input.GetTouch(0).position.y - posY;
        Vector3 newPos = new Vector3(newPosX, newPosY, thisPos.z);

        Vector3 worldPos = cam.ScreenToWorldPoint(newPos) - prevPos;
        worldPos = new Vector3(worldPos.x, worldPos.y, 0f);

        toDragRB.velocity = worldPos / (Time.deltaTime * 10);

        prevPos = toDrag.position;
        Debug.Log("Touched " + touched + " Dragging " + dragging);
    }        

    private void StopDragging()
    {
        dragging = false;
        touched = false;

        prevPos = new Vector3(0f, 0f, 0f);
        SetNotDragingPorperties(toDragRB);
        Debug.Log("Touched " + touched + " Dragging " + dragging);
    }
    #endregion

    #region RigidBody_Property
    private void SetDraggingPorperties (Rigidbody rb)
    {
        rb.useGravity = false;
        rb.drag = 8;

    }

    private void SetNotDragingPorperties(Rigidbody rb)
    {
        rb.useGravity = true;
        rb.drag = 5;

    }
    #endregion

}
