package platform.game;

import platform.util.Input;
import platform.util.Output;
import platform.util.Box;
import platform.util.Vector;


public class HiddenBlock extends Block{
	private double hidden;
	private Signal signal;
	
	/**
     * Create a new Hidden Block.
     * @param x first coordinate of spawn
     * @param y second coordinate of spawn
     * @param width width of hidden block, greater than 0
     * @param height height of hidden block, greater than 0
     * @param name sprite name
     * @param signal activation signal, not null
     */
	public HiddenBlock(double x, double y, double width, double height, String name, Signal signal) {
		super(x,y,width,height,name);
		if (signal == null)
			throw new NullPointerException();
		this.signal = signal;
	}
	
	public boolean isSolid() {
		if (!signal.isActive())
			return false;
		else
			return super.isSolid();
	}
	
	public void update(Input input) {
		if (signal.isActive())
			hidden = 1;
		else
			hidden = 0.05;
	}
	
	public Box getBox() {
		return zone;
	}
	
	public void draw(Input input, Output output) {
		output.drawSprite(sprite, zone, 0, hidden);
	}
}
