package platform.game.level;

import platform.util.Vector;

import java.awt.event.KeyEvent;

import platform.game.*;

public class Lvl04_1 extends Level {
	

	public void register(World world) {
        super.register(world);
        
     // Register a new instance, to restart level automatically
        world.setNextLevel(new Lvl04_1());
        
     // Construct terrain
        world.register(new Limits(200,250));
        world.register(new Terrain(-27.5,-15,28,56,"snow"));//gauche
        world.register(new Exit(-4,41.25,new Lvl04(),new Constant()));
        Key yellow1 = new Key(9,40,"yellow");
        Key yellow8 = new Key(18,29,"yellow");
        Key red1 = new Key(18,24,"red");
        Key yellow3 = new Key(18,19,"yellow");
        Key yellow4 = new Key(18,14,"yellow");
        Key yellow5 = new Key(18,9,"yellow");
        Key yellow6 = new Key(18,4,"yellow");
        Key yellow7 = new Key(18,-1,"yellow");
        world.register(new Terrain(20,41,19,1,"snow"));
        world.register(new Terrain(26,36,7,6,"snow"));
        world.register(new Door(28,35,"yellow", red1));
        world.register(new Door(29,35,"yellow", red1));
        world.register(new Door(30,35,"yellow", red1));
        Key yellow2 = new Key(41,40,"yellow");
        Key yellow9 = new Key(41,39,"yellow");
        Key yellow10 = new Key(41,38,"yellow");
        Key yellow11 = new Key(41,37,"yellow");
        Key yellow12 = new Key(41,36,"yellow");
        Key yellow13 = new Key(41,43,"yellow");
        Key yellow14 = new Key(41,42,"yellow");
        Key yellow15 = new Key(41,41,"yellow");
        Key yellow16 = new Key(47,35,"yellow");
        Key yellow17 = new Key(47,36,"yellow");
        Key yellow18 = new Key(47,37,"yellow");
        Key yellow19 = new Key(47,38,"yellow");
        Key yellow20 = new Key(47,39,"yellow");
        Key yellow21 = new Key(47,40,"yellow");
        Key yellow22 = new Key(47,41,"yellow");
        Key yellow23 = new Key(47,42,"yellow");
        world.register(new Block(46.5,36.5,0.5,0.5,"snow"));
        world.register(new Block(41.5,37.5,0.5,0.5,"snow"));
        world.register(new Block(41.5,39.5,0.5,0.5,"snow"));
        world.register(new Block(41.5,41.5,0.5,0.5,"snow"));
        world.register(new Block(46.5,38.5,0.5,0.5,"snow"));
        world.register(new Block(46.5,40.5,0.5,0.5,"snow"));
        Key yellow24 = new Key(46,42,"yellow");
        Key yellow25 = new Key(45,42,"yellow");
        Key yellow26 = new Key(46,40.3,"yellow");
        Key yellow27 = new Key(42,41.3,"yellow");
        Key yellow28 = new Key(42,39.3,"yellow");
        Key yellow29 = new Key(42,37.3,"yellow");
        Key yellow31 = new Key(46,38.3,"yellow");
        Key yellow30 = new Key(48.5,43,"yellow");
        Key yellow32 = new Key(48.5,42,"yellow");
        Key yellow33 = new Key(48.5,41,"yellow");
        Key yellow34 = new Key(48.5,40,"yellow");
        Key yellow35 = new Key(48.5,39,"yellow");
        Key yellow36 = new Key(48.5,38,"yellow");
        Key yellow37 = new Key(48.5,37,"yellow");
        Key yellow38 = new Key(48.5,36,"yellow");
        Key yellow39 = new Key(53,43,"yellow");
        Key yellow40 = new Key(52,43,"yellow");
        Key yellow41 = new Key(51,43,"yellow");
        Key yellow42 = new Key(57,43,"yellow");
        Key yellow43 = new Key(59,43,"yellow");
        Key yellow44 = new Key(61,41,"yellow");
        Key yellow45 = new Key(60,41,"yellow");
        Key yellow46 = new Key(59,37,"yellow");
        Key yellow47 = new Key(60,37,"yellow");
        Key yellow48 = new Key(55,37,"yellow");
        Key yellow49 = new Key(57,39,"yellow");
        Key yellow50 = new Key(55,41,"yellow");
        Key blue1 = new Key(61,40,"blue");
        world.register(new Door(62,35,"yellow", blue1));
        
        world.register(new Terrain(54,36,1,10,"snow"));
        world.register(new Terrain(58,34,1,10,"snow"));
        world.register(new Terrain(54,45,9,1,"snow"));
        world.register(new Terrain(62,36,1,10,"snow"));
        world.register(new Laser(70,35,20,"h",new Constant()));
        world.register(new Laser(70,36,20,"h",new Constant()));
        world.register(new Terrain(69,35,1,2,"snow"));
        world.register(new Terrain(90,35,1,2,"snow"));
        
        world.register(new Door(31,34,"blue",yellow1));
        world.register(new Door(32,34,"blue",yellow1));
        world.register(new Door(27,34,"blue",yellow1));
        world.register(new Door(26,34,"blue",yellow1));
        world.register(new Door(29,34,"blue",yellow1));
        world.register(new Door(28,34,"blue",yellow1));
        world.register(new Door(30,34,"blue",yellow1));
        world.register(new Laser(26,33,7,"h",new Constant()));
        
        world.register(new Exit(95,35.25,new Lvl_Select(), new Constant()));
        world.register(new Checkpoint(51,36,10, new Lvl04_2()));
        
        
        
        
        
        world.register(new Terrain(0,-15,16,50,"snow"));//bas
        world.register(new Terrain(15,34,2,1,"snow"));//bas
        world.register(new Terrain(20,34,2,1,"snow"));//bas
        world.register(new Terrain(21,-15,5,50,"snow"));//bas
        world.register(new Terrain(33,-15,66,50,"snow"));//bas
        world.register(new Terrain(26,-15,7,47,"snow"));//bas
        
        
        Player player = new Player(new Vector(35,35));
        Torch torch1 = new Torch(5,36,false);
        world.register(player);
        world.register(torch1);
        world.register(new Hat(player));
        world.register(new Overlay(player));
        world.register(yellow1);
        world.register(red1);
        world.register(yellow3);
        world.register(yellow4);
        world.register(yellow5);
        world.register(yellow6);
        world.register(yellow7);
        world.register(yellow8);
        world.register(yellow9);
        world.register(yellow10);
        world.register(yellow11);
        world.register(yellow12);
        world.register(yellow15);
        world.register(yellow14);
        world.register(yellow13);
        world.register(yellow2);
        world.register(yellow16);
        world.register(yellow17);
        world.register(yellow18);
        world.register(yellow19);
        world.register(yellow20);
        world.register(yellow21);
        world.register(yellow22);
        world.register(yellow23);
        world.register(yellow24);
        world.register(yellow25);
        world.register(yellow26);
        world.register(yellow27);
        world.register(yellow28);
        world.register(yellow29);
        world.register(yellow31);
        world.register(yellow30);
        world.register(yellow32);
        world.register(yellow33);
        world.register(yellow34);
        world.register(yellow35);
        world.register(yellow36);
        world.register(yellow37);
        world.register(yellow38);
        world.register(yellow39);
        world.register(yellow40);
        world.register(yellow41);
        world.register(yellow42);
        world.register(yellow43);
        world.register(yellow44);
        world.register(yellow45);
        world.register(yellow46);
        world.register(yellow47);
        world.register(yellow48);
        world.register(yellow49);
        world.register(yellow50);
        world.register(blue1);
        world.register(new Mover(new Vector(-4,41.5),3,2,new Vector(-4,1500),"stone.2", torch1,0.25));
        world.register(new Block(46.76,35,0.005,10.5,"empty"));
        world.register(new Door(74,37,"blue",new Or(yellow2,new Or(yellow9,new Or(yellow10,new Or(yellow11,new Or(yellow12,new Or(yellow13,new Or(yellow14,new Or(yellow15,new Or(yellow16,new Or(yellow17,new Or(yellow18,new Or(yellow19,new Or(yellow20,new Or(yellow21,new Or(yellow22,new Or(yellow23,new Or(yellow24,new Or(yellow25,new Or(yellow26,new Or(yellow27,new Or(yellow28,new Or(yellow29,new Or(yellow30,new Or(yellow31,new Or(yellow32,new Or(yellow33,new Or(yellow34,new Or(yellow35,new Or(yellow36,new Or(yellow37,new Or(yellow38,new Or(yellow39,new Or(yellow40,new Or(yellow41,new Or(yellow42,new Or(yellow43,new Or(yellow44,new Or(yellow45,new Or(yellow46,new Or(yellow47,new Or(yellow48,new Or(yellow49,yellow50))))))))))))))))))))))))))))))))))))))))))));
        world.register(new Door(79,37,"blue",new Or(yellow2,new Or(yellow9,new Or(yellow10,new Or(yellow11,new Or(yellow12,new Or(yellow13,new Or(yellow14,new Or(yellow15,new Or(yellow16,new Or(yellow17,new Or(yellow18,new Or(yellow19,new Or(yellow20,new Or(yellow21,new Or(yellow22,new Or(yellow23,new Or(yellow24,new Or(yellow25,new Or(yellow26,new Or(yellow27,new Or(yellow28,new Or(yellow29,new Or(yellow30,new Or(yellow31,new Or(yellow32,new Or(yellow33,new Or(yellow34,new Or(yellow35,new Or(yellow36,new Or(yellow37,new Or(yellow38,new Or(yellow39,new Or(yellow40,new Or(yellow41,new Or(yellow42,new Or(yellow43,new Or(yellow44,new Or(yellow45,new Or(yellow46,new Or(yellow47,new Or(yellow48,new Or(yellow49,yellow50))))))))))))))))))))))))))))))))))))))))))));
        world.register(new Door(84,37,"blue",new Or(yellow2,new Or(yellow9,new Or(yellow10,new Or(yellow11,new Or(yellow12,new Or(yellow13,new Or(yellow14,new Or(yellow15,new Or(yellow16,new Or(yellow17,new Or(yellow18,new Or(yellow19,new Or(yellow20,new Or(yellow21,new Or(yellow22,new Or(yellow23,new Or(yellow24,new Or(yellow25,new Or(yellow26,new Or(yellow27,new Or(yellow28,new Or(yellow29,new Or(yellow30,new Or(yellow31,new Or(yellow32,new Or(yellow33,new Or(yellow34,new Or(yellow35,new Or(yellow36,new Or(yellow37,new Or(yellow38,new Or(yellow39,new Or(yellow40,new Or(yellow41,new Or(yellow42,new Or(yellow43,new Or(yellow44,new Or(yellow45,new Or(yellow46,new Or(yellow47,new Or(yellow48,new Or(yellow49,yellow50))))))))))))))))))))))))))))))))))))))))))));
	}
}
