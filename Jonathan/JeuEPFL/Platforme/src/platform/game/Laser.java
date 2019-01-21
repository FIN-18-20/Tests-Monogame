package platform.game;

import platform.util.Box;
import platform.util.Vector;
import platform.util.Input;
import platform.util.Output;

public class Laser extends Actor{
	private Signal signal;
	private double x;
	private double y;
	private double length;
	private String direction;
	private double cooldown = 0;
	
	/**
     * Create a new Laser.
     * @param x first coordinate of the first laser tile
     * @param y second coordinate of the first laser tile
     * @param length length of the laser, greater than 0
     * @param direction vertical "v" or horizontal "h"
     * @param signal activation signal
     */
	public Laser(double x, double y, double length, String direction, Signal signal) {
		if (length <= 0)
			throw new IllegalArgumentException("enter a positive length");
		if (direction == "v")
			zone = new Box(new Vector(x,y+(length-1)/2),1,length);
		else if (direction == "h")
			zone = new Box(new Vector(x+(length-1)/2,y),length,1);
		else
			throw new IllegalArgumentException("must be v or h");
		this.x = x;
		this.y = y;
		this.length = length;
		this.direction = direction;
		this.signal = signal;
		priority = 50;
	}
	
	public void update(Input input) {
		cooldown -= input.getDeltaTime();
	}
	
	public void draw(Input input, Output output) {
		if (signal.isActive())
		for (int i = 0; i < length; i++) {
			if (direction == "v")
				output.drawSprite(getSprite("laser_vertical"),new Box(new Vector(x,i+y),1,1));
			else
				output.drawSprite(getSprite("laser_horizontal"),new Box(new Vector(i+x,y),1,1));
		}
	}
	
	public void interact(Actor other) {
		super.interact(other);
		
		// LASER DAMAGE
		if (signal.isActive() && other.getBox().isColliding(getBox()) && cooldown <= 0)
			if (other.hurt(this , Damage.LASER, 5.0, getPosition()))
				cooldown = 1;
		}
	
	public Box getBox() {
		return zone;
	}

}
