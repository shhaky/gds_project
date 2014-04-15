package nl.fontys.cryptoexchange.engine;

import nl.fontys.cryptoexchange.core.Order;

/**
 * This Class implements Runnable and gets associated with a job the Agent is
 * doing the job and then he dies
 * 
 * he will look in the orderbook for a matching trade
 * 
 * if found he will send the Trade to the TradeHistory
 * 
 * If not found he will add the Trade to the Orderbook
 * @author Tobias Zobrist
 * @version 1.0
 * @created 06-Apr-2014 15:03:54
 */
public class TradeAgent implements Runnable {



	/**
	 * 
	 * @param order
	 */
	public TradeAgent(Order order){
	
	}

	
	@Override
	public void run() {
		// TODO Auto-generated method stub
		
	}
}