package nl.fontys.cryptoexchange.webservice;

import static org.junit.Assert.*;

import javax.ws.rs.core.MediaType;

import nl.fontys.cryptoexchange.core.CurrencyPair;
import nl.fontys.cryptoexchange.core.OrderTest;
import nl.fontys.cryptoexchange.core.exception.InvalidCurrencyPairException;
import nl.fontys.cryptoexchange.core.exception.MarketNotAvailableException;

import org.junit.Test;

import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.WebResource;

public class MarketDataResourceTest {


	
	private static final String WEB_ROOT = "http://localhost:8080/webservice/webresources/marketdata/";
	
	@Test
	public void getMarketDepthGET() throws InvalidCurrencyPairException, MarketNotAvailableException {
		
		String market = CurrencyPair.LTC_BTC.toString();

		TradeEngineHolder.getTradeEngine().createMarket(CurrencyPair.LTC_BTC);
		
		TradeEngineHolder.getTradeEngine().placeOrder(OrderTest.ORDER_BUY_HIGH_USER1);
		
		
		
		Client client = Client.create();
		WebResource webResource = client.resource(WEB_ROOT);
		ClientResponse response = webResource.accept(MediaType.APPLICATION_JSON).put(ClientResponse.class,market);
		if (response.getStatus() != 200) {
			throw new RuntimeException("Failed : HTTP error code : " + response.getStatus());
		}
		
		
		String output = response.getEntity(String.class);
		System.out.println(output);
	
		assertEquals("42", output);
		
}
	

}