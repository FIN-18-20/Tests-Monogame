package platform.game;

import platform.util.Box;
import platform.util.Input;
import platform.util.Output;
import platform.util.Vector;

public class Mover extends Block{
	private Vector min;
	private Vector max;
	private Signal signal;
	private double height;
	private double width;
	private Vector current;
	private Vector velocity;
	private double velocityFactor = 1.0;
	private Vector deltaPos;
	
	/**
     * Create a new Mover.
     * @param min spawn position, not null
     * @param width width of the mover, greater than 0
     * @param height height of the mover, greater to 0
     * @param max final position, not null
     * @pararm name sprite name
     * @param signal activation signal, not null
     */
	public Mover (Vector min,double width, double height, Vector max, String name, Signal signal) {
		super(new Box(min,width,height),name);
		if (min == null || max == null || signal == null)
			throw new NullPointerException();
		this.height = height;
		this.width = width;
		this.signal = signal;
		if (max.getLength() < min.getLength()) {
			this.min = max;
			this.max = min;
		} else {
			this.min = min;
			this.max = max;
		}
		current = min;
	}
	
	/**
     * Create a new Mover.
     * @param min spawn position, not null
     * @param width width of the mover, greater than 0
     * @param height height of the mover, greater to 0
     * @param max final position, not null
     * @pararm name sprite name
     * @param signal activation signal, not null
     * @param velocityFactor velocity factor, greater or equal to 0
     */
	public Mover (Vector min,double width, double height, Vector max, String name, Signal signal, double velocityFactor) {
		super(new Box(min,width,height),name);
		if(min == null || max == null || signal == null)
			throw new NullPointerException();
		if (velocityFactor < 0)
			throw new IllegalArgumentException("enter velocity factor greater or equal to zero");
		this.height = height;
		this.width = width;
		this.signal = signal;
		this.velocityFactor = velocityFactor;
		if (max.getLength() < min.getLength()) {
			this.min = max;
			this.max = min;
		} else {
			this.min = min;
			this.max = max;
		}
		current = min;
	}
	
	private boolean i = true;
	public void update(Input input) {
		Vector posI = current;
		Vector posF = Vector.ZERO;
		double delta = input.getDeltaTime();
		if (signal.isActive()) {
			if ((current.getLength() < max.getLength()) && i){
				velocity = (max.sub(min)).resized(velocityFactor);
				current = current.add(velocity.mul(delta));
				posF = current;
			} else if (current.getLength() > min.getLength()){
				if (current.getLength() > max.getLength())
					i = false;
				velocity = (max.sub(min)).resized(velocityFactor);
				current = current.sub(velocity.mul(delta));
				posF = current;
				if (current.getLength() < min.getLength())
					i = true;
			}
		} else {
			velocity = Vector.ZERO;
		}
		zone = new Box(current,width,height);
		deltaPos = posF.sub(posI);
	}
	
	// used for keeping things on top of the Mover
	public Vector getDeltaPos() {
		return deltaPos;
	}
	
	public void draw(Input input, Output output) {
		output.drawSprite(sprite, zone);
	}
	
	public Box getBox() {
		return zone;
	}
	
	public Vector getVelocity() {
		return velocity;
	}
}
