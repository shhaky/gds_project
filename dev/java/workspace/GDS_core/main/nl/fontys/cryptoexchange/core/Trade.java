package nl.fontys.cryptoexchange.core;

import java.math.BigDecimal;

/**
 * This is a Data Object that is representing a Trade
 * @author Ratidzo Zvirawa, Tobias Zobrist
 * @version 1.0
 * @created 04-Apr-2014 14:05:14
 */
public class Trade {

	private final OrderType type;
	private final CurrencyPair currencyPair;
	private final BigDecimal price;
	private final long tradeId;
	private final long buyOrderId;
	private final long sellOrderId;

	
public Trade(CurrencyPair currencyPair, OrderType type, BigDecimal price, long buyOrderId, long sellOrderId ) {
	this.type = type;
	
	this.currencyPair = currencyPair;
	this.price = price;
	this.buyOrderId = buyOrderId;
	this.sellOrderId = sellOrderId;
	
	
	this.tradeId = IdGenerator.getInstance().getTradeId();
	
	
}
	public void finalize() throws Throwable {

	}
	public String toString(){
		return "";
	}

	public int compareTo(){
		return 0;
	}
}//end Trade