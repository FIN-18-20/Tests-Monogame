package platform.game;

import platform.util.Box;
import platform.util.Input;
import platform.util.Output;
import platform.util.Vector;

public class Heart extends Actor{
	private double cooldown = 0.0;
	private double size = 0.4;
	private double variation = 0.0;
	
	/**
     * Create a new Heart.
     * @param x first coordinate of spawn
     * @param y second coordinate of spawn
     */
	public Heart(double x, double y) {
		zone = new Box(new Vector(x,y),size,size);
		sprite = getSprite("heart.full");
		priority = 50;
	}
	
	public void update(Input input) {
		super.update(input) ;
		cooldown -= input.getDeltaTime();
		variation -= input.getDeltaTime();
		if (variation < 0.0)
			variation = 0.4 ;
	}
	
	public void interact(Actor other) {
		super.interact(other) ;
		if (cooldown <= 0 && getBox().isColliding(other.getBox())) {
			if (other.hurt(this , Damage.HEAL, 2.0, Vector.ZERO))
				cooldown = 10.0 ;
		}
	}
	
	public void draw(Input input, Output output) {
		if (variation < 0.2)
			size = 0.4;
		else
			size = 0.43;
		if (cooldown <= 0.0)
		output.drawSprite(sprite, new Box(getPosition(),size,size));
	}
	
	public Box getBox() {
		return zone;
	}
}
