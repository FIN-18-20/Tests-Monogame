package platform.game.level;

import platform.util.Box;
import platform.util.Vector;
import platform.game.*;

public class Lvl_Select extends Level {
	
	public void register(World world) {
        super.register(world);
        
        // Register a new instance, to restart level automatically
        world.setNextLevel(new Lvl_Select());
        
        // Create terrain
        world.register(new Limits(30,20));
        world.register(new Background("BG"));
        
        world.register(new Terrain(0,10,4,6,"castle"));
        
        world.register(new Terrain(8,15,18,1,"castle"));
        
        world.register(new Terrain(3,10,2,5,"castle"));
        
        world.register(new Terrain(4,10,2,4,"castle"));
        
        world.register(new Terrain(5,10,2,3,"castle"));
        
        world.register(new Terrain(6,10,2,2,"castle"));
        
        world.register(new Terrain(7,10,2,1,"castle"));
        
        world.register(new Terrain(0,10,26,1,"castle"));
        
        
        // OBJECTS
        Player player = new Player(new Vector(2,16));
        
        world.register(player);
        world.register(new Hat(player));
        // Menu door
        world.register(new Exit(0.5,16,new Menu(),new Constant()));
        // Doors lvl 1-5
        world.register(new Deco(10,17.2,0.35,0.5,"digit.1",-1));
        world.register(new Exit(10,16,new Lvl01(),new Constant()));
        
        world.register(new Deco(13,17.2,0.35,0.5,"digit.2",-1));
        world.register(new Exit(13,16,new Lvl02(),new Constant()));

        world.register(new Deco(16,17.2,0.35,0.5,"digit.3",-1));
        world.register(new Exit(16,16,new Lvl03(),new Constant()));

        world.register(new Deco(19,17.2,0.35,0.5,"digit.4",-1));
        world.register(new Exit(19,16,new Lvl04(),new Constant()));

        world.register(new Deco(22,17.2,0.35,0.5,"digit.5",-1));
        world.register(new Deco(22,16,1,0.6,"underconstruction2",1));
        world.register(new Exit(22,16,new Menu(),new Not(new Constant())));
        
        // Doors lvl 6-10
        world.register(new Deco(10,12.2,0.35,0.5,"digit.6",-1));
        world.register(new Deco(10,11,1,0.6,"underconstruction2",1));
        world.register(new Exit(10,11,new Menu(),new Not(new Constant())));

        world.register(new Deco(13,12.2,0.35,0.5,"digit.7",-1));
        world.register(new Deco(13,11,1,0.6,"underconstruction2",1));
        world.register(new Exit(13,11,new Menu(),new Not(new Constant())));

        world.register(new Deco(16,12.2,0.35,0.5,"digit.8",-1));
        world.register(new Deco(16,11,1,0.6,"underconstruction2",1));
        world.register(new Exit(16,11,new Menu(),new Not(new Constant())));
        
        world.register(new Deco(19,12.2,0.35,0.5,"digit.9",-1));
        world.register(new Deco(19,11,1,0.6,"underconstruction2",1));
        world.register(new Exit(19,11,new Menu(),new Not(new Constant())));
        
        world.register(new Deco(21.8,12.2,0.35,0.5,"digit.1",-1));
        world.register(new Deco(22.2,12.2,0.35,0.5,"digit.0",-1));
        world.register(new Deco(22,11,1,0.6,"underconstruction2",1));
        world.register(new Exit(22,11,new Menu(),new Not(new Constant())));
        
	}
}
