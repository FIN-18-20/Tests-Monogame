package platform.game;

import platform.util.Box;
import platform.util.Input;
import platform.util.Output;
import platform.util.Vector;

public class Deco extends Actor{
	
	/**
     * Create a new Decoration.
     * @param x first coordinate of spawn
     * @param y second coordinate of spawn
     * @param width width of decoration, greater than 0
     * @param height height of decoration, greater than 0
     * @param name sprite name
     * @param priority priority
     */
	public Deco(double x,double y, double width, double height, String name, int priority) {
		if (width <= 0 || height <= 0)
			throw new IllegalArgumentException("enter positive width and height");
		zone = new Box(new Vector(x,y),width,height);
		sprite = getSprite("deco/" + name);
		this.priority = priority;
	}
	
	/**
     * Create a new Decoration.
     * @param x first coordinate of spawn
     * @param y second coordinate of spawn
     * @param width width of decoration, greater than 0
     * @param height height of decoration, greater than 0
     * @param name sprite name
     */
	public Deco(double x,double y, double width, double height, String name) {
		if (width <= 0 || height <= 0)
			throw new IllegalArgumentException("enter positive width and height");
		zone = new Box(new Vector(x,y),width,height);
		sprite = getSprite("deco/" + name);
		priority = 101;
	}
	
	public void draw(Input input, Output output) {
		output.drawSprite(sprite, zone);
	}
	
	public Box getBox() {
		return zone;
	}
}
