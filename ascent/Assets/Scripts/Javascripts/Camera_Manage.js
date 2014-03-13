

var otherThing  :  GameObject;
 
function Update ()
{
    gameObject.transform.position.x = otherThing.transform.position.x;
    gameObject.transform.position.y = otherThing.transform.position.y;
    

    if (Input.GetKeyDown(KeyCode.F))
        Screen.fullScreen = !Screen.fullScreen;

}