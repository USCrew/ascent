#pragma strict

var otherThing  :  GameObject;
 
function Update ()
{
    gameObject.transform.position.y = otherThing.transform.position.y;
}