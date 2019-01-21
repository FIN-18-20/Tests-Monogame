package platform.game;

import platform.util.Box;
import platform.util.Input;
import platform.util.Output;
import platform.util.Vector;
import platform.game.level.Level;

public class Exit extends Actor{
	private Level nextLevel;
	private Signal signal;
	
	/**
     * Create a new Exit door.
     * @param x first coordinate of spawn
     * @param y second coordinate of spawn
     * @param nextLevel next level
     * @param signal activation signal
     */
	public Exit(double x, double y, Level nextLevel, Signal signal) {
		if (signal == null)
			this.signal = new Constant();
		else
			this.signal = signal;
		this.nextLevel = nextLevel;
		zone = new Box(new Vector(x,y),1,1.5);
		priority = -1;
	}
	
	public boolean hurt(Actor instigator , Damage type, double amount , Vector location) {
		switch (type) {
		case ACTIVATION:
			if (signal.isActive()) {
				getWorld().setNextLevel(nextLevel);
				getWorld().register(new End());
			}
			return true;
		default :
			return super.hurt(instigator , type, amount , location) ;
		}
	}
	
	public void draw(Input input, Output output) {
		if (signal.isActive())
			sprite = getSprite("door.open");
		else
			sprite = getSprite("door.closed");
		output.drawSprite(sprite, zone);
	}
	
	public Box getBox() {
		return zone;
	}
}
