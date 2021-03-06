package nl.fontys.cryptoexchange.core;

import java.math.BigDecimal;
import java.util.Calendar;
import java.util.Date;

import javax.xml.bind.annotation.XmlRootElement;

import org.apache.log4j.Logger;

import nl.fontys.cryptoexchange.core.exception.IllegalTradeException;
import nl.fontys.cryptoexchange.core.exception.NoMatchingPriceException;

/**
 * @author Tobias Zobrist
 * @version 1.0
 * @created 16-Apr-2014 14:05:14 This is a Data Object that is representing a
 *          Trade.
 */
@XmlRootElement
public final class Trade {

	public OrderType getType() {
		return type;
	}

	public CurrencyPair getCurrencyPair() {
		return currencyPair;
	}

	public BigDecimal getPrice() {
		return price;
	}

	public long getTradeId() {
		return tradeId;
	}

	public long getBuyOrderId() {
		return buyOrderId;
	}

	public long getSellOrderId() {
		return sellOrderId;
	}

	public BigDecimal getVolume() {
		return volume;
	}

	public Date getTimeStamp() {
		return timeStamp;
	}

	/**
	 * @param newOrder
	 *          the Order coming in to compare with the order book
	 * @param orderInOrderBook
	 *          The order witch is already in the order book
	 * @throws IllegalTradeException
	 *           if the two orders are not from the same CurrencyPair
	 * @throws NoMatchingPriceException
	 */
	public Trade(Order newOrder, Order orderInOrderBook) throws IllegalTradeException, NoMatchingPriceException {

		this.timeStamp = Calendar.getInstance().getTime();

		this.tradeId = IdGenerator.getInstance().getTradeId();
		log.trace("Trade executed ID=" + tradeId);
		this.type = newOrder.getType();

		//check witch volume is bigger the trade volume will be the smaller one

		if (newOrder.getVolume().subtract(orderInOrderBook.getVolume()).signum() == 1) {
			this.volume = orderInOrderBook.getVolume();
		} else {
			this.volume = newOrder.getVolume();
		}

		//check if the orders match
		if (!newOrder.getCurrencyPair().equals(orderInOrderBook.getCurrencyPair())) {
			throw new IllegalTradeException(newOrder, orderInOrderBook);
		}

		this.currencyPair = newOrder.getCurrencyPair();
		//always take price from order book

		this.price = orderInOrderBook.getPrice();

		if (newOrder.getType() == OrderType.BUY) {
			this.buyOrderId = newOrder.getOrderId();
			this.sellOrderId = orderInOrderBook.getOrderId();
		} else if (newOrder.getType() == OrderType.SELL) {
			this.buyOrderId = orderInOrderBook.getOrderId();
			this.sellOrderId = newOrder.getOrderId();
		} else {
			throw new IllegalTradeException(newOrder, orderInOrderBook);
		}

		//check if the orders have a matching price

		if (newOrder.getPrice().subtract(orderInOrderBook.getPrice()).signum() == 1 && this.type == OrderType.SELL
						|| newOrder.getPrice().subtract(orderInOrderBook.getPrice()).signum() == -1 && this.type == OrderType.BUY) {
			throw new NoMatchingPriceException();
		}

	}

	public String toString() {
		return "Trade [type=" + type + ", volume=" + volume + ", currencyPair=" + currencyPair + ", price=" + price + ", timestamp=" + timeStamp + ", trade ID="
						+ tradeId + ", order ID sell=" + sellOrderId + " , order ID buy=" + buyOrderId + "]";
	}

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + (int) (buyOrderId ^ (buyOrderId >>> 32));
		result = prime * result + ((currencyPair == null) ? 0 : currencyPair.hashCode());
		result = prime * result + ((price == null) ? 0 : price.hashCode());
		result = prime * result + (int) (sellOrderId ^ (sellOrderId >>> 32));
		result = prime * result + (int) (tradeId ^ (tradeId >>> 32));
		result = prime * result + ((type == null) ? 0 : type.hashCode());
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj) {
			return true;
		}

		if (obj == null || getClass() != obj.getClass()) {
			return false;
		}

		// has to be a Trade Class now
		return this.tradeId == ((Trade) obj).getTradeId();
	}

	private final OrderType type;

	private final CurrencyPair currencyPair;

	private final BigDecimal price;

	private final BigDecimal volume;

	private final Date timeStamp;

	private final long tradeId;

	private final long buyOrderId;

	private final long sellOrderId;

	private final Logger log = Logger.getLogger(Trade.class);

}//end Trade