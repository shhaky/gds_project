package nl.fontys.cryptoexchange.core.exception;

public class NoMatchingPriceException extends Exception {

	/**
	 * 
	 */
	private static final long serialVersionUID = -910153785545665695L;

	public NoMatchingPriceException() {

		super("the prices of the Orders do not match");
	}

}
