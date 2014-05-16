package nl.fontys.cryptoexchange.core;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlRootElement;

/**
 * @author Tobias Zobrist
 * @version 1.0
 * @created 16-Apr-2014 16:34:41
 */

@XmlRootElement
public final class BuyOrder extends Order {

	public BuyOrder(CurrencyPair currencyPair, long orderId, BigDecimal volume, BigDecimal price, long userId) {
		super(currencyPair, orderId, volume, price, userId);
		// TODO Auto-generated constructor stub
	}


	/**
	 * used by XML Mapper
	 */
	public BuyOrder() {
		super();
	}
	
	
	public BuyOrder(Order order) {
		super(order);
	}

	@Override
	public OrderType getType() {
		return OrderType.BUY;
	}
}
