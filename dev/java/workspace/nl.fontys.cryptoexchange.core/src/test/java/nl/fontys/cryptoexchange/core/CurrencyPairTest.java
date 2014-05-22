package nl.fontys.cryptoexchange.core;

import static org.junit.Assert.*;
import nl.fontys.cryptoexchange.core.exception.InvalidCurrencyPairException;

import org.junit.Test;

public class CurrencyPairTest {
	
	@Test
	public void testConstructorSingleString()
	{
		CurrencyPair pair = null;
		try {
			 pair = new CurrencyPair("zet/btc");
		} catch (InvalidCurrencyPairException e) {
			e.printStackTrace();
			fail();
		}
		
		assertEquals("ZET", pair.getCounterSymbol());
		assertEquals("BTC", pair.getBaseSymbol());
		
	}
	
	@Test
	public void testInvalidCurrencyPairException()
	{
		try {
			new CurrencyPair("zetbtc");
			 fail();
		} catch (InvalidCurrencyPairException e) {
		assertTrue(true);
		}
		
		
	}
	
	@Test
	public void testConstructorDoubleString()
	{
		CurrencyPair pair = null;
			 pair = new CurrencyPair("zet","btc");
		
		
		assertEquals("ZET", pair.getCounterSymbol());
		assertEquals("BTC", pair.getBaseSymbol());
		
	}

}
