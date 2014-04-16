package nl.fontys.cryptoexchange.core;

import java.math.BigDecimal;

/**
 * @author Tobias Zobrist
 * @version 1.0
 * @created 16-Apr-2014 16:34:32
 */
public class SellOrder extends Order {

	public SellOrder(CurrencyPair currencyPair, long orderId,
			BigDecimal volume, BigDecimal price) {
		super(currencyPair, orderId, volume, price);
	}

	@Override
	public OrderType getType() {
		return OrderType.SELL;
	}


}