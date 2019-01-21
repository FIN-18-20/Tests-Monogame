package platform.game;

import platform.util.Box;
import platform.util.Vector;
import platform.util.Input;
import platform.util.Output;

public class End extends Actor {
	private double time = 0.0;
	private double duration = 1.0;
	
	public End() {
		sprite = getSprite("pixel.black");
		priority = Integer.MAX_VALUE;
	}
	
	public void update(Input input) {
		time += input.getDeltaTime();
	}
	
	public void postUpdate(Input input) {
		if(duration <= time)
			getWorld().nextLevel();
	}
	
	public void draw(Input input , Output output) {
		double transparency = Math.max(0.0, time - duration + 1);
		output.drawSprite(sprite, output.getBox(), 0.0, transparency);
	}
	
	public Box getBox() {
		return Box.EMPTY;
	}

}
