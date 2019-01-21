package platform.game;

public class And implements Signal {
	private Signal left;
	private Signal right;
	
	/**
     * Combine two signals with AND.
     * @param left first signal, not null
     * @param right second signal, not null
     */
	public And(Signal left, Signal right) {
		if (left == null || right == null)
			throw new NullPointerException();
		this.left = left;
		this.right = right;
	}
	
	public boolean isActive() {
		return left.isActive() && right.isActive() ;
		}
}
