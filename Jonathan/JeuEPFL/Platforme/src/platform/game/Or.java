package platform.game;

public class Or implements Signal{
	private Signal right;
	private Signal left;
	
	/**
     * Combine two signals with OR.
     * @param left first signal, not null
     * @param right second signal, not null
     */
	public Or(Signal left, Signal right) {
		if (left == null || right == null)
			throw new NullPointerException();
		this.left = left;
		this.right = right;
	}
	
	public boolean isActive() {
		return right.isActive() || left.isActive();
	}
}
