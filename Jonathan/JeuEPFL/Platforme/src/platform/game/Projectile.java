package platform.game;

import platform.util.Box;
import platform.util.Input;
import platform.util.Output;
import platform.util.Vector;

public abstract class Projectile extends Actor{
	protected Actor owner;
	protected Vector position;
	protected Vector velocity;
	protected final double SIZE = 0.4;
	
	/**
     * Create a new Projectile.
     * @param position spawn position, not null
     * @param velocity initial velocity, not null
     * @param name sprite to show
     * @param owner owner, not null
     */
	public Projectile(Vector position, Vector velocity, String name, Actor owner) {
		if (position == null || velocity == null || owner == null)
			throw new NullPointerException();
		this.owner = owner;
		this.position = position;
		this.velocity = velocity;
		zone = getBox();
		sprite = getSprite(name);
		priority = 80;
	}
	
	// EVOLUTION	
	public void update(Input input) {
		super.update(input);
		double delta = input.getDeltaTime();
		Vector acceleration = getWorld().getGravity();
		velocity = velocity.add(acceleration.mul(delta));
		position = position.add(velocity.mul(delta));
	}
		
	// CENTERED ZONE
	public Box getBox() {
		return new Box(position , SIZE, SIZE);
	}
	
	// DRAW
	public void draw(Input input, Output output) {
		output.drawSprite(sprite, getBox());
	}
	
}
