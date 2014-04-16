package nl.fontys.cryptoexchange.core;

import java.math.BigDecimal;

/**
 * @author Tobias Zobrist
 * @version 1.0
 * @created 16-Apr-2014 16:34:41
 */
public class BuyOrder extends Order {

	public BuyOrder(CurrencyPair currencyPair, long orderId, 
			BigDecimal volume, BigDecimal price) {
		super(currencyPair, orderId, volume, price);
		// TODO Auto-generated constructor stub
	}

	@Override
	public OrderType getType() {
		return OrderType.BUY;
	}
	}