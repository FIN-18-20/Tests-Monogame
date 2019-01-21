
package platform.game;

import platform.util.Box;
import platform.util.Input;
import platform.util.Output;
import platform.util.Vector;

public class Limits extends Actor {
	
	/**
     * Create new Limits.
     * @param width width of limits, greater than 0
     * @param height height of limits, greater than 0
     */
	public Limits (int width, int height) {
		if (width <= 0 || height <= 0)
			throw new IllegalArgumentException("enter a positive width and height");
		zone = new Box(Vector.ZERO, new Vector(width,height));
		sprite = getSprite("empty");
		priority = 100;
	}
	
	public void update(Input input) {}
	
	public void draw(Input input, Output output) {
		output.drawSprite(sprite, zone);
	}
	
	public Box getBox() {
		return zone;
	}
	
	public void interact(Actor other) {
		super.interact(other);
		if (!other.getBox().isColliding(this.getBox()))
			other.hurt(this , Damage.VOID, Double.POSITIVE_INFINITY, Vector.ZERO);
	}
}
