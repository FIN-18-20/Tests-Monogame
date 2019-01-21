package platform.game;

import platform.util.Box;
import platform.util.Input;
import platform.util.Output;
import platform.util.Vector;

public class Spike extends Actor{
	private final double SIZE = 1;
	private double width;
	private double cooldown = 0;
	private double x;
	private double y;
	
	/**
     * Create a new row of Spikes.
     * @param x first coordinate of first spike
     * @param y second coordinate of first spike
     * @param width width of row, greater than 0
     */
	public Spike (double x, double y, double width) {
		if (width <= 0)
			throw new IllegalArgumentException("enter a positive width");
		zone = new Box(new Vector(x+(width-1)/2,y),width,SIZE);
		this.width = width;
		this.x = x;
		this.y = y;
		sprite = getSprite("spikes");
		priority = 50;
	}
	
	public void update(Input input) {
		super.update(input) ;
		cooldown -= input.getDeltaTime();
	}
	
	public void interact(Actor other) {
		super.interact(other);
		if (other instanceof Player && cooldown <= 0 && getBox().isColliding(other.getBox()))
				if(other.hurt(this , Damage.PHYSICAL, 2.0, Vector.ZERO)) {
					((Player) other).setVelocity(Vector.ZERO);
					cooldown = 1.5; }
	}
	
	public void draw(Input input, Output output) {
		for (int i = 0; i < width; i++) {
			output.drawSprite(sprite, new Box(new Vector(i+x,y),1,SIZE));
		}
	}
	
	public Box getBox() {
		return zone;
	}
}
