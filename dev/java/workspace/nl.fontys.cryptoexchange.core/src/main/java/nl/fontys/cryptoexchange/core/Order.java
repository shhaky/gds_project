package nl.fontys.cryptoexchange.core;

import java.math.BigDecimal;
import java.util.Calendar;
import java.util.Date;

import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlRootElement;

import nl.fontys.cryptoexchange.core.exception.IllegalOrderCloneExeption;

import org.apache.log4j.Logger;
import org.json.JSONObject;

/**
 * Data object representing an order, an order that is not executed yet!
 * 
 * @author Tobias Zobrist
 * @version 1.0
 * @updated 15-Apr-2014 02:43
 */
@XmlRootElement
public abstract class Order implements Comparable<Order> {
	public Order(CurrencyPair currencyPair, long orderId, BigDecimal volume, BigDecimal price, long userId) {

		this.currencyPair = currencyPair;
		this.orderId = orderId;
		this.volume = volume;
		this.price = price;
		this.userId = userId;
		this.timeStamp = Calendar.getInstance().getTime();

	}

	private final CurrencyPair currencyPair;

	private final long orderId;

	private Logger log = Logger.getLogger(Order.class);

	private static Logger sLog = Logger.getLogger(Order.class);

	/**
	 * creation date of the instance
	 */
	private final Date timeStamp;

	private final BigDecimal volume;

	private final BigDecimal price;

	private final long userId; //owner

	@XmlAttribute
	public CurrencyPair getCurrencyPair() {
		return this.currencyPair;
	}
	@XmlAttribute
	public BigDecimal getPrice() {
		return this.price;
	}
	@XmlAttribute
	public long getOrderId() {
		return this.orderId;
	}
	@XmlAttribute
	public Date getTimeStamp() {
		return this.timeStamp;
	}
	@XmlAttribute
	public abstract OrderType getType();
	@XmlAttribute
	public BigDecimal getVolume() {
		return this.volume;
	}
	@XmlAttribute
	public long getUserId() {
		return userId;
	}

		//TODO
		public String toJson(){
			
			return new JSONObject(this).toString();
		}

		  @Override
		  public String toString() {

		    return "Order [type=" + this.getType() + ", price=" + price + ", volume=" + volume + ", currencyPair=" + currencyPair + ", id=" + orderId + ", timestamp=" + timeStamp + "]";
		  }
	@Override
	public int compareTo(Order order) {

		//TODO we should find a more proper solution here, problem cause of override we cant declare that this method should throw an exeption!
		if (!this.currencyPair.equals(order.getCurrencyPair())) {

			log.warn("orders with different CurrencyPairs have been compared!");

		}

		return this.price.compareTo(order.getPrice());
	}

	/**
	 * this method will create the rest order when 2 orders are traded there is
	 * almost every time a rest volume left, it will match 2 Orders by volume and
	 * will return a clone Order with same ID and stuff but with the rest volume.
	 * IMPORTANT: will return null if both orders have the same volume
	 * 
	 * @param order1
	 * @param order2
	 * @return clone of the bigger order with the rest volume left
	 * @throws IllegalOrderCloneExeption
	 *           when there is a try to clone a rest order form 2 Orders of a
	 *           different CurrencyPair Type
	 */
	public static Order cloneRestOrder(Order order1, Order order2) throws IllegalOrderCloneExeption {

		if (!order1.getCurrencyPair().equals(order2.getCurrencyPair())) {
			throw new IllegalOrderCloneExeption(order1, order2);
		}

		Order orders[] = { order1, order2 };

		int index = 0;

		Order newOrder = null;
		BigDecimal volume = order1.getVolume().subtract(order2.getVolume());

		if (volume.signum() == 1) {
			//Order1 has bigger volumes
			sLog.debug("Order 1 has bigger volume Order1:" + order1 + " Order2:" + order2);
			index = 0;
		} else if (volume.signum() == -1) {
			sLog.debug("Order 2 has bigger volume Order1:" + order1 + " Order2:" + order2);
			//Order2 has bigger volume
			index = 1;
		} else if (volume.signum() == 0) {
			sLog.debug("orders have the same volume " + order1 + "  " + order2);
			return null;
		}

		//create new Order
		if (orders[index].getType() == OrderType.BUY) {
			newOrder = new BuyOrder(orders[index].getCurrencyPair(), orders[index].getOrderId(), volume.abs(), orders[index].getPrice(), orders[index].getUserId());
		} else if (orders[index].getType() == OrderType.SELL) {
			newOrder = new SellOrder(orders[index].getCurrencyPair(), orders[index].getOrderId(), volume.abs(), orders[index].getPrice(), orders[index].getUserId());
		} else {
			sLog.error("unable to clone Order!");
		}

		return newOrder;

	}
}
