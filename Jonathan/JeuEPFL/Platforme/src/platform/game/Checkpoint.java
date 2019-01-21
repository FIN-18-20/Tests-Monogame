package platform.game;

import platform.util.Box;
import platform.util.Input;
import platform.util.Output;
import platform.util.Vector;
import platform.game.level.Level;

public class Checkpoint extends Exit {
	
	private double height;
	private Level nextLevel;
	
	public Checkpoint(double x, double y,double height, Level nextLevel) {
		super(x, y, nextLevel, new Constant());
		this.height = height;
		this.nextLevel = nextLevel;
		zone = new Box(new Vector(x,y),1,height);
	}
	public void draw(Input input, Output output){
		sprite = getSprite("deco/checkpoint");
		output.drawSprite(sprite, new Box(getBox().getCenter(),2,0.4));
	}
	
	public boolean hurt(Actor instigator , Damage type, double amount , Vector location) {
		return false;
	}
	
	public Level getNextLevel(){
		return nextLevel;
	}

}
