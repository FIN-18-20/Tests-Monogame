package platform.game.level;
import platform.util.Vector;

import java.awt.event.KeyEvent;

import platform.game.*;

public class Lvl03_1 extends Level {
	
	public void register(World world) {
        super.register(world);
        
     // Register a new instance, to restart level automatically
        world.setNextLevel(new Lvl03_1());
        
     // Construct terrain
        world.register(new Limits(200,250));
        
        // Toit
        world.register(new Terrain(9.5,8,9,50,"snow"));
        world.register(new Terrain(20.5,8,108.5,22,"snow"));
        
        // Partie 1
        world.register(new Terrain(16,36,122,23.5,"snow"));
        world.register(new Terrain(24,9,26,2,"snow"));
        world.register(new Terrain(23,0,1,3,"snow"));
        world.register(new Terrain(28,0,1,3,"snow"));
        world.register(new Terrain(31,0,1,5,"snow"));
        world.register(new Terrain(34,0,1,7,"snow"));
        world.register(new Terrain(38,1.2,1,8,"snow"));
        world.register(new Terrain(44,0,1,4,"snow"));
        world.register(new Terrain(47,1.15,1,8,"snow"));
        world.register(new Spike(50.5,-0.4,10));
        world.register(new Terrain(50.5,-15.3,10,15,"snow"));
        world.register(new Terrain(63,0,1,3,"snow"));
        world.register(new Terrain(63,3.25,1,6,"snow"));
        world.register(new Terrain(69,0,1,3,"snow"));
        world.register(new Terrain(69,4,1,5,"snow"));
        world.register(new Terrain(73,0,1,5,"snow"));
        world.register(new Terrain(73,6,1,3,"snow"));
        world.register(new Terrain(77,0,1,7,"snow"));
        world.register(new Terrain(80,0,1,7,"snow"));
        world.register(new Terrain(84,0,1,5,"snow"));
        world.register(new Terrain(84,6,1,3,"snow"));
        world.register(new Terrain(88,0,1,3,"snow"));
        world.register(new Terrain(88,4,1,5,"snow"));
        world.register(new Spike(95.5,-0.4,34));
        world.register(new Terrain(95.5,-15.3,34,15,"snow"));
        world.register(new Terrain(100,-5,1,10,"snow"));
        world.register(new Terrain(105,-5,1,8,"snow"));
        world.register(new Terrain(105,5.5,1,3,"snow"));
        world.register(new Terrain(110,3.5,1,5,"snow"));
        world.register(new Terrain(117,-5,1,10,"snow"));
        world.register(new Terrain(123,3.5,3,7,"snow"));
        world.register(new Terrain(137,-15,3,65,"snow"));
        
        // Partie 2
        world.register(new Terrain(129,8,6,1,"snow"));
        world.register(new Terrain(136,8,4,1,"snow"));
        world.register(new Terrain(129,14,2,1,"snow"));
        world.register(new Terrain(132,14,4,1,"snow"));
        world.register(new Terrain(130.5,19,9,1,"snow"));
        world.register(new Terrain(129,25,4,1,"snow"));
        world.register(new Terrain(134,25,5,1,"snow"));
        world.register(new Terrain(129,29,6,1,"snow"));
        world.register(new Terrain(136,29,2,1,"snow"));
        world.register(new Checkpoint(130,3,5,new Lvl03_2()));
        
        // Partie 3
        world.register(new Laser(40,29.9,85,"h",new Constant()));
        world.register(new Block (125,30,1,1,"stone.1"));
        world.register(new Block(124,31,1,1,"stone.1"));
        world.register(new Block(120,33,1,1,"stone.1"));
        world.register(new Block(112.5,33,1,1,"stone.1"));
        world.register(new Block(104,32,2,1,"stone.1"));
        world.register(new Mover(new Vector(100,34),1,1, new Vector(98,34),"stone.1",new Constant(), 1.0));
        world.register(new Mover(new Vector(90,34),1,1, new Vector(92,34),"stone.1",new Constant(), 1.0));
        world.register(new Mover(new Vector(82,34),1,1, new Vector(84,34),"stone.1",new Constant(), 1.0));
        world.register(new Block(74,31,1,1,"stone.1"));
        world.register(new Block(69,33,1,1,"stone.1"));
        world.register(new Block(64,34,1,1,"stone.1"));//clé en dessous
        Key blue = new Key(64,32,"blue");
        world.register(new Block(59,31,1,1,"stone.1"));
        world.register(new Block(54,33.25,1,1,"stone.1"));
        world.register(new Block(51,34,1,3.25,"stone.7"));
        world.register(new Block(48,33,1,1,"stone.1"));
        world.register(new Block(41,32,1,1,"stone.1"));
        world.register(new Block(40,31,1,1,"stone.1"));
        world.register(new Block(39,30,1,1,"stone.1"));
        
        // Fin
        world.register(new Terrain(33,31,1,6,"snow"));
        world.register(new Door(33,30,"blue", blue));        
        world.register(new Terrain(25,31,1,6,"snow"));
        Key red = new Key(19,25,"red");
        world.register(new Door(25,30,"red", red));
        world.register(new Exit(29,30,new Lvl_Select(),new Constant()));
        
        
        world.register(new Terrain(9.5,-15,40.5,16,"snow"));//block bas
        world.register(new Terrain(60.5,-15,35,16,"snow"));
        world.register(new Terrain(129.5,-15,10,16,"snow"));//block bas
        
        Player player = new Player(new Vector(93,1));
        Torch torch = new Torch(12,1,false);
        Lever lever = new Lever(133,2.9,false, Double.POSITIVE_INFINITY);
        world.register(player);
        world.register(new Overlay(player));
        world.register(new Hat(player));
        world.register(red);
        world.register(torch);
        world.register(lever);
        world.register(blue);
        world.register(new Mover(new Vector(85,4), 2, 7, new Vector(130,4), "stone.7", new Constant(), 3.0));
        world.register(new Mover(new Vector(19,4), 2, 7, new Vector(19,1500), "stone.7", torch,10.0));//mover partie 1
        world.register(new Mover(new Vector(132.7,1.5), 7.6, 2, new Vector(132.7,28.5), "stone.2", lever, 4.0));//mover partie 2
	}

}
