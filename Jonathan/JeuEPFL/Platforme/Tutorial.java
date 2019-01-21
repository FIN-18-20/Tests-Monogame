package platform.game.level;

import platform.util.Box;
import platform.util.Vector;
import platform.game.*;

public class Tutorial extends Level {

    @Override
    public void register(World world) {
        super.register(world);
        
        // Register a new instance, to restart level automatically
        world.setNextLevel(new Tutorial());
        
        // Background
        world.register(new Background(6,6,0.5,0.5,"UP"));
        world.register(new Background(37,5,0.5,0.5,"DOWN"));
        
        // Create terrain
        world.register(new Limits(50,50));

        world.register(new Terrain(0,5,7,1,"snow"));

        world.register(new Terrain(9,6,2,1,"snow"));

        world.register(new Terrain(13,7,7,1,"snow"));
        
        world.register(new Terrain(23,4,2,1,"snow"));
        
        world.register(new Terrain(35,4,10,1,"snow"));
        
        world.register(new Terrain(38,5.3,4,8,"snow"));

        world.register(new Terrain(45,4,5,12,"snow"));
        
        world.register(new Terrain(42,8,1,1,"snow"));
        
        world.register(new Spike(35,11.8,3));
        
        world.register(new Terrain(35,11,3,1,"castle"));
 
        world.register(new Terrain(32,11,3,2,"snow"));
        
        world.register(new Terrain(26,13,4,1,"snow"));
        
        world.register(new Terrain(14,13,10,1,"snow"));
        
        world.register(new Terrain(13,18,9,1,"snow"));
        
        world.register(new Terrain(21,15,1,4,"snow"));
        
        world.register(new Terrain(13,13,1,6,"snow"));

        
        // Other actors
        Player player = new Player(new Vector(2,6));
        Key blue = new Key(26,14,"blue");
        Lever lever = new Lever(23.5,4.7,false,Double.POSITIVE_INFINITY);
        Torch torch = new Torch(19,8,false);
        
        world.register(player);
        world.register(new Overlay(player));
        world.register(new Hat(player));
        world.register(torch);
        world.register(blue);
        world.register(lever);
        world.register(new Heart(32,13));
        world.register(new Jumper(new Vector(44,4.8)));
        world.register(new Jumper(new Vector(42,8.8)));
        world.register(new Door(21,14,"blue", blue));
        world.register(new Mover(new Vector(33,4), 3, 1, new Vector(26,4), "stone.2", lever));
        world.register(new Exit(15,14,new Menu(),new Constant()));
        
        // Deco
        world.register(new Deco(0,6.4,1,2,"foliagePack_030"));
        world.register(new Deco(0.6,6.3,0.8,1.8,"foliagePack_030"));
        
        world.register(new Deco(45.5,16.4,1,2,"foliagePack_030"));
        world.register(new Deco(46.5,16.3,0.8,1.8,"foliagePack_030"));
        world.register(new Deco(47,16.5,1.2,2.2,"foliagePack_030"));
        
    }
    
}
