package nl.fontys.cryptoexchange.core.exception;

import nl.fontys.cryptoexchange.core.Order;

/**
 * @author Tobias Zobrist
 * @version 1.0
 * @created 16-Apr-2014 14:50:14 this Exeption is thrown if a Trade is not
 *          possible between 2 Orders
 */
public class IllegalTradeException extends Exception {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1113492265103154233L;

	public IllegalTradeException(Order order1, Order order2) {

		super(order1 + " and " + order2 + " are not tradable");

	}
}
