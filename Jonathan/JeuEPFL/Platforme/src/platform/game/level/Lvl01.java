package platform.game.level;

import platform.util.Box;
import platform.util.Vector;
import platform.game.*;

public class Lvl01 extends Level {

	public void register(World world) {
        super.register(world);
        
        // Register a new instance, to restart level automatically
        world.setNextLevel(new Lvl01());
        
        // Create terrain
        world.register(new Limits(30,30));
        world.register(new Background("BG"));
        
        
        world.register(new Terrain(30,4,1,10,"snow")); //9
        
        world.register(new Terrain(9,13,21,1,"snow")); //10
        
        world.register(new Terrain(0,-2,16,7,"snow")); //1
        
        world.register(new Terrain(17,-2,14,7,"snow")); //2
        
        world.register(new Terrain(15,-2,3,5,"snow")); //3
        
        world.register(new Terrain(9,6,1,8,"snow")); //5
        
        world.register(new Terrain(10,10,1,4,"snow")); //6
        
        world.register(new Terrain(11,8,9,6,"snow")); //7
        
        world.register(new Terrain(20,10,11,4,"snow")); //8
        
        
        // Create objects
        Player player = new Player(new Vector(1,5));
        Torch torch1 = new Torch(3.5,5,true);
        Torch torch2 = new Torch(5,5,true);
        Torch torch3 = new Torch(6.5,5,true);
        Torch torch4 = new Torch(0.5,12,false);
        Lever lever = new Lever(24,4.74,false,10);
        
        // Register player
        world.register(player);
        world.register(new Overlay(player));
        world.register(new Hat(player));
        
        // Register Signals
        world.register(torch1);
        world.register(torch2);
        world.register(torch3);
        world.register(torch4);
        world.register(lever);
        
        // Register Movers
        world.register(new Mover(new Vector(10,6),1,3,new Vector(10,8),"stone.8",new Not(torch1)));
        world.register(new Mover(new Vector(16,6),1,3,new Vector(16,4),"stone.8",new And(torch2,new Not(torch3))));
        world.register(new Mover(new Vector(20,6),1,3,new Vector(20,8),"stone.8",new And(new Not(torch1),new Not(torch3))));
        
        // Register Hidden Blocks
        world.register(new HiddenBlock(5,6,2,1,"stone.5",lever));
        world.register(new HiddenBlock(2.5,8,2,1,"stone.5",lever));
        world.register(new HiddenBlock(0,10,2,1,"stone.5",lever));
        
        // Register Exit
        world.register(new Exit(27,5,new Lvl_Select(),torch4));
        
        // Register Deco
        world.register(new Deco(0,5.5,1,2.2,"foliagePack_028"));
        world.register(new Deco(0.3,5.35,0.8,1.8,"foliagePack_030"));
        world.register(new Deco(1.6,5.4,1,2,"foliagePack_030",-1));

    }
	
}
