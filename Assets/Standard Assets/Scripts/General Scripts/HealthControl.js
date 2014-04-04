var health1 : Texture2D; //one life left
var health2 : Texture2D; //two lives left
var health3 : Texture2D; //three lives left

static var LIVES = 3;   //capitol letters = global


function Update () 
{
	switch(LIVES)
	{
		case 3:
			guiTexture.texture = health3;
		break;
		
		case 2:
			guiTexture.texture = health2;
		break;
		
		case 1:
			guiTexture.texture = health1;
		break;
		
		case 0:
		//game over, man
		break;
	}
}