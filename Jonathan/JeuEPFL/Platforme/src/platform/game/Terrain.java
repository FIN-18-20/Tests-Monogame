package platform.game;

import platform.util.Vector;
import platform.util.Box;
import platform.util.Input;
import platform.util.Output;

public class Terrain extends Block{
	private String name;
	private double height;
	private double width;
	private double x;
	private double y;
	
	/**
     * Create a new Terrain.
     * @param x first coordinate of first block
     * @param y second coordinate of first block
     * @param width width of terrain, greater than 0
     * @param height height of terrain, greater than 0
     * @param name type of terrain, (grass,snow,castle)
     */
	public Terrain(double x, double y, double width, double height, String name) {
		super(new Box(new Vector(x+(width-1)/2,y+(height-1)/2),width,height),name);
		if (!(name == "grass" || name == "snow" || name == "castle"))
			throw new IllegalArgumentException("entrez un type de terrain valable");
		this.name = name;
		this.height = height;
		this.width = width;
		this.x = x;
		this.y = y;
	}
	
	public void draw(Input input, Output output) {
		for (int i = 0; i < height; i++) {
			for (int j = 0; j < width; j++)
				if (i == height -1 && j == width -1)
					if (width == 1)
						output.drawSprite(getSprite(name + ".single"),new Box(new Vector(j+x,i+y),1,1));
					else
						output.drawSprite(getSprite(name + ".right"), new Box(new Vector(j+x,i+y),1,1));
				else if (i == height -1 && j == 0)
					output.drawSprite(getSprite(name + ".left"), new Box(new Vector(j+x,i+y),1,1));
				else if (i == height -1)
					output.drawSprite(getSprite(name + ".middle"),new Box(new Vector(j+x,i+y),1,1));
				else
				output.drawSprite(sprite, new Box(new Vector(j+x,i+y),1,1));
			}
		}
	
	public Box getBox() {
		return zone;
	}
}
