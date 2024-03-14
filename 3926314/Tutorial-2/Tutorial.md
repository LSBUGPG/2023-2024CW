# Basic Weapon System In Unity

This tutorial shows how to create an easily expandable weapon system in Unity.

## 1. Set up scene

Under your player create a new game object and call it `Gun`, this will act as the object that we use to contain all of the logic of the weapon script.

Now create a new layer and call it `Enemy`, this will act as the enemy layer so the weapon can identify what the targets are.

## 2. Create weapon script

Under your scripts folder create a new script and call it `GunSystem`.

### Refrences

In this script we need to create the variales to control the properties of the gun:

```.cs
    public float timeBetweenShooting;
    public float spread;
    public float range;
    public float reloadTime;
    public float timeBetweenShots;
    public int magazineSize;
    public int bulletsPerTap;
    public bool allowButtonHold;
    private int _bulletsLeft, _bulletsShot;
```

These variables control the variables such as bullet spread, range, reload and fire rate.

Now we need to create some variaes for the refrences we could need for the script:

```.cs
    public Camera fpsCam;
    public LayerMask whatIsEnemy;
```

These give us the camera that we can shoot the raycast from and the layer mask to identify if what we hit was an enemy or not.

The last variables we need are private for the purposes of the script:

```.cs
    private RaycastHit _rayHit;
    private bool _shooting, _readyToShoot, _reloading;
```

### Awake Function

```.cs
    private void Awake()
    {
        _bulletsLeft = magazineSize;
        _readyToShoot = true;
    }
```

In the awake function we need to set the `_bulletsLeft` equal to the `magazineSize` so we can start with the right amount of ammo.

We also need to set our `_readyToShoot` variable to true so we can be able to shoot.

### Update Function

```.cs
    private void Update()
    {
        MyInput();
    }
```

In the update function we are only calling the input function as all of the logic is happening in there.

### Input Function

```.cs
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
```

In this function we are using an alternate if statement to check wether or not the player is holding down the shoot key and we store this as a bool `_shooting`.

Next we check if the player presses the R key to reload, we call the `Reload()` function if the player presses the key and the current amount of bullets is less than the size of the magazine and is also not already reloading.

The last statement checks if the player is allowed to shoot and if the `_shooting` variable is true as well as if we are not reloading and have bullets left in the magazine. If true,  we call the `Shoot()` function.

### Shoot Function

```.cs
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
```

In this shoot function we have to set the `_readyToShoot` variable to false so we cannot shoot while we are already shooting.

Next we generate 2 random numbers to act as the `x` and `y` values for the spread of the bullet, we then apply this to a `direction` variable which uses the camera forward transfrom and applies the spread.

Next we use a raycast to shoot out a ray using the `direction` variable out of the front of the camera with the given range and layer mask.

If we hit something in range with the enemy layer mask, for now all we do is output the name of the object that was hit into the console.

Now we have to reduce the amount of bullets in the magazine and call the `ResetShot()` function.

If we have given a value for more than 1 bullet to be shot with each click, we then call the `Shoot()` function again.

### Reset Shot Function

```.cs
    private void ResetShot()
    {
        _readyToShoot = true;
    }
```

Here we just reset our shot by making `_readyToShoot` true again.

### Reload Function

```.cs
    private void Reload()
    {
        _reloading = true;
        Invoke(nameof(ReloadFinished), reloadTime);
    }
```

In the `Reload()` function we set `_reloading` to true and call the `ReloadFinished()` function after the time of `reloadTime` has passed.

### Reload Finished Function

```.cs
    private void ReloadFinished()
    {
        _bulletsLeft = magazineSize;
        _reloading = false;
    }
```

Here we reset or current ammo to the capactity of the magazine and then set our `_reloading` variable to false as the reload has finished.

## 3. Finish set up in Unity

Now go back to unity and apply the script to your gun object and set the values to your choosing, make sure to set the layer mask to the enemy layer and the camera to the camera refrence and press play and you are done.
