package platform.game;

import platform.util.Box;
import platform.util.Input;
import platform.util.Output;
import platform.util.Vector;

public class Torch extends Actor implements Signal{
	private boolean lit;
	private double variation = 0.0;
	private final double SIZE = 0.8;
	
	/**
     * Create a new Torch.
     * @param x first coordinate of spawn
     * @param y second coordinate of spawn
     * @param lit spawn state
     */
	public Torch(double x, double y, boolean lit) {
		this.lit = lit;
		zone = new Box(new Vector(x,y), SIZE, SIZE);
		if (lit)
			sprite = getSprite("torch.lit.1");
		else
			sprite = getSprite("torch");
		priority = -1;
	}
	
	public void update(Input input) {
		super.update(input);
		variation -= input.getDeltaTime();
		if (variation < 0.0)
			variation = 0.6 ;
	}
	
	public boolean hurt(Actor instigator , Damage type, double amount , Vector location) {
		switch (type) {
		case AIR : 
			lit = false;
			sprite = getSprite("torch");
			return true;
		case FIRE :
			if (!lit){
				getWorld().unregister(instigator);
			}
			lit = true;
			sprite = getSprite("torch.lit.1");
			return true;
		default :
			return super.hurt(instigator, type, amount, location);
		}
	}
	
	public Box getBox() {
		return zone;
	}
	
	public void draw(Input input, Output output) {
		if (lit)
			if (variation < 0.3)
				sprite = getSprite("torch.lit.2");
			else
				sprite = getSprite("torch.lit.1");
		output.drawSprite(sprite, zone);
	}
	
	public boolean isActive() {
		return lit;
	}

}
