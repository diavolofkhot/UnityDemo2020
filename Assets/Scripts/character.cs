using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour
{
    //[SerializeField] private
    //public AudioClip walkClip;
    private AudioSource audioSource;
    public Light sunlight;
    public Light bulb;
    public CanvasGroup sky;
    public bed Bed;
    public Fridge fridge;
    public float m_WalkSpeed;
    //[SerializeField] private 
    public float m_StickToGroundForce;
    public bool isMoving = false, isCoding = false, isSleeping = false, isWashing = false,
        isBlack=false,cleanNumChange=false,toMove=false,isOpeningFridge=false,hungerNumChange=false,
        moneyNumChange=false,sleepChange=false,ableToEat=false, ableToWash = false, ableToWork = false;
    private Vector2 m_Input;
    private Vector3 m_MoveDir = Vector3.zero;
    private Animator Animator;
    private CollisionFlags m_CollisionFlags;
    private CharacterController m_CharacterController;
    private Light selfLight;

    //public float hunger;
    public  BarsController barsController;
    public float hunngerIncrease = 20.0f;
    //public float clean;
    public float cleanIncrease = 20.0f;
    public float money;
    protected CanvasGroup canvas;

    //private Transform oldTransform;
    private Vector3 oldPosition;
    private Quaternion oldRotation;
    // Start is called before the first frame update
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        Animator = GetComponent<Animator>();
        selfLight = GetComponentInChildren<Light>();
        sky.alpha = 0;
        //oldTransform = transform;
        oldPosition = transform.position;
        oldRotation = transform.rotation;
        canvas = GetComponentInChildren<CanvasGroup>();
        canvas.alpha = 0;
        audioSource = GetComponent<AudioSource>();
        //audioSource.clip = walkClip;
    }

    // Update is called once per frame
    void Update()
    {
        handleAnimator();
        //Debug.Log("oldTransform:  " + oldPosition);
        if (isSleeping || isCoding||isWashing||isOpeningFridge) return;
        //Debug.Log(donDestroy.don.days.pay.activeSelf);
        if (donDestroy.don.days.pay.activeSelf)return;
        getInput();
        handleMovements();
        
    }
    void handleAnimator()
    {
        if (isMoving)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else audioSource.Stop();
        Animator.SetBool("toMove", toMove);
        Animator.SetBool("isMoving", isMoving);
        Animator.SetBool("isCoding", isCoding);
        Animator.SetBool("isSleeping", isSleeping);
        Animator.SetBool("isOpeningFridge", isOpeningFridge);
    }

    void getInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Mathf.Abs(horizontal - 0) >= 0.001 || Mathf.Abs(vertical - 0) >= 0.001)
        {
            //if (!isMoving)
            //{
            //    toMove = true;
            //    handleAnimator();
                isMoving = true;
            //    toMove = false;
            //}
        }
        else isMoving = false;

        m_Input = new Vector2(horizontal, vertical);
        //m_Input = new Vector2(-vertical, horizontal);
    }
    void handleMovements()
    {
        if (isCoding || isSleeping) return;
        //Vector3 desiredMove = transform.forward * m_Input.y + transform.right * m_Input.x;
        Vector3 desiredMove = Vector3.forward * m_Input.x + Vector3.right * (-m_Input.y);
        //Vector3 desiredMove = transform.up * m_Input.y + transform.right * m_Input.x;

        // get a normal for the surface that is being touched to move along it
        //RaycastHit hitInfo;
        //Physics.SphereCast(transform.position, m_CharacterController.radius, Vector3.down, out hitInfo,
        //                   m_CharacterController.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
        //desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

        m_MoveDir.x = desiredMove.x * m_WalkSpeed;
        m_MoveDir.z = desiredMove.z * m_WalkSpeed;


        //if (m_CharacterController.isGrounded)
        {
            m_MoveDir.y = -m_StickToGroundForce;

            //if (m_Jump)
            //{
            //    m_MoveDir.y = m_JumpSpeed;
            //    PlayJumpSound();
            //    m_Jump = false;
            //    m_Jumping = true;
            //}
        }
        //else
        //{
        //    m_MoveDir += Physics.gravity * m_GravityMultiplier * Time.fixedDeltaTime;
        //}
        Vector3 rotation = transform.localEulerAngles;
        if (m_Input.x > 0)
        {
            rotation.y = 0.0f;
        }
        if (m_Input.x < 0)
        {
            rotation.y = 180.0f;
        }
        if (m_Input.y > 0)
        {
            rotation.y = -90.0f;
        }
        if (m_Input.y < 0)
        {
            rotation.y = 90.0f;
        }
        transform.rotation = Quaternion.Euler(rotation);
        if (m_CharacterController.enabled)
            m_CollisionFlags = m_CharacterController.Move(m_MoveDir * Time.fixedDeltaTime);
        //transform.position += m_MoveDir * Time.fixedDeltaTime;


    }
    //IEnumerator colliderWithTable(ControllerColliderHit hit)
    //{
    //    float timeClip = 0.3f;
    //    isCoding = true;
    //    //handleAnimator();
    //    Animator.SetBool("isCoding", true);
    //    m_CharacterController.enabled = false;
    //    transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
    //    transform.position = hit.transform.position + new Vector3(-0.2f, -0.7f, -2.5f);
    //    for (int i = 0; i < 10; i++) yield return new WaitForSeconds(timeClip);
    //    //
    //    m_CharacterController.enabled = true;
    //    transform.rotation = oldTransform.rotation;
    //    transform.position = oldTransform.position;
    //    isCoding = false;
    //    Animator.SetBool("isCoding", false);
    //    //
    //    yield return true;
    //}
    //IEnumerator colliderWithBed(ControllerColliderHit hit)
    //{
    //    float timeClip = 0.3f;
    //    //Bed.sleep = true;
    //    Bed.pressed = true;
    //    isSleeping = true;
    //    //handleAnimator();
    //    Animator.SetBool("isSleeping", true);
    //    m_CharacterController.enabled = false;
    //    transform.rotation = Quaternion.Euler(new Vector3(0.0f, 90.0f, 0.0f));
    //    transform.position = hit.transform.position + new Vector3(0.2f, -2.3f, 0.0f);
    //    for (int i = 0; i < 10; i++) yield return new WaitForSeconds(timeClip);
    //    //
    //    //Bed.sleep = false;
    //    Bed.pressed = false;
    //    m_CharacterController.enabled = true;
    //    transform.rotation = oldTransform.rotation;
    //    transform.position =oldTransform.position+new Vector3(2.0f,0.0f,0.0f);
    //    isSleeping = false;
    //    Animator.SetBool("isSleeping", false);
    //    //
    //    yield return true;
    //}
    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.collider.tag == "Table" && Input.GetKeyDown(KeyCode.Space))
    //    {
    //        if (!isCoding)
    //        {
    //            //handleAnimator();
    //            isCoding = true;
    //            oldTransform = transform;
    //            StartCoroutine(colliderWithTable(hit));
    //        }

    //    }
    //    else if(hit.collider.tag == "Bed"/*&&Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Debug.Log("bed");
    //        if (!isSleeping)
    //        {
    //            //handleAnimator();
    //            isSleeping = true;
    //            oldTransform = transform;
    //            StartCoroutine(colliderWithBed(hit));
    //        }

    //    }
    //}
    IEnumerator warning(int num)
    {
        
        Text text = GetComponentInChildren<Text>();
        //Debug.Log("warning"+text.name);
        if (num == 1)
        {
            text.text = "饱食度或清洁度太低！";
           
        } else text.text = "精力不足！";
        float timeClip = 0.1f;
        canvas.alpha = 1;
        for (int i = 0; i < 10; i++) yield return new WaitForSeconds(timeClip);
        canvas.alpha = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        if (isSleeping || isCoding) return;
        if (other.tag == "Table" && Input.GetKeyDown(KeyCode.Space))
        {
            if (!ableToWork)
            {
                StartCoroutine(warning(2));
                return;
            }
            if (barsController.bars[0].value < 0.3 || barsController.bars[0].value < 0.3)
            {
                StartCoroutine(warning(1));
                return;
            }
            if (!isCoding)
            {
                //handleAnimator();
                isCoding = true;
                //oldTransform = transform;
                oldPosition = transform.position;
                oldRotation = transform.rotation;
                StartCoroutine(colliderWithTable(other));
            }

        }
        else if (other.tag == "Bed" && Input.GetKeyDown(KeyCode.Space))
        {
            if (!isSleeping)
            {
                //handleAnimator();
                isSleeping = true;
                //oldTransform.position = transform.position;
                //oldTransform.rotation = transform.rotation;
                oldPosition = transform.position;
                oldRotation = transform.rotation;
                StartCoroutine(colliderWithBed(other));
            }

        }
        else if (other.tag == "Washroom" && Input.GetKeyDown(KeyCode.Space))
        {
            if (!ableToWash)
            {
                StartCoroutine(warning(2));
                return;
            }
            if (!isWashing)
            {
                //handleAnimator();
                isWashing = true;
                //oldTransform.position = transform.position;
                //oldTransform.rotation = transform.rotation;
                oldPosition = transform.position;
                oldRotation = transform.rotation;
                StartCoroutine(colliderWithWashroom(other));
            }

        }
        else if (other.tag == "Fridge" && Input.GetKeyDown(KeyCode.Space))
        {
            if (!ableToEat)
            {
                StartCoroutine(warning(2));
                return;
            }
            if (!isOpeningFridge)
            {
                //handleAnimator();
                isOpeningFridge = true;
                //oldTransform.position = transform.position;
                //oldTransform.rotation = transform.rotation;
                oldPosition = transform.position;
                oldRotation = transform.rotation;
                StartCoroutine(colliderWithFridge(other));
            }

        }
    }
    IEnumerator colliderWithTable(Collider other)
    {
        float timeClip = 0.2f;
        isMoving = false;
        isCoding = true;
        //handleAnimator();
        Animator.SetBool("isCoding", true);
        m_CharacterController.enabled = false;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
        transform.position = other.transform.position + new Vector3(-0.2f, -0.7f, -2.5f);
        for (int i = 0; i < 10; i++) yield return new WaitForSeconds(timeClip);
        //
        moneyNumChange = true;
        m_CharacterController.enabled = true;
        //transform.rotation = oldTransform.rotation;
        //transform.position = oldTransform.position;
        transform.position=oldPosition;
        transform.rotation=oldRotation;
        isCoding = false;
        Animator.SetBool("isCoding", false);
        //s
        yield return true;
    }
    IEnumerator colliderWithFridge(Collider other)
    {
        float timeClip = 0.2f;
        isMoving = false;
        isOpeningFridge = true;
        fridge.pressed = true;
        fridge.opened = true;
        fridge.animator.SetBool("opened", fridge.opened);
        handleAnimator();
        fridge.opening = true;
        
        //m_CharacterController.enabled = false;
        //
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, -90.0f, 0.0f));
        transform.position = other.transform.position + new Vector3(3.2f, -1.5f, -0.6f);
        
        for (int i = 0; i < 10; i++) yield return new WaitForSeconds(timeClip);

        //
        hungerNumChange = true;
        fridge.opening = false;
        fridge.opened = false;
        transform.position = oldPosition + new Vector3(0.0f, 0.0f, 0.0f);
        transform.rotation = oldRotation;
        m_CharacterController.enabled = true;
        isOpeningFridge = false;
        //
        yield return true;
    }
    IEnumerator colliderWithBed(Collider other)
    {
        float timeClip = 0.2f;
        //Bed.sleep = true;
        //
        Bed.pressed = true;
        isMoving = false;
        isSleeping = true;
        Animator.SetBool("isSleeping", true);
        selfLight.enabled = false;
        m_CharacterController.enabled = false;
        //
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 90.0f, 0.0f));
        transform.position = other.transform.position + new Vector3(0.2f, -2.3f, 0.0f);
        //for (int i = 0; i < 10; i++) yield return new WaitForSeconds(timeClip);
        float gapNum=20;
        for (int i = 0; i < gapNum; i++)
        {
            float inten1 = sunlight.intensity, inten2 = bulb.intensity;
            inten1 /= gapNum; inten2 /= gapNum;
            sunlight.intensity -= inten1;
            bulb.intensity -= inten2;
            sky.alpha += (float)(1/ gapNum);
            yield return new WaitForSeconds(1.5f/ gapNum);
        }
        isBlack = true;
        sleepChange = true;
        for (int i = 0; i < 10; i++) yield return new WaitForSeconds(timeClip);
        isBlack = false;
        for (int i = 0; i < gapNum; i++)
        {
            float inten1 = sunlight.intensity, inten2 = bulb.intensity;
            inten1 /= gapNum; inten2 /= gapNum;
            sunlight.intensity += inten1;
            bulb.intensity += inten2;
            sky.alpha -= (float)(1/ gapNum);
            yield return new WaitForSeconds(1.5f/ gapNum);
        }
        //
        //Bed.sleep = false;
        selfLight.enabled = true;
        transform.position = oldPosition+ new Vector3(0.0f, 0.0f, 0.0f);
        transform.rotation = oldRotation ;
        m_CharacterController.enabled = true;
        isSleeping = false;
        //
        //for (int i = 0; i < 10; i++) yield return new WaitForSeconds(0.2f);
        //Bed.pressed = false;
        //
        Animator.SetBool("isSleeping", false);
        //
        yield return true;
    }
    IEnumerator colliderWithWashroom(Collider other)
    {
        float timeClip = 0.2f;
        isMoving = false;
        isWashing = true;
        m_CharacterController.enabled = false;
        selfLight.enabled = false;
        //
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 90.0f, 0.0f));
        transform.position = other.transform.position + new Vector3(-3.0f, 0.0f, -1.5f);
        for (int i = 0; i < 10; i++) yield return new WaitForSeconds(timeClip);
        //
        cleanNumChange = true;
        //yield return new WaitForSeconds(0.3f);
        transform.position = oldPosition + new Vector3(0.0f, 0.0f, 0.0f);
        transform.rotation = oldRotation;
        selfLight.enabled = true;
        //for (int i = 0; i < 10; i++) yield return new WaitForSeconds(timeClip);
        m_CharacterController.enabled = true;
        
        isWashing = false;
        //
        yield return true;
    }
}
