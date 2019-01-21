package platform.game;

public class Not implements Signal{
	private final Signal signal ;
	
	/**
     * Inverse a signal.
     * @param signal signal to change, not null
     */
	public Not(Signal signal) {
		if (signal == null)
			throw new NullPointerException() ;
		this.signal = signal ;
	}
	
	public boolean isActive() {
		return !signal.isActive() ;
	}
}
