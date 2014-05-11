package nl.fontys.cryptoexchange.core.exception;

import nl.fontys.cryptoexchange.core.Order;

public class IllegalOrderCloneExeption extends Exception {

	/**
	 * 
	 */
	private static final long serialVersionUID = -8426975896904069184L;
	
	public IllegalOrderCloneExeption(Order order1, Order order2) {
		super("can not create rest order from CurrencyPair " + order1.getCurrencyPair() + " and Currencypair " + order2.getCurrencyPair());
	}

}
