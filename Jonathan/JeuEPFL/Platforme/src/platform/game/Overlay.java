package platform.game;

import platform.util.Box;
import platform.util.Input;
import platform.util.Output;
import platform.util.Vector;

public class Overlay extends Actor{
	private Player player;
	private final double SIZE = 0.5;
	
	/**
     * Create a new Overlay.
     * @param player associated player, not null
     */
	public Overlay(Player player) {
		if (player == null)
			throw new NullPointerException();
		this.player = player;
		priority = 100;
	}
	
	public void update(Input input) {
		super.update(input);
		if (player.getWorld() == null)
			getWorld().unregister(this);
	}

	public Box getBox() {
		return player.getBox();
	}
	
	public void draw(Input input, Output output) {
		double health = 5.0 * player.getHealth() / player.getHealthMax() ;
		for (int i = 1 ; i <= 5 ; ++i) {
			String name ;
			if (health >= i)
				name = "heart.full" ;
			else if (health >= i - 0.5)
				name = "heart.half";
			else
				name = "heart.empty" ;
			// trouver le Sprite associé à name
			sprite = getSprite(name);
			// dessiner ce Sprite en desssus de Player.
			//output.drawSprite(sprite, new Box(player.getPosition().add(new Vector(-0.6,0.5).add(new Vector(SIZE*i,0))),SIZE,SIZE));
			
			// Draw sprite in top left corner
			output.drawSprite(sprite, new Box(output.getBox().getMin().add(new Vector(0.5,output.getBox().getHeight()-1).add(new Vector(SIZE*i,0))),SIZE,SIZE));
		}
	}
}
