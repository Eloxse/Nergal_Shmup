using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Controller : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public float moveSpeed = 50f;
    public float dragLerpMultiplier;
    public float xMax, zMax;
    public float dragOffsetZ;
    public bool useClamp = true;

    public AudioSource fireRateSound;
    public AudioSource coinSound;
    public AudioSource shieldSound;
    public AudioSource bombSound;

    private bool _isDragging = false;

    private Camera _cam;
    private GameManager _gm;
    private Health_Controller _hc;
    private Player_Input _inputs;
    private PointerEventData _lastData;
    private Vector3 _wantedPos;

    void Start()
    {
        _inputs = GetComponent<Player_Input>();
        _hc = GetComponent<Health_Controller>();

        _cam = Camera.main;
        _gm = GameManager.instance;
    }

    void Update()
    {
        Move();
    }

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Collectable")){
            switch(other.gameObject.tag){
                case "Coin" :
                    coinSound.Play();
                    Destroy(other.gameObject);
                    _gm.AddCoins();
                    break;
                case "PowerUp_FireRate" :
                    fireRateSound.Play();
                    Destroy(other.gameObject);
                    StartCoroutine(GetComponent<Player_Shoot>().UpgradeFireRate());
                    break;
                case "PowerUp_Shield" :
                    shieldSound.Play();
                    Destroy(other.gameObject);
                    _hc.GetComponent<Health_Controller>().ActiveShield();
                    break;
                case "PowerUp_Bomb" :
                    bombSound.Play();
                    Destroy(other.gameObject);
                    _hc.GetComponent<Health_Controller>().ActiveDamageArea();
                    break;
                default :
                    Debug.Log("Nothing to pick up...");
                    break;
            }
        }
    }

    void Move(){
        _wantedPos = transform.position;

        if(_lastData != null && _isDragging){
            RaycastHit hit;

            if(Physics.Raycast(_cam.ScreenPointToRay(_lastData.position), out hit, 300, 1<<31)){
                _wantedPos = Vector3.Lerp(transform.position, hit.point + Vector3.forward * dragOffsetZ, Time.deltaTime * dragLerpMultiplier);
            }
        }else{
            _wantedPos = transform.position + (Vector3.right * _inputs.horizontal + Vector3.forward * _inputs.vertical).normalized * moveSpeed * Time.deltaTime;
        }

        if(useClamp){
            _wantedPos.x = Mathf.Clamp(_wantedPos.x, _cam.transform.position.x - xMax, _cam.transform.position.x + xMax);
            _wantedPos.z = Mathf.Clamp(_wantedPos.z, _cam.transform.position.z - zMax, _cam.transform.position.z + zMax);
        }

        transform.position =_wantedPos;
    }

    public void OnBeginDrag(PointerEventData eventData){
        _lastData = eventData;
    }

    public void OnEndDrag(PointerEventData eventData){
        _lastData = eventData;
    }

    public void OnDrag(PointerEventData eventData){
        _lastData = eventData;
    }

    public void OnPointerDown(PointerEventData eventData){
        _lastData = eventData;
        _isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData){
        _lastData = eventData;
        _isDragging = false;
    }
}