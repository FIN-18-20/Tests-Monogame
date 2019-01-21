package platform.game;

import platform.util.Box;
import platform.util.Input;
import platform.util.Output;
import platform.util.Vector;

public class Fireball extends Projectile{
	private double cooldown = 3.7;
	
	/**
     * Create a new Fireball.
     * @param position spawn position, not null
     * @param velocity initial velocity, not null
     * @param owner owner, not null
     */
	public Fireball(Vector position, Vector velocity, Actor owner) {
		super(position,velocity,"fireball",owner);
	}
	
	// EVOLUTION	
	public void update(Input input) {
		super.update(input);
		
		cooldown -= input.getDeltaTime();
		if (cooldown < 0){
			getWorld().unregister(this);
		}
	}
	
	// DRAW
	public void draw(Input input, Output output) {
		output.drawSprite(sprite, getBox(), input.getTime());
	}
		
	// INTERACTION
	public void interact(Actor other) {
		super.interact(other);
		if (other.isSolid()) {
			
		// BOUNCE
		Vector delta = other.getBox().getCollision(position);
		if (delta != null) {
			position = position.add(delta);
			velocity = velocity.mirrored(delta);
			}
		}
		
		// FIRE DAMAGE
		if (other.getBox().isColliding(getBox()) && other != owner) {
			other.hurt(this , Damage.FIRE, 1.0, getPosition());
		}
	}
	
}
