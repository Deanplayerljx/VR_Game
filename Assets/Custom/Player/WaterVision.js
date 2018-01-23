//From http://answers.unity3d.com/questions/442734/how-do-i-make-the-area-under-my-water-a-plane-look.html

 var underwaterDens: float = 0.15;
 var underwaterColor: Color = Color(0.1, 0.3, 0.4, 1.0);
 
 private var oldFog: boolean;
 private var oldDens: float;
 private var oldColor: Color;
 private var oldMode: FogMode;
 private var curWater: Transform;
 private var underwater = false;
 
 function OnTriggerEnter(other: Collider){
     if (other.tag=="Water"){ // if entering a waterplane
         if (transform.position.y > other.transform.position.y){
             // set reference to the current waterplane
             curWater = other.transform; 
         }
     }
 }
 
 function OnTriggerExit(other: Collider){
     if (other.transform==curWater){ // if exiting the waterplane...
         if (transform.position.y > curWater.position.y){
             //  null the current waterplane reference
             curWater = null; 
         }
     }
 }
 
 function Update(){
     // if it's underwater...
     if (curWater && Camera.main.transform.position.y < curWater.position.y){
         if (!underwater){ // turn on underwater effect only once
             oldFog = RenderSettings.fog;
             oldMode = RenderSettings.fogMode;
             oldDens = RenderSettings.fogDensity;
             oldColor = RenderSettings.fogColor;
             RenderSettings.fog = true;
             RenderSettings.fogMode = FogMode.Exponential;
             RenderSettings.fogDensity = underwaterDens;
             RenderSettings.fogColor = underwaterColor;
             underwater = true;
         }
     } 
     else // but if it's not underwater...
     if (underwater){ // turn off underwater effect, if any
         RenderSettings.fog = oldFog;
         RenderSettings.fogMode = oldMode;
         RenderSettings.fogDensity = oldDens;
         RenderSettings.fogColor = oldColor;
         underwater = false;
     }
 }