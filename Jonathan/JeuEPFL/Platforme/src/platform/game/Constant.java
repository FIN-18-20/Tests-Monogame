package platform.game;

public class Constant implements Signal{
	private final boolean signal = true;
	
	/**
     * Create new Constantly true signal.
     */
	public Constant() {}
	
	public boolean isActive() {
		return signal;
	}
}
