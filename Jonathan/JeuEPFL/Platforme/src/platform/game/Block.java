package platform.game;

import platform.util.Box;
import platform.util.Input;
import platform.util.Output;
import platform.util.Vector;

/**
 * Simple solid actor that does nothing.
 */
public class Block extends Actor {
	
	/**
     * Create a new Block.
     * @param lowerCorner lower corner of spawn
     * @param upperCorner upper corner of spawn
     * @param name sprite name
     */
	public Block(Vector lowerCorner, Vector upperCorner, String name) {
		zone = new Box(lowerCorner,upperCorner);
		sprite = getSprite(name);
		priority = 0;
	}
	
	/**
     * Create a new Block.
     * @param zone spawn position, not null
     * @param name sprite name
     */
	public Block(Box zone, String name) {
		if (zone == null)
			throw new NullPointerException();
		this.zone = zone;
		sprite = getSprite(name);
		priority = 0;
	}
	
	/**
     * Create a new Block.
     * @param x first cooridinate of spawn
     * @param y second coordinate of spawn
     * @param width width of block, greater than 0
     * @param height height of block, greater than 0
     * @param name sprite name
     */
	public Block(double x, double y, double width, double height, String name) {
		if (width <= 0 || height <= 0)
			throw new IllegalArgumentException("enter positive width and height");
		zone = new Box(new Vector(x,y),width,height);
		sprite = getSprite(name);
		priority = 0;
	}
	
	// pour évoluer au cours du temps :
	public void update(Input input) {}
	
	// pour être dessiné
	public void draw(Input input , Output output) {
		output.drawSprite(sprite,zone);
	}
	
	public Box getBox() {
		return zone;
	}
		
	public void interact(Actor other) {}
	
	public boolean isSolid() {
		return true; }
	
}
