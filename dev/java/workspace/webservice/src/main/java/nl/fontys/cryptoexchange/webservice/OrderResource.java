package nl.fontys.cryptoexchange.webservice;

import javax.ws.rs.Consumes;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import nl.fontys.cryptoexchange.core.Order;
import nl.fontys.cryptoexchange.core.exception.InvalidCurrencyPairException;
import nl.fontys.cryptoexchange.core.exception.MarketNotAvailableException;
import nl.fontys.cryptoexchange.webservice.response.Response;

@Path("order")
public class OrderResource {

	private static final String RESOURCE_ROOT = WebRoot.SERVICE_ROOT + "order";

	@Path("/place")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	@PUT
	public Response<Long> createMarket(Order order) {
		Response<Long> response;
	
		
		try {
			response = new Response<Long>(TradeEngineHolder.getTradeEngine().placeOrder(order));
			response.setSuccsess();
		} catch (MarketNotAvailableException e) {
			
			response = new Response<Long>(0L);
			response.setFail(e.getClass().getSimpleName());
		}
		return response;
	}
}
