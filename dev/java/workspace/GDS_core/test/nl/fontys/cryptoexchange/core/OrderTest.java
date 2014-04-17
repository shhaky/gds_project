package nl.fontys.cryptoexchange.core;

import java.math.BigDecimal;

public class OrderTest {
	
	/**
	 * 
	 * @author Tobias Zobrist
	 * @version 1.0
	 * @created 16-Apr-2014 16:18:14
	 * 
	 *
	 * provides some Test Orders
	 */
	
	//test values
	public final static long USER1_ID = 33333;
	
	public final static long USER2_ID = 44444;
	
	public static final int HIGH_VOLUME = 50;
	public static final int LOW_VOLUME = 20;
	//User 1
	public final static Order ORDER_BUY_LOW_USER_1 = new BuyOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(LOW_VOLUME), new BigDecimal(10),USER1_ID);
	public final static Order ORDER_BUY_HIGH_USER_1 = new BuyOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(HIGH_VOLUME), new BigDecimal(50),USER1_ID);
	
	public final static Order ORDER_SELL_LOW_USER1 = new SellOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(LOW_VOLUME), new BigDecimal(10),USER1_ID);
	public final static Order ORDER_SELL_HIGH_USER1 = new SellOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(),  new BigDecimal(HIGH_VOLUME), new BigDecimal(50),USER1_ID);
	
	public final static Order ORDER_BUY_OTHER_CURRECNY_USER1 = new BuyOrder(CurrencyPair.DOGE_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(HIGH_VOLUME), new BigDecimal(50),USER1_ID);
	//User2
	public final static Order ORDER_BUY_LOW_USER_2 = new BuyOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(LOW_VOLUME), new BigDecimal(10),USER2_ID);
	public final static Order ORDER_BUY_HIGH_USER_2 = new BuyOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(HIGH_VOLUME), new BigDecimal(50),USER2_ID);
	
	public final static Order ORDER_SELL_LOW_USER2 = new SellOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(LOW_VOLUME), new BigDecimal(10),USER2_ID);
	public final static Order ORDER_SELL_HIGH_USER2 = new SellOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(),  new BigDecimal(HIGH_VOLUME), new BigDecimal(50),USER2_ID);
	
	public final static Order ORDER_BUY_OTHER_CURRECNY_USER2 = new BuyOrder(CurrencyPair.DOGE_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(HIGH_VOLUME), new BigDecimal(50),USER2_ID);

	
	
}

