# Enemy AI System Tutorial

This tutorial shows how to create an easily expandable AI enemy system in Unity.

## 1. Setup

Import the `AI Navigation` package via the package manager window

Create a cylinder to act as the enemy, this can always be changed later.

Create a layer called `Enemy` and apply it to your enemy object.

Next create an empty gameobject in the scene and call it `NavMesh`, on this object apply the `NavMeshSurface` component and bake the scene.

Now on the enemy object apply the `Nav Mesh Agent` component, the default values are fine.

## 2. Create AI Script

Under your scripts folder create a new script and call it `EnemyAI`

### Refrences

In this script we need to create the variales to control the properties of the AI:

```.cs
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
```

### Awake Function

```.cs
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
```

In the awake function if the variable `player` isnt already assigned, we search the scene to find the player's transform.

We then get the AI agent component that is on the enemy object.

### Update Function

```.cs
    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }
```

In the update function we check if the player is within any given ranges for chasing or attacking, if so we then call the respective functions.

### Patroling Function

```.cs
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
```

In this patroling function we check if we already have a walk destiantion, if not we call the `SearchWalkPoint()` function, otherwise we check our distance to the walkpoint and if it is 0, we then say that we no longer have a walk destination.

### Walk Point Function

```.cs
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
```

Here we just generate a random point using a specified range from the original start position, we then make sure that the point we have generated is on a ground by using a raycast as a ground check, if it is true then we set the points as the new walk destination.

### Chase Function

```.cs
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
```

Here we jsut set the destination of the AI to the position of the player.

### Attack Function

```.cs
    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
```

In this attack function, first we stop the enemy from moving then rotate the enemy to face the player.

Next, as an exapmple, we get the enemy to shoot a projectile at the player, this can be replaces with any form of attacking of your choice.

We then set `alreadyAttacked` to true and check if the `timeBetweenAttacks` has passed so we can then attack again after a given amount of time.

```.cs
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
```

Here we reset the attack after we have just attacked.

### Damage

```.cs
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
```

Here we reduce the `health` of the enemy.

```.cs
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
```

If the `health` is 0 we destroy the gameobject.

### Gizmos (Optional)

```.cs
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
```

This is optional but all we are doing is visualising the ranges in which the enemy chases and attacks.

## 3. Finish setup in Unity

Now just apply the script and change the values to your liking and make sure to put a gameobject in for a projectile.

Now hit play and make sure you have no errors.