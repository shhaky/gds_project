package nl.fontys.cryptoexchange.core;

import java.math.BigDecimal;
import java.util.Calendar;
import java.util.Date;

import org.apache.log4j.Logger;
import org.json.JSONObject;

/**
 * Data object representing an order, an order that is not executed yet!
 * 
 * 
 * @author Tobias Zobrist
 * @version 1.0
 * @updated 15-Apr-2014 02:43
 */
public abstract class Order implements Comparable<Order> {
	
	public Order(CurrencyPair currencyPair, long orderId, BigDecimal volume, BigDecimal price) {
		
		this.currencyPair = currencyPair;
		this.orderId = orderId;
		this.volume = volume;
		this.price = price;
		
		this.timeStamp = Calendar.getInstance().getTime();
		
		
	}
	private final CurrencyPair currencyPair;
	private final long orderId;
	private Logger log = Logger.getLogger(Order.class);
	
	
	/**
	 * creation date of the instance
	 */
	private final Date timeStamp;
	private final BigDecimal volume;
	private final BigDecimal price;



	public CurrencyPair getCurrencyPair(){
		return this.currencyPair;
	}
	
	public BigDecimal getPrice(){
		return this.price;
	}

	public long getOrderId(){
		return this.orderId;
	}

	public java.util.Date getTimeStamp(){
		return this.timeStamp;
	}

	public abstract OrderType getType();

	public BigDecimal getVolume(){
		return this.volume;
	}

	//TODO
	public JSONObject toJson(){
		
		return null;
	}
		  @Override
		  public String toString() {

		    return "Order [type=" + this.getType() + ", volume=" + volume + ", currencyPair=" + currencyPair + ", id=" + orderId + ", timestamp=" + timeStamp + "]";
		  }
	

	@Override
	public int compareTo(Order order) {
		
		
		//TODO we should find a more proper solution here, problem cause of override we cant declare that this method should throw an exeption!
		if(!this.currencyPair.equals(order.getCurrencyPair()))
		{
			log.error("orders with different CurrencyPairs have been compared!");
		}
		
		
		return this.price.compareTo(order.getPrice());
	}
}
