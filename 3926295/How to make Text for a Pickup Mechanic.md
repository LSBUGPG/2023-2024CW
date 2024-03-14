How to make UI Text for a Pickup mechanic in Unity 3D 

  

Firstly get the object that you have for the pickup mechanism, and then create a cube on top of the object so that they are overlapping. 

  ![tutorial 5](https://github.com/huckerE/University-work/assets/146854478/33eef1a1-360f-4690-a0ee-8e668f6c0b6a)
![tutorial 5 - 1](https://github.com/huckerE/University-work/assets/146854478/20507758-fadf-4852-a2ed-5a07669aca2e)


Next on the cube that has just been created name it "Press E to Pickup" and then uncheck "Mesh Renderer" and then also check "Is Trigger" within the box collider. 

  ![tutorial 5 - 2](https://github.com/huckerE/University-work/assets/146854478/cdbe46d4-19cf-4795-aebc-ab9908c36045)


After that create a C# and then name it "ShowUI" and then copy the code below: 

![tutorial 5 - 3](https://github.com/huckerE/University-work/assets/146854478/e6c4b706-d3ab-4332-bfbd-1445e3bd00f3)

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUi : MonoBehaviour
{
    public GameObject uiObject;
    void Start()
    {
        uiObject.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(uiObject);
        Destroy(gameObject);
    }
}
```



Once that has been done, drag and drop the "ShowUi" code into the "Press E to Pickup" that should now show the script within the object 
![tutorial 5 - 4](https://github.com/huckerE/University-work/assets/146854478/50efc9b2-4e76-44ca-9b2e-0860ccfbf10d)

   ![tutorial 5 - 5](https://github.com/huckerE/University-work/assets/146854478/9bbcfcfc-480b-476f-a07b-f80a477fa311)
 

Next Create some text (Create - Legacy - Text) and name it whatever you want 

  ![tutorial 5 - 6](https://github.com/huckerE/University-work/assets/146854478/63c429f4-4525-41e4-ace5-0e5a11ce5def)


After that, type in the chosen code you would like to appear when wlaking up to the cube and then once done change the "horizontal" and "vertical" overflow to "Overflow!" 

  ![tutorial 5 - 7](https://github.com/huckerE/University-work/assets/146854478/eb4f8728-3040-4ab4-b57f-05184bf7df63)
![tutorial 5 - 9](https://github.com/huckerE/University-work/assets/146854478/0b34081b-6e4b-41ee-96c1-eca26dbbacf1)


Finally drag the text into the "UI Object" inside the "ShowUi" script.
![tutorial 5 - 8](https://github.com/huckerE/University-work/assets/146854478/64dd0e60-b64e-4723-b814-fc803f86e93d)
