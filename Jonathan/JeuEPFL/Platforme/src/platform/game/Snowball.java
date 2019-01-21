package platform.game;

import platform.util.Box;
import platform.util.Input;
import platform.util.Output;
import platform.util.Vector;

public class Snowball extends Projectile{
	private double cooldown = 1.5;
	private boolean impact;
	
	/**
     * Create a new Snowball.
     * @param position spawn position, not null
     * @param velocity initial velocity, not null
     * @param owner owner, not null
     */
	public Snowball(Vector position, Vector velocity, Actor owner) {
		super(position,velocity,"snowball",owner);
	}
	
	// PREUPDATE
	public void preUpdate(Input input) {
		impact = false;
	}
	
	// INTERACTION
	public void interact(Actor other) {
		super.interact(other);
		
		// STAY ON MOVER
		if (other instanceof Mover && getBox().isColliding(other.getBox()) && getBox().getMin().getY() > other.getBox().getMin().getY() && other.getVelocity() != Vector.ZERO)
			position = position.add(new Vector(((Mover) other).getDeltaPos().getX(),0));
		
		if (other.isSolid() && other.getBox().isColliding(getBox()))
			impact = true;
	}
	
	// EVOLUTION
	public void update(Input input) {
		super.update(input);
		if (impact) {
			velocity = Vector.ZERO;
			cooldown -= input.getDeltaTime();
		}
		if (cooldown < 0)
			getWorld().unregister(this);
	}
	
	public boolean hurt(Actor instigator , Damage type, double amount , Vector location) {
		if (type == Damage.VOID)
			getWorld().unregister(this);
		return true;
	}
	
	public void draw(Input input, Output output) {
		output.drawSprite(sprite, getBox(),0,cooldown);
	}
	
}
