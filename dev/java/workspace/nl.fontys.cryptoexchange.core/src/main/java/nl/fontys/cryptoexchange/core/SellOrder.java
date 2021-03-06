package nl.fontys.cryptoexchange.core;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlRootElement;

/**
 * @author Tobias Zobrist
 * @version 1.0
 * @created 16-Apr-2014 16:34:32
 */

@XmlRootElement
public final class SellOrder extends Order {

	public SellOrder(CurrencyPair currencyPair, long orderId, BigDecimal volume, BigDecimal price, long userId) {
		super(currencyPair, orderId, volume, price, userId);
		// TODO Auto-generated constructor stub
	}

	public SellOrder(Order order) {
		
		super(order);
	}
	
	/**
	 * used by XML Mapper
	 */

	public SellOrder() {
	}
	
	
	@Override
	public OrderType getType() {
		return OrderType.SELL;
	}

}