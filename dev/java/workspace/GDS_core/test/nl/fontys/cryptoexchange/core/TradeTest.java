package nl.fontys.cryptoexchange.core;

import static org.junit.Assert.*;

import java.math.BigDecimal;

import nl.fontys.cryptoexchange.core.exception.IllegalTradeExeption;
import nl.fontys.cryptoexchange.core.exception.NoMatchingPriceExeption;

import org.apache.log4j.Logger;
import org.junit.Before;
import org.junit.Test;


/**
 * 
 * @author Tobias Zobrist
 * @version 1.0
 * @created 16-Apr-2014 16:18:14
 * 
 * 
 * This Case will thest the class Trade
 * 
 */
public class TradeTest {

	private Trade trade;
	
	private Order orderBUYlow;
	private Order orderBUYhigh;
	
	private Order orderSELLlow;
	private Order orderSELLhigh;
	
	private Order orderOtherCurrency;
	
	
	private static final int LOW_VOLUME = 20;
	
	private Logger log = Logger.getLogger(TradeTest.class);
	
	private static final int HIGH_VOLUME = 50;
	
	@Before
	public void setUp()
	{

		 orderBUYlow = new BuyOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(LOW_VOLUME), new BigDecimal(10));
		 orderBUYhigh = new BuyOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(HIGH_VOLUME), new BigDecimal(50));
			
		 orderSELLlow = new SellOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(LOW_VOLUME), new BigDecimal(10));
		 orderSELLhigh = new SellOrder(CurrencyPair.LTC_BTC, IdGenerator.getInstance().getOrderId(),  new BigDecimal(HIGH_VOLUME), new BigDecimal(50));
	
		 orderOtherCurrency = new BuyOrder(CurrencyPair.DOGE_BTC, IdGenerator.getInstance().getOrderId(), new BigDecimal(HIGH_VOLUME), new BigDecimal(50));
	
	}
	
	@Test
	public void testConstructorBuyOrderInMarket() {
		
		try {
			trade = new Trade(orderBUYhigh,orderSELLlow);
		} catch (IllegalTradeExeption | NoMatchingPriceExeption e) {
			
			e.printStackTrace();
		}
		
		log.info(trade);
		
		assertEquals(LOW_VOLUME, trade.getVolume().toBigInteger().intValue());
		assertEquals(OrderType.BUY, trade.getType());
		
	}
	
	
	@Test
	public void testConstructorSellOrderInMarket() {
		
		try {
			trade = new Trade(orderSELLlow,orderBUYhigh);
		} catch (IllegalTradeExeption | NoMatchingPriceExeption e) {
			
			e.printStackTrace();
		}
		
		log.info(trade);;
		
		assertEquals(LOW_VOLUME, trade.getVolume().toBigInteger().intValue());
		assertEquals(OrderType.SELL, trade.getType());
		
	}
	
	@Test
	public void testIllegalTradeWrongCurrencyPair() {
		
		try {
			trade = new Trade(orderSELLlow,orderOtherCurrency);
		} catch (IllegalTradeExeption e) {
			assertTrue(true);
		} catch (NoMatchingPriceExeption e) {
			e.printStackTrace();
			assertTrue(false);
		}
		
	}
	
	@Test
	public void testIllegalTradeNoMatchingPricesSell() {
		
		try {
			trade = new Trade(orderSELLhigh,orderBUYlow);
		} catch (IllegalTradeExeption e) {
			assertTrue(false);
			e.printStackTrace();
		}catch (NoMatchingPriceExeption e) {
			assertTrue(true);
		}
		
	}
	
	@Test
	public void testIllegalTradeNoMatchingPricesBuy() {
		
		try {
			trade = new Trade(orderBUYlow,orderSELLhigh);
		} catch (IllegalTradeExeption e) {
			assertTrue(false);
			e.printStackTrace();
		}	catch (NoMatchingPriceExeption e) {
			assertTrue(true);
		}
		
	}

}
