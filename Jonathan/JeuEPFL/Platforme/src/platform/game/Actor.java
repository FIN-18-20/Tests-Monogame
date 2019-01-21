package platform.game;

import platform.util.Box;
import platform.util.BufferedLoader;
import platform.util.DefaultLoader;
import platform.util.FileLoader;
import platform.util.Input;
import platform.util.Vector;
import platform.util.Output;
import platform.util.Sprite;
import platform.util.Loader;

/**
 * Base class of all simulated actors, attached to a world.
 */

public abstract class Actor implements Comparable<Actor> {
	protected int priority;
	protected Box zone;
	protected Sprite sprite;
	private World world;
	private Loader loader = new BufferedLoader(new FileLoader("res/", DefaultLoader.INSTANCE));
	
	// EVOLUTION
	public void preUpdate(Input input) {}
	public void update(Input input) {}
	public void postUpdate(Input input) {}
	
	// AFFICHAGE
	public void draw(Input input , Output output) {}
	
	// PRIORITE & INTERACTION
	public void interact(Actor other) {}
	
	public int getPriority() {
		return priority;
	}

	@Override
	public int compareTo(Actor other) {
		if (other.getPriority() < this.getPriority()) {
			return -1;
		} else if (other.getPriority() == this.getPriority()) {
			return 0;
		} else {
			return 1;}
	}
	
	// WORLD
	public void register(World world) {
		this.world = world ;
	}
	
	public void unregister() {
		world = null ;
	}
	
	protected World getWorld() {
		return world;
	}
	
	// SPRITE
	protected Sprite getSprite(String name) {
		if (name == null)
			return loader.getSprite("duck");
		else
			return loader.getSprite(name);
	}
	
	// DAMAGE
	public boolean hurt(Actor instigator , Damage type, double amount , Vector location) {
		return false ;
	}
	
	// AUTRE
	public boolean isSolid() {
		return false ;
	}
	
	public Box getBox() {
		return null ;
	}
	
	public Vector getVelocity() {
		return null;
	}
	
	public Vector getPosition() {
		Box box = getBox() ;
		if (box == null)
			return null ;
		return box.getCenter() ;
	}
}