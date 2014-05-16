package nl.fontys.cryptoexchange.core.exception;

import nl.fontys.cryptoexchange.core.CurrencyPair;

public class InvalidCurrencyPairException extends Exception {

	public InvalidCurrencyPairException(CurrencyPair pair) {
		
		super("CurrencyPair " + pair.toString() + " is invalid!");
		
	}
	
	
	public InvalidCurrencyPairException(String pair) {
		
		super("CurrencyPair " + pair + " is invalid!");
	}


	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

}
