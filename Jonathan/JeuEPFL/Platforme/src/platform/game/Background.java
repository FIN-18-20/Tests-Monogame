package platform.game;

import platform.util.Box;
import platform.util.Input;
import platform.util.Output;
import platform.util.Vector;

public class Background extends Actor{
	
	/**
     * Create a new Background.
     * @param name sprite name
     */
	public Background(String name) {
		sprite = getSprite("deco/" + name);
		priority = -10;
	}
	
	public void draw(Input input, Output output) {
		double width = output.getBox().getWidth();
		double height = width/2;
		zone = new Box(new Vector(output.getBox().getCenter().getX(),output.getBox().getCenter().getY()-3),width,height);
		output.drawSprite(sprite, zone,0,0.7);
	}
	
	public Box getBox() {
		return Box.EMPTY;
	}
}
