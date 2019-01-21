package platform.game;

import platform.util.Box;
import platform.util.Input;
import platform.util.Output;
import platform.util.Vector;


public class Lever extends Actor implements Signal{
	private boolean active;
	private double cooldown = 0;
	private double time;
	private boolean spawnState;
	
	/**
     * Create a new Lever.
     * @param x first coordinate of spawn
     * @param y second coordinate of spawn
     * @param spawnState spawn state
     * @param time activation time, greater than 0
     */
	public Lever(double x, double y, boolean spawnState, double time) {
		if (time <= 0)
			throw new IllegalArgumentException("enter a positive activation time");
		this.time = time;
		this.spawnState = spawnState;
		active = spawnState;
		zone = new Box(new Vector(x,y),0.8,0.8);
		if (spawnState)
			sprite = getSprite("lever.right");
		else
			sprite = getSprite("lever.left");
		priority = 30;
	}
	
	public void update(Input input) {
			cooldown -= input.getDeltaTime();
		if (cooldown < 0)
			active = spawnState;
	}
	
	public boolean hurt(Actor instigator , Damage type, double amount , Vector location) {
		switch (type) {
		case ACTIVATION:
			cooldown = time;
			active = !active;
			return true;
		default :
			return super.hurt(instigator , type, amount , location) ;
		}
	}
	
	public void draw(Input input, Output output) {
		if (active)
			sprite = getSprite("lever.right");
		else
			sprite = getSprite("lever.left");
		output.drawSprite(sprite, zone);
	}
	
	public Box getBox() {
		return zone;
	}
	
	public boolean isActive() {
		return active;
	}
	
}
