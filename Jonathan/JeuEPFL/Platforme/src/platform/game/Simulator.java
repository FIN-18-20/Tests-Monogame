package platform.game;

import platform.game.level.Level;
import java.util.ArrayList;
import java.util.List;

import platform.util.Input;
import platform.util.Loader;
import platform.util.Output;
import platform.util.Vector;
import platform.util.View;
import platform.util.SortedCollection;
import platform.game.Actor;
import platform.util.Box;
/**
 * Basic implementation of world, managing a complete collection of actors.
 */
public class Simulator implements World {

    private Loader loader;
    private Vector currentCenter ;
    private double currentRadius ;
    private Vector expectedCenter = Vector.ZERO;
    private double expectedRadius = 10.0;
    private List<Actor> registered = new ArrayList<Actor>();
    private List<Actor> unregistered = new ArrayList<Actor>();
    private SortedCollection<Actor> actors = new SortedCollection<Actor>();
    private Level next;
    private boolean transition = true;
    
    /**
    * Create a new simulator.
    * @param loader associated loader , not null
    * @param args level arguments , not null
    */
    public Simulator(Loader loader , String[] args) {
    	if (loader == null) {
    		throw new NullPointerException() ;
    	}
    	this.loader = loader ;
    	currentCenter = Vector.ZERO ;
    	currentRadius = 10.0 ;
    }
    
    /**
     * Simulate a single step of the simulation.
     * @param input input object to use, not null
     * @param output output object to use, not null
     */
    
	public void update(Input input, Output output) {
		// Preupdate tous les acteurs
		for (Actor a : actors)
			a.preUpdate(input);
		
		// transition fluide de la vue
		double factor = 0.2;
		currentCenter = currentCenter.mul(1.0 - factor).add(expectedCenter.mul(factor)) ;
		currentRadius = currentRadius * (1.0 - factor) + expectedRadius * factor ;
		
		// on definit la vue
		View view = new View(input , output);
		view.setTarget(currentCenter , currentRadius);
		
		// trouver priorites et définir s'ils vont interagir
		for (Actor actor : actors)
			for (Actor other : actors)
				if (actor.getPriority() > other.getPriority()) {
					actor.interact(other); }
		
		// Apply update
		for (Actor a : actors)
			a.update(view) ;
		
		// Draw everything
		for (Actor a : actors.descending())
			a.draw(view, view) ;
		
		// Add registered actors
		for (int i = 0 ; i < registered.size() ; ++i) {
			Actor actor = registered.get(i) ;
			actor.register(this);
			if ( !actors.contains(actor)) {
				actors.add(actor) ;
			}
		}
		registered.clear() ;
				
		// Remove unregistered actors
		for (int i = 0 ; i < unregistered.size() ; ++i) {
			Actor actor = unregistered.get(i) ;
			actor.unregister();
			actors.remove(actor) ;
		}
		unregistered.clear() ;
		
		// PostUpdate tout les acteurs
		for (Actor a: actors)
			a.postUpdate(view);
		
		// si un acteur a mis transition à true pour demander le passage à un autre niveau :
		if (transition) {
		if (next == null) {
		next = Level.createDefaultLevel() ;
		}
		
		// si un acteur a appelé setNextLevel , next ne sera pas null :
		Level level = next ;
		transition = false ;
		next = null ;
		actors.clear() ;
		registered.clear() ;
		
		// tous les anciens acteurs sont désenregistrés,
		// y compris le Level précédent :
		unregistered.clear();
		register(level);
		}
		
	}
	
	@Override
    public void setView(Vector center , double radius) {
    	if (center == null)
    		throw new NullPointerException() ;
    	if (radius <= 0.0)
    		throw new IllegalArgumentException("radius must be positive") ;
    expectedCenter = center ;
    expectedRadius = radius ;
	}

    @Override
    public Loader getLoader() {
        return loader;
    }

    @Override
    public void register(Actor actor) {
    	registered.add(actor) ;
    }
    
    @Override
    public void unregister(Actor actor) {
    	unregistered.add(actor) ;
    }
    
	@Override
	public Vector getGravity() {
		return new Vector(0.0,-9.81);
	}
	
	@Override
	public void nextLevel() {
		transition = true;
	}
	
	@Override
	public void setNextLevel(Level level) {
		next = level;
	}
	
	@Override
	public int hurt(Box area, Actor instigator , Damage type, double amount , Vector location) {
		int victims = 0 ;
		for (Actor actor : actors)
			if (actor != instigator && area.isColliding(actor.getBox()))
				if (actor.hurt(instigator , type, amount , location))
					++victims ;
		return victims ;
	}
 
}
