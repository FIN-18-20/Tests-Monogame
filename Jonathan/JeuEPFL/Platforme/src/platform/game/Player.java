package platform.game;

import java.awt.event.KeyEvent;

import platform.game.level.Menu;
import platform.util.Box;
import platform.util.Input;
import platform.util.Output;
import platform.util.Vector;
import platform.game.Mover;

public class Player extends Actor{
	private Vector velocity;
	private Vector position;
	private double size = 0.6;
	private boolean colliding;
	private int zoom = 6;
	private double health;
	private final double MAX_HEALTH = 10;
	private int sautPossible = 1;
	private double cooldownSaut = 0.01;
	private boolean construct = false;
	
	/**
     * Create a new Player.
     * @param position spawn position, not null
     */
	public Player(Vector position) {
		if (position == null)
			throw new NullPointerException();
		this.position = position;
		velocity = Vector.ZERO;
		zone = getBox();
		priority = 42;
		health = MAX_HEALTH;
	}
	
	// GETTERS
	public Vector getPosition() {
		return position;
	}
	
	public double getHealth() {
		return health;
	}
	
	public double getHealthMax() {
		return MAX_HEALTH;
	}
	
	public Vector getVelocity() {
		return velocity;
	}
	
	public Box getBox() {
		return new Box(position, size, size);
	}
	
	// SETTERS
	public void setPosition(Vector position) {
		this.position = position;
	}
	
	public void setVelocity(Vector velocity) {
		this.velocity = velocity;
	}
	
	// FOR DRAW IN MENU
	public void activateConstruct(boolean construct) {
		this.construct = construct;
	}
	
	// PREUPDATE
	public void preUpdate(Input input) {
		super.preUpdate(input);
    	colliding = false;
    }
	
	// INTERRACTION
	public void interact(Actor other) {
		super.interact(other) ;

		// STAY ON MOVER
		if (other instanceof Mover && getBox().isColliding(other.getBox()) && getBox().getMin().getY() > other.getBox().getMin().getY() && other.getVelocity() != Vector.ZERO)
			position = position.add(new Vector(((Mover) other).getDeltaPos().getX(),0));
			
		// NOT SINK IN SOLIDS
		if (other.isSolid()) {
			Vector delta = other.getBox().getCollision(getBox());
			if (delta != null) {
				colliding = true;
				position = position.add(delta);
				if (delta.getX() != 0.0)
					velocity = new Vector(0.0, velocity.getY());
				if (delta.getY() != 0.0)
					velocity = new Vector(velocity.getX(), 0.0);
				if (delta.getX() >= size*0.9 || delta.getY() >= size*0.9) // if compressed then dies
					this.die();
			}
		}
		
		// INTERACTION WITH CHECKPOINTS
		if (other instanceof Checkpoint && getBox().isColliding(other.getBox()))
			getWorld().setNextLevel(((Checkpoint)other).getNextLevel());
	}
	
	// EVOLUTION
	public void update(Input input) {
		super.update(input);
	
		// FRICTION (ACCELERATING ZONES?)
		if (colliding && velocity.getX() != 0) {
			double scale = Math.pow(0.001, input.getDeltaTime());
			velocity = velocity.mul(scale);
		}
		
		double maxSpeed = 4.0 ;
		// RIGHT
		if (input.getKeyboardButton(KeyEvent.VK_RIGHT).isDown() || input.getKeyboardButton(KeyEvent.VK_D).isDown()) {
			sprite = getSprite("blocker.happy.right");
			if (velocity.getX() < maxSpeed) {
				double increase = 60.0 * input.getDeltaTime();
				double speed = velocity.getX() + increase;
				if (speed > maxSpeed)
					speed = maxSpeed;
				velocity = new Vector(speed, velocity.getY());
			}
		} else
		// LEFT
		if (input.getKeyboardButton(KeyEvent.VK_LEFT).isDown() || input.getKeyboardButton(KeyEvent.VK_A).isDown()) {
			sprite = getSprite("blocker.happy.left");
			if (velocity.getX() > -maxSpeed) {
				double increase = -60.0 * input.getDeltaTime();
				double speed = velocity.getX() + increase ;
				if (speed < -maxSpeed)
					speed = -maxSpeed;
				velocity = new Vector(speed, velocity.getY());
			}
		} else {
			sprite = getSprite("blocker.happy");
			velocity = new Vector(0, velocity.getY());
		}
		// JUMP
		if (sautPossible == 1) {
			if (input.getKeyboardButton(KeyEvent.VK_UP).isPressed() || input.getKeyboardButton(KeyEvent.VK_W).isPressed()) {
				velocity = new Vector(velocity.getX(), 79.0);
				sautPossible = 0;
			}
		} else if (sautPossible == 0 && colliding && velocity.getY() == 0 && cooldownSaut < 0)
			sautPossible = 1;
		
		if (colliding)
			cooldownSaut -= input.getDeltaTime();
		else
			cooldownSaut = 0.01;
		
		// WALLJUMP
		if (sautPossible == 0 && colliding && velocity.getY() < 0)
			if (input.getKeyboardButton(KeyEvent.VK_UP).isPressed() || input.getKeyboardButton(KeyEvent.VK_W).isPressed())
				if (input.getKeyboardButton(KeyEvent.VK_RIGHT).isDown() || input.getKeyboardButton(KeyEvent.VK_D).isDown())
					velocity = new Vector(-15,5);
		else if (sautPossible == 0 && colliding && velocity.getY() < 0)
			if (input.getKeyboardButton(KeyEvent.VK_UP).isPressed() || input.getKeyboardButton(KeyEvent.VK_W).isPressed())
				if (input.getKeyboardButton(KeyEvent.VK_LEFT).isDown() || input.getKeyboardButton(KeyEvent.VK_A).isDown())
					velocity = new Vector(15,5);
		
		// DUCK
		if (input.getKeyboardButton(KeyEvent.VK_DOWN).isDown() || input.getKeyboardButton(KeyEvent.VK_S).isDown())
			size = 0.3;
		else
			size = 0.6;
		
		// POSITION & VELOCITY (GRAVITY)
		double delta = input.getDeltaTime();
		Vector acceleration = getWorld().getGravity();
		velocity = velocity.add(acceleration.mul(delta));
		position = position.add(velocity.mul(delta));
		
		// THROW FIREBALL
		Vector v = velocity.add(velocity.resized(2.0));
		if (input.getKeyboardButton(KeyEvent.VK_SPACE).isPressed()) {
			getWorld().register(new Fireball(position,v,this));
		}
		
		// THROW SNOWBALL
		Vector w = ((input.getMouseLocation()).sub(position)).resized(10.0);
		if (input.getMouseButton(1).isPressed()) {
			getWorld().register(new Snowball(position,w,this));
		}
		
		/*
		 * 	//TP, USED FOR DEBUGGING & CONSTRUCTING LEVELS
		 *  if (input.getMouseButton(2).isPressed())
		 *		setPosition(input.getMouseLocation());
		 */
		
		// CONSTRUCT IN MENU (DRAW)
		if (input.getMouseButton(3).isDown() && construct)
			getWorld().register(new Block(input.getMouseLocation().getX(),input.getMouseLocation().getY(),0.05,0.05,"heart"));
		
		// ZOOMOUT
		final int MAX_ZOOMOUT = 15;
		final int ZOOM_DEFAULT = 6;
		if (input.getKeyboardButton(KeyEvent.VK_2).isDown()) {
			zoom = MAX_ZOOMOUT;
		} else {zoom = ZOOM_DEFAULT;}

		// RESTART LEVEL
		if (input.getKeyboardButton(KeyEvent.VK_R).isPressed()) {
			getWorld().nextLevel();
		}
		
		// RETURN TO MENU
		if (input.getKeyboardButton(KeyEvent.VK_M).isPressed()) {
			getWorld().setNextLevel(new Menu());
			getWorld().register(new End());
		}

		// BLOW
		if (input.getKeyboardButton(KeyEvent.VK_B).isPressed())
			getWorld().hurt(getBox(), this , Damage.AIR, 1.0, getPosition());
		
		// ACTIVATE LEVER / ENTER DOOR
		if (input.getKeyboardButton(KeyEvent.VK_E).isPressed())
			getWorld().hurt(getBox(), this , Damage.ACTIVATION, 1.0, getPosition());
		
		// DIE
		if (health <= 0)
			this.die();
	}
	
	// FIXED VIEW
	public void postUpdate(Input input) {
		super.postUpdate(input);
		getWorld().setView(position, zoom);
	}
		
	// DRAW
	public void draw(Input input , Output output) {
		output.drawSprite(sprite , getBox());
	}
	
	// HURT
	public boolean hurt(Actor instigator , Damage type, double amount , Vector location) {
		switch (type) {
		case AIR : 
			velocity = getPosition().sub(location).resized(amount) ;
			return true;
		case VOID :
			health -= amount;
			return true;
		case HEAL:
			if (health < MAX_HEALTH)
				health += amount;
			else
				health = MAX_HEALTH;
			return true;
		case PHYSICAL :
			health -= amount;
			return true;
		case LASER :
			health -= amount;
			return true;
		default :
			return super.hurt(instigator , type, amount , location) ;
		}
	}
	
	// DIE
	public void die() {
		getWorld().register(new End());
	}
}
