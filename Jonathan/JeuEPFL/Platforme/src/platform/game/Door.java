package platform.game;

import platform.util.Box;
import platform.util.Input;
import platform.util.Output;
import platform.util.Vector;

public class Door extends Block{
	private Signal signal;

	/**
     * Create a new Door (Lock).
     * @param x first coordinate of spawn
     * @param y second coordinate of spawn
     * @param color color of lock, (blue, green, red, yellow)
     * @param signal activation signal, not null
     */
	public Door(double x, double y, String color, Signal signal) {
		super(x,y,1,1,"lock." + color);
		if (signal == null)
			throw new NullPointerException();
		if (!(color == "blue" || color == "red" || color == "yellow" || color == "green"))
			throw new IllegalArgumentException("entrez une couleur valable");
		this.signal = signal;
	}
	
	public void update(Input input) {
		if (signal.isActive())
			priority = 50;
	}
	
	public void draw(Input input, Output output) {
			output.drawSprite(sprite, zone);
	}
	
	public void interact(Actor other) {
		if (other instanceof Player && other.getBox().isColliding(getBox()))
				getWorld().unregister(this);
	}
	
	public Box getBox() {
		return zone;
	}

}
