package nl.fontys.cryptoexchange.core.exception;

import nl.fontys.cryptoexchange.core.CurrencyPair;

public class MarketNotAvailableException extends Exception {
	public MarketNotAvailableException(CurrencyPair pair) {

		super("Market: " + pair.toString() + " does not exist yet please create first");

	}

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

}
