package nl.fontys.cryptoexchange.core;

import java.math.BigDecimal;
import java.util.Calendar;
import java.util.Date;

import org.json.JSONObject;

/**
 * Data object representing an order
 * @author Ratidzo Zvirawa, Tobias Zobrist
 * @version 1.0
 * @updated 04-Apr-2014 14:03:43
 */
public class Order {
	
	public Order(CurrencyPair currencyPair, long orderId, OrderType type, BigDecimal volume) {
		
		this.currencyPair = currencyPair;
		this.orderId = orderId;
		this.type = type;
		this.volume = volume;
		
		this.timeStamp = Calendar.getInstance().getTime();
		
		
	}
	private final CurrencyPair currencyPair;
	private final long orderId;
	
	
	/**
	 * creation date of the instance
	 */
	private final Date timeStamp;
	private final OrderType type;
	private final BigDecimal volume;



	public int compareTo(){
		return 0;
	}

	public CurrencyPair getCurrencyPair(){
		return null;
	}

	public long getId(){
		return 0;
	}

	public java.util.Date getTimeStamp(){
		return null;
	}

	public OrderType getType(){
		return null;
	}

	public java.math.BigDecimal getVolume(){
		return null;
	}

	public JSONObject toJson(){
		return null;
	}

	public String toString(){
		return "";
	}
}
