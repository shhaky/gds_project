package nl.fontys.cryptoexchange.engine;

import java.util.ArrayList;

import nl.fontys.cryptoexchange.core.Trade;

/**
 * @author Tobias Zobrist
 * @version 1.0
 * @created 15-Apr-2014 15:56:10
 */
public class TemporaryTradeHistory {

	private ArrayList<Trade> list;
	public TradeEngineImplementation m_TradeEngineImplementation;

	public TemporaryTradeHistory(){

	}

	public void finalize() throws Throwable {

	}
	public Trade getLastTrade(){
		return null;
	}
}//end TemporaryTradeHistory