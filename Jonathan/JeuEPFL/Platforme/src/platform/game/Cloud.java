package platform.game;

import platform.util.Vector;
import platform.util.Input;
import platform.util.Output;

public class Cloud extends Mover {

	/**
     * Create a new Cloud.
     * @param min spawn position, not null
     * @param width width of cloud, greater than 0
     * @param height height of cloud, greater than 0
     * @param max final position, not null
     * @param velocityFactor velocity factor, greater or equal to 0
     */
	public Cloud(Vector min,double width, double height, Vector max, double velocityFactor) {
		super(min,width,height,max,"cloud",new Constant(),velocityFactor);
	}
	
	public boolean isSolid() {
		return false;
	}
	
	public void draw(Input input, Output output) {
		output.drawSprite(sprite, zone, 0, 0.8);
	}
}
