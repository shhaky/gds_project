package nl.fontys.cryptoexchange.core.exeptions;

import nl.fontys.cryptoexchange.core.Order;

public class NotSameCurrencyPairExeption extends Exception {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	public NotSameCurrencyPairExeption(Order order1, Order order2) {
		super("you can not compare an Order from type "+ order1.getCurrencyPair().toString() + " with an Order from type " + order2.getCurrencyPair().toString());
		
	}
	
	
}

