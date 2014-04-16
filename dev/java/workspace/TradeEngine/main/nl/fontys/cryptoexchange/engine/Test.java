package nl.fontys.cryptoexchange.engine;

import java.math.BigDecimal;

import nl.fontys.cryptoexchange.core.CurrencyPair;
import nl.fontys.cryptoexchange.core.Order;
import nl.fontys.cryptoexchange.core.OrderType;

public class Test {

	
	public static void main(String[] args) {
		Order highOrder = new Order(CurrencyPair.DOGE_BTC, 545445, OrderType.SELL, new BigDecimal(501), new BigDecimal(10));
		
		Order mediumOrder = new Order(CurrencyPair.DOGE_BTC, 545445, OrderType.SELL, new BigDecimal(500), new BigDecimal(5));
		
		Order lowOrder = new Order(CurrencyPair.DOGE_BTC, 545445, OrderType.SELL, new BigDecimal(500), new BigDecimal(2));
		
		OrderBook book = new BidOrderBook();
		
		book.add(lowOrder);
		
		book.add(mediumOrder);
		
		book.add(highOrder);
		
		System.out.println(book);
		
		
	}
}
