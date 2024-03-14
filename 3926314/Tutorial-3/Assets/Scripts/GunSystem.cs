using UnityEngine;
public class GunSystem : MonoBehaviour
{
    [Header("Weapon Stats")]
    public float timeBetweenShooting;
    public float spread;
    public float range;
    public float reloadTime;
    public float timeBetweenShots;
    public int magazineSize;
    public int bulletsPerTap;
    public bool allowButtonHold;
    private int _bulletsLeft, _bulletsShot;

    [Header("References")]
    public Camera fpsCam;
    public Transform attackPoint;
    public LayerMask whatIsEnemy;
    
    private RaycastHit _rayHit;
    private bool _shooting, _readyToShoot, _reloading;

    private void Awake()
    {
        _bulletsLeft = magazineSize;
        _readyToShoot = true;
    }
    
    private void Update()
    {
        MyInput();
    }
    
    private void MyInput()
    {
        _shooting = allowButtonHold ? Input.GetKey(KeyCode.Mouse0) : Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && _bulletsLeft < magazineSize && !_reloading) Reload();

        //Shooting mechanics
        if (_readyToShoot && _shooting && !_reloading && _bulletsLeft > 0){
            _bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    
    private void Shoot()
    {
        _readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(fpsCam.transform.position, direction, out _rayHit, range, whatIsEnemy))
        {
            Debug.Log(_rayHit.collider.name);
        }
        
        _bulletsLeft--;
        _bulletsShot--;

        Invoke(nameof(ResetShot), timeBetweenShooting);

        if(_bulletsShot > 0 && _bulletsLeft > 0)
            Invoke(nameof(Shoot), timeBetweenShots);
    }
    
    private void ResetShot()
    {
        _readyToShoot = true;
    }
    
    private void Reload()
    {
        _reloading = true;
        Invoke(nameof(ReloadFinished), reloadTime);
    }
    
    private void ReloadFinished()
    {
        _bulletsLeft = magazineSize;
        _reloading = false;
    }
}